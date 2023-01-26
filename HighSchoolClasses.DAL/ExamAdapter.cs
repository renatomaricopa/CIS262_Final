using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace HighSchoolClasses.DAL
{
    //Creating the ExamAdapter class
    public class ExamAdapter : IExamAdapter
    {
        // Database path
        private string connectionString = @"Data Source = C:\sqlite\School.db";

        // GetAllExams Method
        public IEnumerable<Exam> GetAllExams()
        {
            string sql = "SELECT StudentId, ExamId, Score FROM Exam";
            using (SqliteConnection connection = new SqliteConnection(connectionString))

            {
                return connection.Query<Exam>(sql);
            }
        }


        public Exam GetExamByStudentId(int id)
        {
            string sql = @"SELECT Score FROM Exam WHERE StudentId = @StudentId";
            using SqliteConnection connection = new(connectionString);
            {
                return connection.QueryFirst<Exam>(sql, new { StudentId = id });
            }
        }

        //public char GetGrades()
        //{
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Create a SQL command to retrieve the test scores from the database
        //        using (SqliteCommand command = new SqliteCommand("SELECT Score FROM TestScores", connection))
        //        {
        //            // Execute the command and retrieve the data
        //            SqliteDataReader reader = command.ExecuteReader();

        //            // Loop through the retrieved data and convert the scores to letter grades
        //            while (reader.Read())
        //            {
        //                int score = (int)reader["Score"];
        //                string letterGrade = GetLetterGrade(score);
        //                Console.WriteLine("Score: " + score + ", Letter Grade: " + letterGrade);
        //            }
        //        }
        //        connection.Close();
        //    }
        //}
        public IEnumerable<Exam> GetAllExamsAsGrades()
        {
            //string sql = "SELECT StudentId, ExamId, Score FROM Exam";
            // using (SqliteConnection connection = new SqliteConnection(connectionString))
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT StudentId, ExamId, Score FROM Exam", connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int score = (int)reader["Score"];
                        string letterGrade = GetLetterGrade(score);
                        yield return new Exam { Grade = letterGrade };
                    }


                    //return connection.Query<Exam>(sql);
                }
            }
            //{

            //}
        }

        // Function to convert a score to a letter grade
        private static string GetLetterGrade(int score)
        {
            if (score >= 90)
            {
                return "A";
            }
            else if (score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if (score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }



        //public IEnumerable<Exam> DisplayStudentsAndGrades()
        //{
        //    string sql = "SELECT StudentId, ExamId, Score FROM Exam";
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        // From GPTChat 
        //        //connection.Open();

        //        // Create a SQL command to retrieve the test scores from the database
        //        //using (SqliteCommand command = new("SELECT StudentId, ExamId, Score FROM Exam", connection))

        //        //{
        //            // Execute the command and retrieve the data
        //            SqliteDataReader reader = command.ExecuteReader();

        //            // Loop through the retrieved data and convert the scores to letter grades
        //            while (reader.Read())
        //            {
        //                int score = (int)reader["Score"];
        //                string letterGrade = GetLetterGrade(score);
        //                return connection.QueryFirst<Exam>(sql, new { Grade = letterGrade });
        //                //Console.WriteLine("Score: " + score + ", Letter Grade: " + letterGrade);

        //            }
        //       //}

        //        //connection.Close();
        //    }
        //}


        public bool InsertExam(Exam exam)
        {
            string sql = "INSERT INTO Exam (StudentId, Score) VALUES (@StudentId, @Score)";
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
            string sql = @"UPDATE Exam SET StudentId = @StudentId, Score = @Score WHERE ExamId = @ExamId";
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

        public bool DeleteExamById(int id)
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

    //public class ReportGrade
    //{
    //    public int ACount { get; set; }
    //    public int BCount { get; set; }
    //    public int CCount { get; set; }
    //    public int DCount { get; set; }
    //    public int FCount { get; set; }


    //    ReportGrade reportGrade = new ReportGrade();
    //    foreach (var exam in exams)
    //        {
    //            if (exam.Score > 90)
    //            {
    //            reportGrade.ACount++;
    //            }
    //        }

    //}
}

