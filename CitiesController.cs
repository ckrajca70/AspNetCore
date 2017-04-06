using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]//[Route("api/[controller]")] --more suited for web sites vs APIs
    public class CitiesController : Controller
    {
        //[HttpGet()]//routing info
        //public JsonResult GetCities()
        //{
        //    //return new JsonResult(new List<object>()
        //    //{
        //    //    new {id=1,Name="New York City"},
        //    //    new {id=2,Name = "Antwerp"}
        //    //});

        //    //replaced above using Current City Store
        //    return new JsonResult(CitiesDataStore.Current.Cities); 
        //}

        //[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == id));
        //}

        //mod to use IActionResult instead of JsonResult
        [HttpGet()]//routing info
        public IActionResult GetCities()
        {
            //return new JsonResult(new List<object>()
            //{
            //    new {id=1,Name="New York City"},
            //    new {id=2,Name = "Antwerp"}
            //});

            //replaced above using Current City Store
            return Ok(CitiesDataStore.Current.Cities);//NotFound not needed becauseempty list is ok
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            //Find City with passed in Id
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }

    }
}
