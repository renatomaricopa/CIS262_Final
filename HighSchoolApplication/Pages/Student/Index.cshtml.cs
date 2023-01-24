using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Student
{
    public class IndexModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public IndexModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public IEnumerable<HighSchoolClasses.DAL.Student> Students { get; set; }
        // Variables declaration
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }

        // OnGet
        public void OnGet()
        {
            Students = _studentAdapter.GetAllStudents();
        }

        // OnPost
        public void OnPost()
        {
           // IsSuccess = true;
        }
    }
}
