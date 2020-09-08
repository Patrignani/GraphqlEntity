using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Models
{
    public class Time
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public float TimeExecution { get; set; }
    }
}
