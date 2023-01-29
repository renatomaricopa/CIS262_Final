using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using HighSchoolClasses.DAL;


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
        public List<SelectListItem> StudentNames { get; set; }

        [BindProperty]
        [DisplayName("Student")]
        [Range(1, double.MaxValue,
        ErrorMessage = "Please select a student")]
        public int StudentId { get; set; }


        [BindProperty]
       
        public int ExamId { get; set; }


        [BindProperty]
        [Range(1,100, ErrorMessage = "Scores have values from 0 to 100")]
        public int Score { get; set; }

        public bool IsSuccess { get; set; }
        //public List<SelectListItem> Exam { get; set; }



        public void OnGet(int id = 0)
        {
            GetStudentNames();

            if (id > 0)
            {

                HighSchoolClasses.DAL.Exam exam  = (HighSchoolClasses.DAL.Exam)_examAdapter.GetByStudentId(id);

                StudentId = exam.StudentId;
                Score = exam.Score;
            }
            
        }

        public void GetStudentNames()
        {
            StudentNames = new List<SelectListItem>();
            IEnumerable<HighSchoolClasses.DAL.Student> students = _studentAdapter.GetAllStudents();
            foreach (HighSchoolClasses.DAL.Student student in students)
            {
                SelectListItem nameToAdd = new SelectListItem();
                nameToAdd.Text = student.FirstName + " " + student.LastName;
                nameToAdd.Value = student.StudentId.ToString();
                StudentNames.Add(nameToAdd);
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
