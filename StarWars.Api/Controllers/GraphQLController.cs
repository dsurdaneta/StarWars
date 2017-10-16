using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using StarWars.Api.Models;
using StarWars.Data.InMemory;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        /*
         * Use constructor injection of StarWarsQuery in GraphQLController
         *
          private StarWarsQuery _starWarsQuery { get; set; }

        public GraphQLController(StarWarsQuery starWarsQuery)
        {
            _starWarsQuery = starWarsQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = _starWarsQuery };
        */     

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            /* Using StarWars.Core.Data.IDroidRepository*/
            //var schema = new Schema { Query = new StarWarsQuery(new DroidRepository()) };
            
            var schema = new Schema { Query = new StarWarsQuery() };
           
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}