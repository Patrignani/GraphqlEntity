using GraphQL.Types;
using GraphqlEntity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Field(x => x.Id);
            Field(x => x.Identification);
            Field(
            name: "User",
            type: typeof(UserType),
            resolve: context => context.Source.User
        );

            Field(
           name: "ProductType",
           type: typeof(ProductTypeType),
           resolve: context => context.Source.ProductType
       );

        }
    }
}
