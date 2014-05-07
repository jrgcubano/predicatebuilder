using PredicateBuilder.Entities;
using PredicateBuilder.Helpers;
using PredicateBuilder.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PredicateBuilder.Base
{
    public static class SimpleHandler<T>
    {
        public static Expression<Func<T, bool>> BuildPredicate(IList<FilterInfo> filters)
        {
            // FilterInfo
            var predicate = ModPredicateBuilder.Create<T>(item => true);

            foreach(var info in filters)
            {
                if (info.Logical == Logical.OR)
                    predicate = predicate.Or(BuildExpression(info));
                else
                    predicate = predicate.And(BuildExpression(info));
            }

            return predicate;
        }      
        
        public static Expression<Func<T, bool>> BuildExpression(FilterInfo info)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "parm");
            Expression exp = ExpressionBuilder.GetExpression<T>(param, info);
            var lambda = Expression.Lambda<Func<T, bool>>(exp, param);
            return lambda;
        }        
    }
}
