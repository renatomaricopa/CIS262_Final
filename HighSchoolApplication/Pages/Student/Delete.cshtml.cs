using HighSchoolClasses.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApplication.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public int Id { get; set; }
        public DeleteModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public bool IsSuccess = false;

        public void OnGet(int id = 0)
        {
            Id = id;
            if (Id > 0)
            {
                bool IsDelete = _studentAdapter.DeleteStudentById(Id);
                if (IsDelete)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
