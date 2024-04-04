namespace WebAPI.Dto
{
    public class StudentCourseDto
    {

        public StudentCourseDto(string name, string student)
        {
            Name = name;
            Student = student;
        }

        public string Name { get; set; }
        public string Student { get; set; }
    }
}
