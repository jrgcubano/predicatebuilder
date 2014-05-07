using PredicateBuilder.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PredicateBuilder.Helpers
{
    public static class OrderHelper
    {
        #region Process Data (sort, group)

        public static EnumerableQuery GroupBy(this IOrderedQueryable source, string property)
        {
            return ApplyGroup(source, property, "GroupBy");
        }
        public static IOrderedQueryable OrderBy(this IQueryable source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }
        public static IOrderedQueryable OrderByDescending(this IQueryable source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable ThenBy(this IOrderedQueryable source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }
        public static IOrderedQueryable ThenByDescending(this IOrderedQueryable source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }
        static IOrderedQueryable ApplyOrder(IQueryable source, string property, string methodName)
        {
            //string[] props = property.Split('.');
            Type type = source.ElementType;
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            //foreach (string prop in props)
            //{
            //    // reflection
                PropertyInfo pi = type.GetProperty(property);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            //}
            Type delegateType = typeof(Func<,>).MakeGenericType(source.ElementType, type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(source.ElementType, type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable)result;
        }

        static EnumerableQuery ApplyGroup(IQueryable source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = source.ElementType;
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // reflection
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(source.ElementType, type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(source.ElementType, type)
                    .Invoke(null, new object[] { source, lambda });
            return (EnumerableQuery)result;
        }


        public static IQueryable<T> GetOrderedQueryable<T>(IQueryable<T> queryable, IList<OrderInfo> orders) where T: class
        {
            IOrderedQueryable orderedQueryable = null;
            //if (orders != null && orders.Count > 0)
            //{
                OrderInfo info = null;
                for (int i = 0; i < orders.Count; i++)
                {
                    info = orders[i];
                    if (info.OrderType.Equals(OrderType.ASC))
                    {
                        if (i == 0)
                            orderedQueryable = OrderBy(queryable, info.Property);
                        else
                            orderedQueryable = ThenBy(orderedQueryable, info.Property);
                    }
                    else if (info.OrderType.Equals((OrderType.DESC)))
                    {
                        if (i == 0)
                            orderedQueryable = OrderByDescending(queryable, info.Property);
                        else
                            orderedQueryable = ThenByDescending(orderedQueryable, info.Property);
                    }
                }
                IQueryable<T> result = (IQueryable<T>)orderedQueryable;
                return result;
            //}
        }
        #endregion

    }
}
