using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        private readonly ITeacherAdapter _teacherAdapter;
        public IndexModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        public IEnumerable<HighSchoolClasses.DAL.Teacher> Teachers { get; set; }

        // Variables declaration
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }

        // OnGet
        public void OnGet()
        {
            Teachers = _teacherAdapter.GetAllTeachers();
        }

        // OnPost
        public void OnPost()
        {
            // IsSuccess = true;
        }
    }
}
