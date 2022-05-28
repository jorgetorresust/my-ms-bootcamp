
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public  class LocationService: ILocationService
    {
        ILocationData _LocationData;
        public LocationService(ILocationData locationDL)
        {
            _LocationData = locationDL;
        }
       public async Task<List<Location>> getLocationsBYPatientaId(String PatientaId) {
         return  await _LocationData.getLocationsBYPatientaId(PatientaId);
        }
        public async Task<List<Location>> getLocations() {
            return await _LocationData.getLocations();

        }

        public async Task<List<Location>> getLocationByCity(String city) {
           return  await _LocationData.getLocationByCity(city);
        }
        public async Task<Location> postLocation(Location location) {
            return await _LocationData.postLocation(location);
        }
    }

}
