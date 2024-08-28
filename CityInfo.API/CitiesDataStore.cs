namespace CityInfo.API
{
    using Models;

    public class CitiesDataStore
    {
        public List<CityDto> Cites { get; set; } = new List<CityDto>
        {
            new CityDto {Id = 1, Name = "New York", Description = "The one with that big park."},
            new CityDto {Id = 2, Name = "Antwerp", Description = "The one with the cathedral that was never really finished."},
            new CityDto {Id = 3, Name = "Paris", Description = "The one with that big tower."}
        };
    }
}