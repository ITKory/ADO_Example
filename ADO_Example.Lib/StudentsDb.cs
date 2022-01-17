using System.Collections.Generic;
using System.IO;
using ADO_Example.Model;
using MySql.Data.MySqlClient;

namespace ADO_Example.App
{
    public class StudentsDb
    {
        private readonly MySqlConnection _db;
        private MySqlCommand _command;

        public StudentsDb()
        {
            var str = File.ReadAllText("connect_to_db.ini"); //TODO Сделать проверку файла
            _db = new MySqlConnection(str);
            _command = new MySqlCommand { Connection = _db};
        }

        public StudentsDb(string connectionString)
        {
            //TODO Сделать проверку входящего аргумента
            _db = new MySqlConnection(connectionString);
            _command = new MySqlCommand { Connection = _db};
        }

        public void Open() => _db.Open();

        public void Close() => _db?.Close();

        public bool AddPerson(Person person)
        {
            Open();
            
            var sql = $"INSERT INTO tab_persons (first_name, last_name) VALUES ('{person.FirstName}', '{person.LastName}');";
            _command.CommandText = sql;
            var res = _command.ExecuteNonQuery();
            
            Close();
            
            return res == 1;
        }

        public List<Person> GetAllPersons()
        {
            var persons = new List<Person>();
            
            Open();

            var sql = "SELECT id, first_name, last_name FROM tab_persons";
            _command.CommandText = sql;

            var res = _command.ExecuteReader();
            while (res.Read())
            {
                persons.Add(new Person
                {
                    Id = res.GetInt32("id"),
                    FirstName = res.GetString("first_name"),
                    LastName = res.GetString("last_name"),
                });
            }
            
            Close();

            return persons;
        }
    }
}