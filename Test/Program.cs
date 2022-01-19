using ADO_Example.App;
using ADO_Example.Model;
using System;

namespace Test
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            MySQLConnectionString connection = new MySQLConnectionString("host1323541_itstep", "269f43dc", "host1323541_itstep39", "", "mysql60.hostland.ru");


            var persons = new StudentsDb<Person>(connection.ConnectionString());
            foreach (var person in persons.GetAllPersons())
                Console.WriteLine($"{person.Id}, {person.FirstName}, {person.LastName}");

            var subjects = new StudentsDb<Subject>(connection.ConnectionString());
            foreach (var sub in subjects.GetAllSubjects())
                Console.WriteLine($"{sub.Id}, {sub.SubName}");

            var groups = new StudentsDb<Subject>(connection.ConnectionString());
            foreach (var grp in groups.GetAllGroups())
                Console.WriteLine($"{grp.Id}, {grp.FacultyId}");

            var students = new StudentsDb<Student>(connection.ConnectionString());
            foreach (var stud in students.GetAllStudents())
                Console.WriteLine($"{stud.Id}, {stud.PersonId}, {stud.GroupId}");
        }
   
    }
}
