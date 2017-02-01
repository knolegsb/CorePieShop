using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorePieShop.Models;
using CorePieShop.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePieShop.Controllers
{
    [Route("api/[controller]")]
    public class PieDataController : Controller
    {
        private readonly IPieRepository _pieRespository;

        public PieDataController(IPieRepository pieRepository)
        {
            _pieRespository = pieRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PieViewModel> LoadMorePies()
        {
            IEnumerable<Pie> dbPies = null;

            dbPies = _pieRespository.Pies.OrderBy(p => p.PieId).Take(10);

            List<PieViewModel> pies = new List<PieViewModel>();

            foreach(var dbPie in dbPies)
            {
                pies.Add(MapDbPieToPieViewModel(dbPie));
            }
            return pies;
        }

        private PieViewModel MapDbPieToPieViewModel(Pie dbPie)
        {
            return new ViewModels.PieViewModel()
            {
                PieId = dbPie.PieId,
                Name = dbPie.Name,
                Price = dbPie.Price,
                ShortDescription = dbPie.ShortDescription,
                ImageThumbnailUrl = dbPie.ImageThumbnailUrl
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
