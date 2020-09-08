using GraphQL.Types;
using GraphqlEntity.Core.EF.Context;
using GraphqlEntity.Core.Models;
using GraphqlEntity.Core.Types;
using System.Linq;
using ProductType = GraphqlEntity.Core.Models.ProductType;

namespace GraphqlEntity.Core.Query
{
    public class SaleQuery : ObjectGraphType
    {
        public SaleQuery(GraphqlEntityContext context)
        {
            Field<ListGraphType<SaleType>>(
                   "Sale",
                   resolve: a =>
                   {
                       var sales = context.Sale.Select(x => new Sale
                       {
                           Id = x.Id,
                           Identification = x.Identification,
                           UserId = x.UserId,
                           User = new User
                           {
                               Id = x.User.Id,
                               Identification = x.User.Identification
                           },
                           Product = x.Product.Select(y => new Product
                           {
                               Id = y.Id,
                               Identification = y.Identification,
                               UserId = y.UserId,
                               ProductTypeId = y.ProductTypeId,
                               ProductType = new ProductType
                               {
                                   Id = y.ProductType.Id,
                                   Identification = y.ProductType.Identification
                               },
                               User = new User
                               {
                                   Id = y.User.Id,
                                   Identification = y.User.Identification
                               }
                           }).ToList()

                       });

                       return sales;
                   });
        }
    }
}
