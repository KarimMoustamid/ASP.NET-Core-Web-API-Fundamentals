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

        [HttpGet("{pointofintrestid}", Name = "GetPointOfInterest")]
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

        [HttpPost]
        public ActionResult<PointOfInterestDto> createPointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterestForCreation)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return this.NotFound();
            }

            // demo purposes - to be improved :
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany( c=> c.PointsOfIntrest).Max( p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto
            {
                Id = maxPointOfInterestId++,
                Name = pointOfInterestForCreation.Name,
                Description = pointOfInterestForCreation.Description
            };


            return this.CreatedAtRoute("GetPointOfInterest", new {
                cityId = cityId,
                pointofintrestid = finalPointOfInterest.Id
            },
            finalPointOfInterest);


        }
    }
}