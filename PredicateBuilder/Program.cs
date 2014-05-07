using PredicateBuilder.Helpers;
using PredicateBuilder.Process;
using PredicateBuilder.Repository;
using PredicateBuilder.Services;
using System.Collections.Generic;

namespace PredicateBuilder
{
    class Program
    {
        static void Main(string[] args)
        {           
            //+ Client (build the query params)
            var query = BuildQuery();

            //+ Server
            IStudentRepository repository = new StudentRepository(new SimpleContext());
            IStudentService service = new StudentService(repository);            
            
            var simple = service.GetStudents();
            var withFilters = service.GetStudents(query.FilterInfo, query.OrderInfo, query.StartIndex, query.Length);
        }

        public static BaseQuery BuildQuery()
        {
            SimpleQuery query = new SimpleQuery();
            // filters 
            query.FilterInfo = new List<FilterInfo>();
            query.FilterInfo.Add(new FilterInfo() { Logical = Logical.AND, PropertyName = "FirstName", Value = "Taiseer", Operator = Operator.Equals });
            query.FilterInfo.Add(new FilterInfo() { Logical = Logical.AND, PropertyName = "LastName", Value = "Joudeh", Operator = Operator.Contains });
            // orders
            query.OrderInfo = new List<OrderInfo>();
            query.OrderInfo.Add(new OrderInfo()
            {
                Index = 0,
                OrderType = OrderType.DESC,
                Property = "FirstName"
            });
            query.StartIndex = 0;
            query.Length = 1;
            return query;
        }
    }
}
