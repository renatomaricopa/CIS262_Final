namespace HighSchoolClasses.DAL
{
    public interface IStudentAdapter
    {
        bool DeleteStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
    }
}