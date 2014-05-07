using PredicateBuilder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredicateBuilder.Process
{
    public class FilterInfo
    {        
        public Logical Logical { get; set; }        
        public string PropertyName { get; set; }
        public string Value { get; set; }
        private Operator _op = Operator.Contains;
        public Operator Operator
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public enum Logical
    {
        OR,
        AND
    }  
}
