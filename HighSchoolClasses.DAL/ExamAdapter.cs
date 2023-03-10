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
		public Exam GetByStudentId(int studentId)
		{
			string sql = "SELECT ExamId, StudentId, Score FROM Exam WHERE StudentId = @StudentId";
			using (SqliteConnection connection = new SqliteConnection(connectionString))
			{
				return connection.QueryFirst<Exam>(sql, new { StudentId = studentId });
			}
		}
		public IEnumerable<Exam> GetGradesByStudentId(int studentId)
		{
			using (SqliteConnection connection = new SqliteConnection(connectionString))
			{
				// Open the connection
				connection.Open();

				// Define the SQL command
				// Not working
				//string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam INNER JOIN Student WHERE Exam.StudentId = @ExamId";
				string sql = "SELECT Exam.ExamId, Exam.StudentId, Exam.Score, Student.FirstName, Student.LastName FROM Exam, Student WHERE Exam.StudentId = @StudentId";

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

