using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.RegularExpressions;
using HighSchoolClasses.DAL;

namespace HighSchoolClasses.DAL
{

    public class ReportAdapter
    {
        private string connectionString = @"Data Source = C:\Sqlite\School.db";


        public IEnumerable<Report> GetGrades()
        {
            string sql = @"SELECT "
        }

    }

    //public class ReportGrades
    //{
    //    public int ACount { get; set; }
    //    public int BCount { get; set; }
    //    public int CCount { get; set; }
    //    public int DCount { get; set; }
    //    public int FCount { get; set; }
    //}

    //    Report report = new Report();
    //        foreach(var exam in exams)
    //        {
    //           if(exam.Score > 90)
    //           {
    //              report.ACount++;
    //           }
    //        }
}
