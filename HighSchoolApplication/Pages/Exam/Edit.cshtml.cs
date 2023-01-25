using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

using HighSchoolClasses.DAL;

namespace HighSchoolApplication.Pages.Exam
{
    public class EditModel : PageModel
    {
        private IExamAdapter _examAdapter;
        public EditModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }

        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }
        public List<SelectListItem> Exam { get; set; }
        [BindProperty]
        public int ExamId { get; set; }


        public void OnGet(int id = 0)
        {
            if (id != 0)
            {
                HighSchoolClasses.DAL.Exam exam = _examAdapter.GetExamById(id);
                if (exam != null)
                {
                    FirstName = exam.FirstName;
                    LastName = exam.LastName;
                    ExamId = exam.StudentId;
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                HighSchoolClasses.DAL.Exam exam = new HighSchoolClasses.DAL.Exam();
                exam.FirstName = FirstName;
                exam.LastName = LastName;
                exam.ExamId = ExamId;

                if (ExamId > 0)
                {
                    bool isUpdate = _examAdapter.UpdateExam(exam);
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
                    bool isCreate = _examAdapter.InsertExam(exam);
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
