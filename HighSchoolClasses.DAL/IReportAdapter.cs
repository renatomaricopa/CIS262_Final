namespace HighSchoolClasses.DAL
{
    public interface IReportAdapter
    {
        IEnumerable<Report> GetAllExamsAsGrades();
    }
}