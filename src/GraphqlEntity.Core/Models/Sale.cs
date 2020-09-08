using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual User User { get; set; }
    }
}
