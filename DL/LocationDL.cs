using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Text.Json;

namespace DL
{
    public class LocationDL:ILocationDL
    {
        //FileStream fs;
        public LocationDL()
        {
          if (!File.Exists("C:\\Users\\user\\source\\Repos\\nessi0527\\repositories\\locations2.JSON")) {
               var fs= File.CreateText("C:\\Users\\user\\source\\Repos\\nessi0527\\repositories\\locations2.JSON");
                fs.Close();
            } 
        }
        public async Task<List<Location>> getLocationsByPatientId(String patientId)
        {

            List<Location> locations =  JsonSerializer.Deserialize<List<Location>>(await File.ReadAllTextAsync("C:\\Users\\me\\Documents\\נסי\\Microsoft-Bootcamp\\locations.JSON"));
            var l= locations.FindAll(loc => loc.PatientId == patientId);
            return l;
        }
        public async Task<List<Location>> getAllLocations()
        {
            return JsonSerializer.Deserialize<List<Location>>(await File.ReadAllTextAsync("C:\\Users\\me\\Documents\\נסי\\Microsoft-Bootcamp\\locations.JSON"));
        }
        public async Task<List<Location>> getLocationsByCity(String city)
        {
            List<Location> locations = JsonSerializer.Deserialize<List<Location>>(await File.ReadAllTextAsync("C:\\Users\\me\\Documents\\נסי\\Microsoft-Bootcamp\\locations.JSON"));
            return locations.FindAll(loc => loc.City == city);
        }
        public async Task<Location> addNewLocation(Location location)
        {
            string file = await File.ReadAllTextAsync("C:\\Users\\me\\Documents\\נסי\\Microsoft-Bootcamp\\locations.JSON");
            String jsonLocation;
            List<Location> locations;
            if (file != "")
            {
                locations = JsonSerializer.Deserialize<List<Location>>(file);
                locations.Add(location);

            }
            else
            {
                locations = new List<Location> { location };


            }
            jsonLocation = JsonSerializer.Serialize(locations);

            await File.WriteAllTextAsync("C:\\Users\\me\\Documents\\נסי\\Microsoft-Bootcamp\\locations.JSON", jsonLocation);
            return location;
        }
    }
}
