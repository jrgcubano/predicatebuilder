using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateBuilder.Process
{
    public abstract class BaseQuery
    {
        public IList<FilterInfo> FilterInfo { get; set; }
        public IList<OrderInfo> OrderInfo { get; set; }
        public int Length { get; set; }
        public int StartIndex { get; set; }
    }
}
