using PredicateBuilder.Entities;
using PredicateBuilder.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PredicateBuilder.Repository
{   
    public interface IStudentRepository
    {                        
        IQueryable<Student> GetStudents();                        
    }
           
}
