using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Identification { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
