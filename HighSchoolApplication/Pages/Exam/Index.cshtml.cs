using HighSchoolClasses.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }


        public void OnGet()
        {
                Exams = _examAdapter.GetAllExams(); 
        }

        // OnPost
        public void OnPost()
        {
            // IsSuccess = true;
        }
    }
}
