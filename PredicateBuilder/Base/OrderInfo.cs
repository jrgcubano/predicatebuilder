using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateBuilder.Process
{
    public class OrderInfo
    {
        public OrderType OrderType { get; set; }
        public string Property { get; set; }
        public int Index { get; set; }
    }

    public enum OrderType
    {
        None = 0,
        ASC = 1,
        DESC = 2
    }
}
