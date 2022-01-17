using System.IO;
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
        
        
    }
}