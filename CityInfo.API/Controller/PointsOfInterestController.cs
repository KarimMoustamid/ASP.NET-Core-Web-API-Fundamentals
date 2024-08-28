namespace CityInfo.API.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return this.NotFound();
            }

            return this.Ok(city.PointsOfIntrest);
        }

        [HttpGet("{pointofintrestid}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterestById(int cityId, int pointofintrestid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return this.NotFound();
            }


            var pointofintrest = city.PointsOfIntrest.FirstOrDefault(p => p.Id == pointofintrestid);

            if (pointofintrest == null)
            {
                return this.NotFound();
            }

            return this.Ok(pointofintrest);
        }
    }
}