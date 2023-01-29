# CIS262_Final
CIS262 Final Project

Project

For this project, create a Web-based ASP.NET Application. 
This application will be used by a high school to keep track of teachers, students, and student exam scores. 
You must create a user interface that allows a user to view, insert, update, and delete data from the following tables:

Teacher
Student
Exam

The teacher table has the following columns:

TeacherId (int)
FirstName (string)
LastName (string)

The student table has the following columns:

StudentId (int)
FirstName (string)
LastName (string)

The exam table has the following columns:

ExamId (int)
StudentId (int)
Score (int)

Access the SQLite database that contains these tables (opens in a new tab)ZIP compressed file. 
You will notice there is no data included in the tables. 
After you design your application, enter at least 5 teachers, 5 students, and 10 exam scores into the database using your user interface. 
This is an excellent opportunity to test your application.

The database is set up to automatically increment the ID columns 
(e.g., TeacherId, StudentId, and ExamId), so you don't need to worry about adding these values when inserting new records.

You must use the program design skills you have learned in this course. So you know what is expected, review the rubric for more information.

You must use the user interface principles that you learned in this course. 
Make sure that your application looks good and is easy for users to use (review the rubric for more information on this). 
Make sure to validate the exam scores that users enter (use range checks).

Lastly, create a Report page that displays the total number of letter grades by type (A, B, C, D, and F). 
If 10 exams are entered in the database, then the total number of letter grades in the report is 10 
(Tip: A simple way to generate this report is to use the same method that you created to retrieve all data from the exam table). 
Create an MVC model that you pass to the report page. You can create this report in any format that you would like (e.g., table or chart).
