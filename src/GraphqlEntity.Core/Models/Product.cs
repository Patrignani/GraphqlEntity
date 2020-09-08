using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public int ProductTypeId { get; set; }
        public int UserId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual User User { get; set; }
    }
}
