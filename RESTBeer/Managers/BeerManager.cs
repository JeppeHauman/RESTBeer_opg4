using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Opgave_1;

namespace RESTBeer.Managers
{
    public class BeerManager
    {
        private static int _nextId = 1;

        private static readonly List<Beer> Data = new List<Beer>
        {
            new Beer(_nextId++, "Turborg Classic", 10, 4.6),
            new Beer(_nextId++, "Grøn Tuborg", 9, 5),
            new Beer(_nextId++, "Turborg Rå", 12, 5.2)
        };

        public List<Beer> GetAll(string name = null, string sortBy = null)
        {
            List<Beer> beers = new List<Beer>(Data);

            if (name != null)
            {
                beers = beers.FindAll(beer => beer.Name != null && beer.Name.ToLower().StartsWith(name));
            }

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        beers = beers.OrderBy(beer => beer.Name).ToList();
                        break;
                    case "price":
                        beers = beers.OrderBy(beer => beer.Price).ToList();
                        break;
                    case "abv":
                        beers = beers.OrderBy(beer => beer.Abv).ToList();
                        break;
                }
            }
            return beers;
        }

        public Beer GetById(int id)
        {
            return Data.Find(beer => beer.Id == id);
        }

        public Beer Add(Beer newBeer)
        {
            newBeer.Id = _nextId++;
            Data.Add(newBeer);
            return newBeer;
        }

        public Beer Delete(int id)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            Data.Remove(beer);
            return beer;
        }

        public Beer Update(int id, Beer updates)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            beer.Name = updates.Name;
            beer.Price = updates.Price;
            beer.Abv = updates.Abv;
            return beer;
        }
    }
}
