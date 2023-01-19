using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace HighSchoolClasses.DAL
{
    public class StudentAdapter : IStudentAdapter
    {
        private string connectionString = @"Data Source = C:\sqlite\School.db";
        public IEnumerable<Student> GetAllStudents()
        {
            string sql = "SELECT StudentId, StudentFirstName, StudentLastName FROM Student";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Student>(sql);
            }
        }
    }
}
