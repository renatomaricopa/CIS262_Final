using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HighSchoolClasses.DAL;
using System.Security.Cryptography.X509Certificates;


namespace HighSchoolApplication.Pages
{
    public class ReportModel : PageModel
    {
        private readonly IExamAdapter _examAdapter;
        public ReportModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public IEnumerable<HighSchoolClasses.DAL.Exam> Exams { get; set; }

        public IEnumerable<Report> ReportRows { get; set; }
        public void OnGet(int id = 0)
        {


            if (id == 0)
            {
                Exams = _examAdapter.GetAllExamsAsGrades();

            }
            else
            { 
                Exams = _examAdapter.GetGradesByStudentId(id);
            }
        }
    }
}

