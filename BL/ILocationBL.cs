using Entities;

namespace BL
{
    public interface ILocationBL
    {
        Task<List<Location>> getLocationsByPatientId(String patientId);
        Task<List<Location>> getAllLocations();
        Task<List<Location>> getLocationsByCity(String city);
        Task<Location> addNewLocation(Location location);
    }
}