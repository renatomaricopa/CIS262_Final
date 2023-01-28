using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HighSchoolClasses.DAL;
using System.Security.Cryptography.X509Certificates;


namespace HighSchoolApplication.Pages
{
    public class ReportModel : PageModel
    {
        private readonly IReportAdapter _reportAdapter;
        public ReportModel(IReportAdapter reportAdapter)
        {
            _reportAdapter = reportAdapter;
        }
        public IEnumerable<Report> Reports { get; set; }

        //public IEnumerable<HighSchoolClasses.DAL.Report> ReportRows { get; set; }
        public void OnGet(int id = 0)
        {
                   Reports = _reportAdapter.GetAllExamsAsGrades();
        }
    }
}

