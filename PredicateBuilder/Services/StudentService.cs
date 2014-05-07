using PredicateBuilder.Base;
using PredicateBuilder.Entities;
using PredicateBuilder.Helpers;
using PredicateBuilder.Process;
using PredicateBuilder.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PredicateBuilder.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IList<Student> GetStudents()
        {
            var queryable = _repository.GetStudents();
            var result = queryable.ToList();
            return result;
        }
        public IList<Student> GetStudents(IList<FilterInfo> filters, IList<OrderInfo> orders, int index, int length)
        {
            var predicate = SimpleHandler<Student>.BuildPredicate(filters);
            if (predicate != null)
            {
                // queryable
                var queryable = _repository.GetStudents();

                // filters
                var filtered = queryable.Where(predicate);

                // orders
                var ordered = OrderHelper.GetOrderedQueryable<Student>(filtered, orders);

                // paged
                var pagination = ordered.Skip(index).Take(length);

                // result (call the linq)
                var result = pagination.ToList();

                return result;
            }
            return null;
        }
    }
}
