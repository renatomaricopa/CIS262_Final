namespace HighSchoolClasses.DAL
{
    public interface IExamAdapter
    {
        bool DeleteExamById(int id);
        IEnumerable<Exam> GetAllExams();
        IEnumerable<Exam> GetAllExamsAsGrades();
        Exam GetExamByStudentId(int id);
        bool InsertExam(Exam exam);
        bool UpdateExam(Exam exam);
    }
}