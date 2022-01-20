using System;
using System.Collections.Generic;
using System.IO;
using ADO_Example.Model;
using MySql.Data.MySqlClient;

namespace ADO_Example.App
{
    public class StudentsDb<T>
    {
        private readonly MySqlConnection _db;
        private MySqlCommand _command;

        public StudentsDb()
        {
            if (File.Exists("connect_to_db.ini"))
            {
                var str = File.ReadAllText("connect_to_db.ini");
                _db = new MySqlConnection(str);
                _command = new MySqlCommand { Connection = _db };

            }
            else
                throw new Exception("file don't exists");
            
        }

        public StudentsDb(string connectionString)
        {
          
            if (connectionString == null)
                throw new Exception("connectionString is null");

            _db = new MySqlConnection(connectionString);
            _command = new MySqlCommand { Connection = _db };

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
            var res = Query("tab_persons","id","first_name","last_name");
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
        public List<Student> GetAllStudents()
        {
            var students  = new List<Student>();
            Open();
            var res = Query("tab_students","person_id","group_id");
            while (res.Read())
            {
                students.Add(new  Student 
                {
                    Id = res.GetInt32("id"),
                    PersonId = res.GetString("person_id"),
                    GroupId = res.GetString("group_id"),
                });
            }

            Close();

            return students ;
        }

        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            Open();
            var res = Query("tab_subjects","id","name");
            while (res.Read())
            {
                subjects.Add(new Subject
                {
                    Id = res.GetInt32("id"),
                    SubName = res.GetString("name"),
                });
            }

            Close();

            return subjects;
        }
        public List<Group> GetAllGroups()
        {
            var groups = new List<Group>();
            Open();
            var res = Query("tab_groups","id","name","faculty_id");
            while (res.Read())
            {
                groups.Add(new Group
                {
                    Id = res.GetInt32("id"),
                    GroupName = res.GetString("name"),
                    FacultyId = res.GetString("faculty_id"),
                });
            }

            Close();

            return groups;
        }

        private MySqlDataReader Query(string table, params string[] values)

        {
            string str="";
            for (int i = 0; i < values.Length; i += 1) {
                str += values[i];
                if (i != values.Length - 1)
                    str += ",";
                    }

            var sql = $"SELECT {str} FROM {table}";
            _command.CommandText = sql;
            var res = _command.ExecuteReader();

            return res;

        }
    }
}