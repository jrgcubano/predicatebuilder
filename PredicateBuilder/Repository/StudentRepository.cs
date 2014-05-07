using PredicateBuilder.Entities;
using System.Linq;

namespace PredicateBuilder.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SimpleContext _ctx;
        public StudentRepository(SimpleContext ctx)
        {
            _ctx = ctx;
        }       

        public IQueryable<Student> GetStudents()
        {        
            var queryable = _ctx.Students.AsQueryable();
            return queryable;
        }
    }
}
