namespace CityInfo.API.Controller
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CitiesController : ControllerBase
    {
        public JsonResult GetCities()
        {
            var cities = new List<object>
            {
                new {Id = 1, Name = "New York City", Description = "The one with that big park."},
                new {Id = 2, Name = "Antwerp", Description = "The one with the cathedral that was never really finished."},
                new {Id = 3, Name = "Paris", Description = "The one with that big tower."}
            };

            return new JsonResult(cities);
        }
    }
}