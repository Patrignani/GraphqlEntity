using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphqlEntity.Core.EF.Context;
using GraphqlEntity.Core.Models;
using GraphqlEntity.Core.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphqlEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly GraphqlEntityContext _context;

        public SalesController(GraphqlEntityContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Entity")]
        public async Task<ActionResult> GetAll()
        {
            var sw = new Stopwatch();
            sw.Start();
            var sales = await _context.Sale.Select(x => new Sale
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

            }).ToListAsync();
            sw.Stop();

            _context.Time.Add(new Time
            {
                Identification = "Sales - GetAll",
                TimeExecution = sw.ElapsedMilliseconds
            });

            await _context.SaveChangesAsync();

            return Ok(sales);
        }

        [HttpPost]
        [Route("graphql")]
        public async Task<ActionResult> GetAllGraphql([FromBody]GraphQLQuery query)
        {
            var sw = new Stopwatch();
            sw.Start();

            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new SaleQuery(_context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            sw.Stop();
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

    }
}