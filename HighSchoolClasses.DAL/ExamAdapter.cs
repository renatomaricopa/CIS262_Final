using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace HighSchoolClasses.DAL
{
    public class ExamAdapter : IExamAdapter
    {
        private string connectionString = @"Data Source = C:\sqlite\School.db";
        public IEnumerable<Exam> GetAllExams()
        {
            string sql = "SELECT StudentId, ExamId, Score FROM Exam";
            using (SqliteConnection connection = new SqliteConnection(connectionString))

            {
                return connection.Query<Exam>(sql);
            }
        }
    }
}
