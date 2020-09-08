using GraphQL.Types;
using GraphqlEntity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.Types
{
    public class SaleType : ObjectGraphType<Sale>
    {
        public SaleType()
        {
            Name = "Sale";
            Field(x => x.Id);
            Field(x => x.Identification);
            Field(
            name: "User",
            type: typeof(UserType),
            resolve: context => context.Source.User
            );
            Field(
           name: "Product",
           type: typeof(ProductType),
           resolve: context => context.Source.Product
           );
         
        }
    }
}
