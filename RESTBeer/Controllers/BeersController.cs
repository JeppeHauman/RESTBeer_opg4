using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opgave_1;
using RESTBeer.Managers;

namespace RESTBeer.Controllers
{
    [Route("beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeerManager _beerManager = new BeerManager();

        // GET: api/Beers
        [HttpGet]
        public IEnumerable<Beer> Get([FromQuery]string name, [FromQuery] string sort_by)
        {
            return _beerManager.GetAll(name, sort_by);
        }

        // GET: api/Beers/5
        [HttpGet("{id}")]
        public Beer Get(int id)
        {
            return _beerManager.GetById(id);
        }

        // POST: api/Beers
        [HttpPost]
        public Beer Post([FromBody] Beer value)
        {
            return _beerManager.Add(value);
        }

        // PUT: api/Beers/5
        [HttpPut("{id}")]
        public Beer Put(int id, [FromBody] Beer value)
        {
            return _beerManager.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Beer Delete(int id)
        {
            return _beerManager.Delete(id);
        }
    }
}
