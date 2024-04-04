namespace WebAPI.Dto
{
    public class StudentDto
    {
        public StudentDto(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
