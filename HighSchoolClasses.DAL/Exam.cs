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
        
    }
    
}
