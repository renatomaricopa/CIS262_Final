namespace HighSchoolClasses.DAL
{
    public interface IReportAdapter
    {
        IEnumerable<Exam> GetAllExams();
        IEnumerable<Exam> GetAllExamsAsGrades();
        IEnumerable<Exam> GetGradesByStudentId(int studentId);
    }
}