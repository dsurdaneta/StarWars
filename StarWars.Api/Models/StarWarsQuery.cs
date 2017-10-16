using GraphQL.Types;
using StarWars.Core.Models;
using System;
using GraphQL.Types;
using StarWars.Core.Data;

namespace StarWars.Api.Models
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery()
        {
            Field<DroidType>(
                "hero",
                resolve: context => new Droid { Id = 1, Name = "R2-D2" }
            );
        }

        /* Using StarWars.Core.Data.IDroidRepository*/
        /*
        private IDroidRepository _droidRepository { get; set; }

        public StarWarsQuery(IDroidRepository _droidRepository)
        {
            Field<DroidType>(
              "hero",
              resolve: context => _droidRepository.Get(1)
            );
        }
        */
    }
}
