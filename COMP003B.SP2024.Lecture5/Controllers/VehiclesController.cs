// TODO: add models reference
using COMP003B.SP2024.Lecture5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.SP2024.Lecture5.Controllers
{
    // api/Vehicles
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        // TODO: create an in-memory list of vehicles
        private List<Vehicle> _vehicles = new List<Vehicle>();

        // TODO: add default contstructor to pre-fill
        public VehiclesController() {             
            _vehicles.Add(new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2018 });
            _vehicles.Add(new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 });
            _vehicles.Add(new Vehicle { Id = 3, Make = "Ford", Model = "Fusion", Year = 2020 });
            _vehicles.Add(new Vehicle { Id = 4, Make = "Ford", Model = "Mustang", Year = 2016 });
        }

        // TODO: create CRUD operations

        // TODO: GET ALL (Read): api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return _vehicles;
        }

        // TODO: GET by id (Read): api/Vehicles/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id)
        {
            // TODO: find vehicle by id
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);

            // TODO: return 404 if not found
            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // TODO: POST (Create): api/Vehicles
        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            // TODO: automaticcaly assign id
            vehicle.Id = _vehicles.Max(v => v.Id) + 1;

            // TODO: add it to the list
            _vehicles.Add(vehicle);

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        // TODO: PUT (Update): api/Vehicles/5
        [HttpPut]
        public ActionResult<Vehicle> UpdateVehicle(int id, Vehicle updatedVehicle)
        { 
            // TODO: look for the vehicle by id
            var vehicle = _vehicles.Find(v => v.Id == id);

            // TODO: return BadRequest if not found
            if (vehicle == null)
            {
                return BadRequest();
            }

            // TODO: update the vehicle
            vehicle.Make = updatedVehicle.Make;
            vehicle.Model = updatedVehicle.Model;
            vehicle.Year = updatedVehicle.Year;

            return NoContent();
        }

        // TODO: DELETE (Delete): api/Vehicles/5
        [HttpDelete]
        public ActionResult DeleteVehicle(int id)
        {
            // TODO: find the vehicle by id
            var vehicle = _vehicles.Find(v => v.Id == id);

            // TODO: return NotFound if not found
            if (vehicle == null)
            {
                return NotFound();
            }

            // TODO: remove from the list
            _vehicles.Remove(vehicle);

            return NoContent();

        }

    }
}
