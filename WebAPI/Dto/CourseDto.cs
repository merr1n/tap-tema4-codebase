namespace WebAPI.Dto
{
    public class CourseDto
    {
        public CourseDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
