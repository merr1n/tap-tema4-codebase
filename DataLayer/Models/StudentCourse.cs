using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class StudentCourse
    {
        public StudentCourse(string name, string student)
        {
            Name = name;
            Student = student;
        }

        public string Name { get; set; }
        public string Student {  get; set; }
    }
}
