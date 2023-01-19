using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace HighSchoolClasses.DAL
{

    public class TeacherAdapter : ITeacherAdapter
    {
        private string connectionString = @"Data Source = C:\sqlite\School.db";
        public IEnumerable<Teacher> GetAllTeachers()
        {
            string sql = "SELECT TeacherId, TeacherFirstName, TeacherLastName FROM Teacher";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                return connection.Query<Teacher>(sql);
            }
        }
    }
}
