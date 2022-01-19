using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Example.Model
{
    public class MySQLConnectionString
    {
       private readonly string _server;
       private readonly string _user;
       private readonly string _pass;
       private readonly string _port;
       private   readonly string _dataBase;

        public MySQLConnectionString( string user, string pass,string dataBase, string port = "3306", string server = "localhost")
        {
            _server = server;
            _user = user;
            _pass = pass;
            _port = port;
            _dataBase = dataBase;
        }
        public string ConnectionString() 
        {
            string connStr =
                    "Server=" + _server + ";" +
                    "Database=" + _dataBase + ";" +
                    "Uid=" + _user + ";" +
                    "Pwd=" + _pass + ";" +
                    "Port =" + _port + ";";
            return connStr;
        }

    }
}
