using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace boot_camp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        Serilog.Core.Logger log;
        ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
            log = new LoggerConfiguration()
                 .WriteTo.File("C:\\Users\\user\\source\\Repos\\nessi0527\\logs\\log.txt")
                 .CreateLogger();
            
        }
        // GET: api/<PatientController>
        [HttpGet("all")]
        public async Task<List<Location>> Get()
        {
            try
            {
                return await _locationService.getLocations();
            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace);
                return new List<Location>();
            }
           
        }


        [HttpGet ]
        public async Task<List<Location>> GetByCity([FromQuery] string city)
        {
            
            return await _locationService.getLocationByCity(city);
        }
        // GET api/<PatientController>/5
        [HttpGet("{patientid}")]
        public async Task<List<Location>> Get(string patientid)
        {
            return await _locationService.getLocationsBYPatientaId(patientid);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<Location> Post([FromBody] Location location)
        {
            return await _locationService.postLocation(location);
        }


    }
}