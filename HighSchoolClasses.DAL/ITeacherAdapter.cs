namespace HighSchoolClasses.DAL
{
    public interface ITeacherAdapter
    {
        IEnumerable<Teacher> GetAllTeachers();
    }
}