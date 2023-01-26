using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Teacher
{
    public class DeleteModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public int Id { get; set; }
        public DeleteModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        public bool IsSuccess = false;

        public void OnGet(int id = 0)
        {
            Id = id;
            if (Id > 0)
            {
                bool IsDelete = _teacherAdapter.DeleteTeacherById(Id);
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