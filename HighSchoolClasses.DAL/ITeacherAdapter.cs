namespace HighSchoolClasses.DAL
{
    public interface ITeacherAdapter
    {
        bool DeleteTeacherById(int id);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        bool InsertTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
    }
}