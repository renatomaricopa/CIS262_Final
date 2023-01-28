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


        //public IEnumerable<Exam> GetExamByStudentId(int studentId)
        //{
        //    string sql = @"SELECT Score, StudentId, ExamId FROM Exam WHERE StudentId = @StudentId";
        //    using SqliteConnection connection = new(connectionString);
        //    {
        //        return connection.Query<Exam>(sql, new { StudentId = studentId });
        //    }
        //}

        public IEnumerable<Exam> GetGradesByStudentId(int studentId)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Define the SQL command
                // Not working
                //string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam INNER JOIN Student WHERE Exam.StudentId = @ExamId";
                string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam, Student WHERE Exam.StudentId = @";

                // Create a new command object
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    // Execute the command and retrieve the results
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the results
                        while (reader.Read())
                        {
                            // Retrieve the data from the current row
                            int examId = reader.GetInt32(0);
                            int studentGradeId = reader.GetInt32(1);
                            int score = reader.GetInt32(2);
                            string letterGrade = GetLetterGrade(score);
                            string firstName = reader.GetString(3);
                            string lastName = reader.GetString(4);



                            yield return new Exam { ExamId = examId, StudentId = studentGradeId, Score = score, Grade = letterGrade, FirstName = firstName, LastName = lastName };

  

                        }


                    }
                }
            }

        }

        //public IEnumerable<Exam> GetGradesByStudentId(int studentId)
        //{
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        // Open the connection
        //        connection.Open();

        //        // Define the SQL command
        //        string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam INNER JOIN Student WHERE Exam.StudentId = @StudentId";

        //        // Create a new command object
        //        using (SqliteCommand command = new SqliteCommand(sql, connection))
        //        {
        //            // Execute the command and retrieve the results
        //            using (SqliteDataReader reader = command.ExecuteReader())
        //            {
        //                // Iterate through the results
        //                while (reader.Read())
        //                {
        //                    // Retrieve the data from the current row
        //                    int examId = reader.GetInt32(0);
        //                    int studentId_grades = reader.GetInt32(1);
        //                    int score = reader.GetInt32(2);
        //                    string letterGrade = GetLetterGrade(score);
        //                    string firstName = reader.GetString(3);
        //                    string lastName = reader.GetString(4);



        //                    yield return new Exam { ExamId = examId, StudentId = studentId_grades, Score = score, Grade = letterGrade, FirstName = firstName, LastName = lastName };

        //                    // Convert the grade to a letter grade
        //                    //if (grade >= 90)
        //                    //{
        //                    //    letterGrade = "A";
        //                    //}
        //                    //else if (grade >= 80)
        //                    //{
        //                    //    letterGrade = "B";
        //                    //}
        //                    //else if (grade >= 70)
        //                    //{
        //                    //    letterGrade = "C";
        //                    //}
        //                    //else if (grade >= 60)
        //                    //{
        //                    //    letterGrade = "D";
        //                    //}
        //                    //else
        //                    //{
        //                    //    letterGrade = "F";
        //                    //}
        //                    //// here you can add the data to a list or data table
        //                    //// so you can use it to bind it to the report.


        //                }


        //            }
        //        }
        //    }

        //}

        //public char GetGrades()
        //{
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Create a SQL command to retrieve the test scores from the database
        //        using (SqliteCommand command = new SqliteCommand("SELECT * FROM Exam", connection))
        //        {
        //            // Execute the command and retrieve the data
        //            SqliteDataReader reader = command.ExecuteReader();
        //            // From ms.com
        //            using Sqlite
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
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Define the SQL command
                //string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam INNER JOIN Student WHERE Exam.StudentId = @StudentId";
                string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam join Student on Exam.StudentId= Student.StudentId";

                // Create a new command object
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    // Execute the command and retrieve the results
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the results
                        while (reader.Read())
                        {
                            // Retrieve the data from the current row
                            int examId = reader.GetInt32(0);
                            int studentId_grades = reader.GetInt32(1);
                            int score = reader.GetInt32(2);
                            string letterGrade = GetLetterGrade(score);
                            string firstName = reader.GetString(3);
                            string lastName = reader.GetString(4);



                            yield return new Exam { ExamId = examId, StudentId = studentId_grades, Score = score, Grade = letterGrade, FirstName = firstName, LastName = lastName };


                        }


                    }
                }
            }

        }

        //public char GetGrades()
        //{
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Create a SQL command to retrieve the test scores from the database
        //        using (SqliteCommand command = new SqliteCommand("SELECT * FROM Exam", connection))
        //        {
        //            // Execute the command and retrieve the data
        //            SqliteDataReader reader = command.ExecuteReader();
        //            // From ms.com
        //            using Sqlite
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
        //public IEnumerable<Exam> GetAllExamsAsGrades()
        //{
        //    //string sql = "SELECT StudentId, ExamId, Score FROM Exam";
        //    // using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    using (SqliteConnection connection = new(connectionString))
        //    {
        //        connection.Open();

        //        using (SqliteCommand command = new SqliteCommand("SELECT StudentId, ExamId, Score FROM Exam", connection))
        //        {
        //            SqliteDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                int score = (int)reader["Score"];
        //                string letterGrade = GetLetterGrade(score);
        //                yield return new Exam { Grade = letterGrade };
        //            }


        //            //return connection.Query<Exam>(sql);
        //        }
        //    }
        //    //{

        //    //}
        //}

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


}

