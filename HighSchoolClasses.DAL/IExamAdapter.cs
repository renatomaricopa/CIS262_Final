namespace HighSchoolClasses.DAL
{
    public interface IExamAdapter
    {
        bool DeleteExamById(int id);
        IEnumerable<Exam> GetAllExams();
        IEnumerable<Exam> GetAllExamsAsGrades();
        IEnumerable<Exam> GetGradesByStudentId(int studentId);
        bool InsertExam(Exam exam);
        bool UpdateExam(Exam exam);
    }
}