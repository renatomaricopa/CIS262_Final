using HighSchoolClasses.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace HighSchoolApplication.Pages.Exam
{ 
    public class IndexModel : PageModel
    {
        private readonly IExamAdapter _examAdapter;
        public IndexModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public IEnumerable<HighSchoolClasses.DAL.Exam> Exams { get; set; }

        // Variables declaration
        //[BindProperty]
        //public string FirstName { get; set; }
        //[BindProperty]
        //public string LastName { get; set; }
        //public bool IsSuccess { get; set; }

        //public void Grades { get; set; }


        public void OnGet(int id=0)
        {
           

            if (id == 0)
            {
                //Exams = _examAdapter.GetAllExams();
                //Exams = _examAdapter.GetGrades();
                Exams = _examAdapter.GetAllExamsAsGrades();
                
                //Grades = _examAdapter.ConvertGraddeToLetter(id);
            }
            else
            {
                //Exams = _examAdapter.GetExamByStudentId(id);
                Exams = _examAdapter.GetGradesByStudentId(id);
            }
        }

        //public int PlusHundred(int grade)
        //{
        //    int gradeHundred = grade + 100;
        //    return gradeHundred;
        //}

        //{
        //        Exams = _examAdapter.GetAllExams(); 
        //}
        // OnPost
        //public void OnPost()
        //{
        //    // IsSuccess = true;
        //}
    }
}
