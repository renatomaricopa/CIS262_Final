using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

using HighSchoolClasses.DAL;
using System.ComponentModel;

namespace HighSchoolApplication.Pages.Exam
{
    public class EditModel : PageModel
    {
        private IExamAdapter _examAdapter;
        private IStudentAdapter _studentAdapter;

        public EditModel(IExamAdapter examAdapter, IStudentAdapter studentAdapter)
        {
            _examAdapter = examAdapter;
            _studentAdapter = studentAdapter;
        }
        public List<SelectListItem> StudentOptions { get; set; }
        [BindProperty]
        [DisplayName("Student")]
        [Range(1, double.MaxValue,
        ErrorMessage = "Please select a student")]

  
        public int StudentId { get; set; }
        [BindProperty]
        [Range(1, 15000)]

     
        public int ExamId { get; set; }
        [BindProperty]
        public int Score { get; set; }
        public bool IsSuccess { get; set; }
        public List<SelectListItem> Exam { get; set; }



        public void OnGet(int studentId = 0)
        {
            if (studentId > 0)
            {
                //HighSchoolClasses.DAL.Exam exam = (HighSchoolClasses.DAL.Exam)_examAdapter.GetGradesByStudentId(studentId);
                HighSchoolClasses.DAL.Exam exam = (HighSchoolClasses.DAL.Exam)_examAdapter.GetGradesByStudentId(studentId);

                if (exam != null)
                {
                    ExamId = exam.ExamId;
                    StudentId = exam.StudentId;
                    ExamId = exam.Score;
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                HighSchoolClasses.DAL.Exam exam = new HighSchoolClasses.DAL.Exam();
                exam.StudentId = StudentId;
                exam.ExamId = ExamId;
                exam.Score = Score;

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
