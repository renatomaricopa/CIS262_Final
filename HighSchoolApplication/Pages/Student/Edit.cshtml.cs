using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Student
{
    public class EditModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public EditModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }

        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }
        public List<SelectListItem>Student { get; set; }
        [BindProperty]
        public int StudentId { get; set; }


        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                HighSchoolClasses.DAL.Student student = _studentAdapter.GetStudentById(id);
                if (student != null)
                {
                    FirstName = student.FirstName;
                    LastName = student.LastName;
                    StudentId = student.StudentId;
                }
            }
        }
        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                HighSchoolClasses.DAL.Student student = new HighSchoolClasses.DAL.Student();
                student.FirstName = FirstName;
                student.LastName = LastName;
                student.StudentId = StudentId;

                if (StudentId > 0)
                {
                    bool isUpdate = _studentAdapter.UpdateStudent(student);
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
                    bool isCreate = _studentAdapter.InsertStudent(student);
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
                    IsSuccess= false; 
                }
        }
    }
}
