
namespace Services
{
    public interface ILocationService
    {
        Task<List<Location>> getLocationsBYPatientaId(String PatientaId);
        Task<List<Location>> getLocations();

        Task<List<Location>> getLocationByCity(String city);
        Task<Location> postLocation(Location location);
    }
}