using PredicateBuilder.Entities;
using PredicateBuilder.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateBuilder.Services
{
    public interface IStudentService
    {
        IList<Student> GetStudents();
        IList<Student> GetStudents(IList<FilterInfo> filters, IList<OrderInfo> orders, int index, int length);
    }
}
