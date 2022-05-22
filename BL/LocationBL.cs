using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LocationBL: ILocationBL
    {
        ILocationDL _ILocationDL;
        public LocationBL(ILocationDL ILocationDL)
        {
            _ILocationDL = ILocationDL;
        }
        public async Task<List<Location>> getLocationsByPatientId(String patientId)
        {
           return await _ILocationDL.getLocationsByPatientId(patientId);
        }
        public async Task<List<Location>> getAllLocations()
        {
           return  await _ILocationDL.getAllLocations();
        }
        public async Task<List<Location>> getLocationsByCity(String city)
        {
            return await _ILocationDL.getLocationsByCity(city);
        }
        public async Task<Location> addNewLocation(Location location)
        {
            return await _ILocationDL.addNewLocation(location);
        }
    }
}
