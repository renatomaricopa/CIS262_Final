namespace HighSchoolClasses.DAL
{
    public interface IStudentAdapter
    {
        IEnumerable<Student> GetAllStudents();
    }
}