using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Teacher
{
    public class EditModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public EditModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }

        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }
        public List<SelectListItem> Teacher { get; set; }
        [BindProperty]
        public int TeacherId { get; set; }


        public void OnGet(int id = 0)
        {
            if (id != 0)
            {
                HighSchoolClasses.DAL.Teacher teacher = _teacherAdapter.GetTeacherById(id);
                if (teacher != null)
                {
                    FirstName = teacher.FirstName;
                    LastName = teacher.LastName;
                    TeacherId = teacher.TeacherId;
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                HighSchoolClasses.DAL.Teacher teacher = new HighSchoolClasses.DAL.Teacher();
                teacher.FirstName = FirstName;
                teacher.LastName = LastName;
                teacher.TeacherId = TeacherId;

                if (TeacherId > 0)
                {
                    bool isUpdate = _teacherAdapter.UpdateTeacher(teacher);
                    if (isUpdate)
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
                    bool isCreate = _teacherAdapter.InsertTeacher(teacher);
                    if (isCreate)
                    {
                        IsSuccess = true;
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
