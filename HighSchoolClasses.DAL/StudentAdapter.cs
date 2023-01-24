using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Security.Cryptography.X509Certificates;

namespace HighSchoolClasses.DAL
{
    // Creating the StudentAdapter class
    public class StudentAdapter : IStudentAdapter
    {
        // Database path
        private string connectionString = @"Data Source = C:\sqlite\School.db";

        // GetAllStudents Method
        public IEnumerable<Student> GetAllStudents()
        {
            string sql = "SELECT StudentId, FirstName, LastName FROM Student";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Student>(sql);
            }
        }
        public Student GetStudentById(int id)
        {
            string sql = @"SELECT StudentId, FirstName, LastName FROM Student WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.QueryFirst<Student>(sql, new { StudentId = id });
            }
        }
        public bool InsertStudent(Student student)
        {
            string sql = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, student);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Information Recoder");
                    return true;
                }
                else
                {
                    Console.WriteLine("Information not recorded.");
                    return false;
                }
            }
        }

        public bool UpdateStudent(Student student)
        {
            string sql = @"UPDATE Student SET FirstName = @FirstName, LastName = @LastName WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, student);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool DeleteStudentById(int id)
        {
            string sql = "DELETE FROM Student WHERE StudentId = @StudentId";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                int rowsAffected = connection.Execute(sql, new { StuentId = id });
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}   

