namespace CityInfo.API.Controller
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

    }
}