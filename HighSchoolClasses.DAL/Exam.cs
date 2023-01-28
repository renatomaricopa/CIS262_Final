namespace HighSchoolClasses.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.Sqlite;
    using Dapper;
    public class Exam
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }

        // Added this so we can create an Exam object that has a Grade property
        public string Grade { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        
    }
    
}
