namespace CityInfo.API
{
    using Models;

    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore(); // singleton pattern

        public List<CityDto> Cities { get; set; } = new List<CityDto>
        {
            new CityDto
            {
                Id = 1,
                Name = "New York",
                Description = "The one with that big park.",
                PointsOfIntrest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto {Id = 1, Name = "Central Park", Description = "Large city park"},
                    new PointOfInterestDto {Id = 2, Name = "Statue of Liberty", Description = "Historical Monument"}
                }
            },
            new CityDto
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished.",
                PointsOfIntrest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto {Id = 1, Name = "Cathedral of Our Lady", Description = "Gothic Cathedral"}
                }
            },
            new CityDto
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower.",
                PointsOfIntrest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto {Id = 1, Name = "Eiffel Tower", Description = "Wrought-iron lattice tower"},
                    new PointOfInterestDto {Id = 2, Name = "Louvre Museum", Description = "World's largest art museum"}
                }
            }
        };
    }
}