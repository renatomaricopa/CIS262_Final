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
        public Student GetExamById(int id)
        {
            string sql = @"SELECT StudentId, FirstName, LastName FROM Student WHERE StudentId = @StudentId";
            using SqliteConnection connection = new(connectionString);
            {
                return connection.QueryFirst<Student>(sql, new { StudentId = id });
            }
        }
        public bool InsertExam(Exam exam)
        {
            string sql = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";
            using SqliteConnection connection = new(connectionString);
            {
                int rowsAffected = connection.Execute(sql, exam);
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

        public bool UpdateExam(Exam exam)
        {
            string sql = @"UPDATE Student SET FirstName = @FirstName, LastName = @LastName WHERE StudentId = @StudentId";
            using SqliteConnection connection = new(connectionString);
            {
                int rowsAffected = connection.Execute(sql, exam);
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
            string sql = "DELETE FROM Exam WHERE ExamId = @ExamId";
            using SqliteConnection connection = new(connectionString);
            {
                int rowsAffected = connection.Execute(sql, new { ExamId = id });
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
