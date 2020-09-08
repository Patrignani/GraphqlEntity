using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Types
{
   public  class ProductTypeType : ObjectGraphType<Core.Models.ProductType>
    {
        public ProductTypeType()
        {
            Name = "ProductType";
            Field(x => x.Id);
            Field(x => x.Identification);
        }
    }
}
