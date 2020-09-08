using System.Collections.Generic;

namespace GraphqlEntity.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Identification { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        
    }
}
