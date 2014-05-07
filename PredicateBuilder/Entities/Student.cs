using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateBuilder.Entities
{
    public class Student
    {
        public Student()
        {           
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
