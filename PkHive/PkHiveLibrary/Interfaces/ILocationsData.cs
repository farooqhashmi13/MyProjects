using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface ILocationsData
    {
        Task<int> AddLocation(Location location);
        Task<List<Location>> GetLocations();
        Task<Location> GetLocationById(int Id);
        Task<int> UpdateLocation(Location location);
    }
}