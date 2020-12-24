using System;
using System.Collections.Generic;
using System.Text;

namespace EFday1
{
    public class Operation : BaseEntity
    {
        public decimal Summ { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
