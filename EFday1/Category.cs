using System;
using System.Collections.Generic;
using System.Text;

namespace EFday1
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
