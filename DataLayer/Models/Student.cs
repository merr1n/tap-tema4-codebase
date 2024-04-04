using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Student
    {
        public Student(string name, string surname, string email)
        {
            Id= Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        public string Email { get; set;}
    }
}
