using GraphqlEntity.Core.EF.Context;
using System.Collections.Generic;
using System.Linq;

namespace GraphqlEntity.Core.EF.Configure
{
    internal static class AddInitialData
    {
        internal static GraphqlEntityContext AddUser(this GraphqlEntityContext context)
        {
            if (!context.User.Any(x => x.Identification == "InitialUSer"))
            {
                var userInit = new Models.User
                {
                    Identification = "InitialUSer"
                };

                var userCommum = new Models.User
                {
                    Identification = "userCommum"
                };

                var userSales = new Models.User
                {
                    Identification = "userSales"
                };

                context.User.Add(userInit);
                context.User.Add(userCommum);
                context.User.Add(userSales);

                var pc = new Models.ProductType
                {
                    Identification = "PC2"
                };

                context.ProductType.Add(pc);

                var placaMae = new Models.Product
                {
                    Identification = "Placa de video",
                    ProductType = pc,
                    User = userCommum
                };

                context.Product.Add(placaMae);

                context.Sale.Add(new Models.Sale
                {
                    Identification = "Initial",
                    Product = new List<Models.Product>
                    {
                        new Models.Product
                        {
                            Identification= "Placa de video",
                            ProductType =pc,
                            User = userCommum
                        },
                        placaMae
                    },
                    User = userInit
                });

                context.Sale.Add(new Models.Sale
                {
                    Identification = "Initial2",
                    Product = new List<Models.Product>
                    {
                        new Models.Product
                        {
                            Identification= "Placa de video2",
                            ProductType = pc,
                            User = userInit
                        },
                        placaMae
                    },
                    User = userInit
                });
            }

            return context;
        }

        internal static GraphqlEntityContext AddSales(this GraphqlEntityContext context)
        {
            if (!context.Sale.Any(x => x.Identification == "Initial"))
            {
               var user = context.User.Where(x => x.Identification == "InitialUSer").FirstOrDefault();
               ;
            }
            return context;
        }

     
        internal static GraphqlEntityContext Commit(this GraphqlEntityContext context)
        {
            context.SaveChanges();
            return context;
        }
    }
}
