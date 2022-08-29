using Microsoft.AspNetCore.Mvc;
using MyCar.Model;
using MyCar.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _carRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCars(int id)
        {
            return await _carRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> PostCars([FromBody]Car car)
        {
            var newCar = await _carRepository.Create(car);
            return CreatedAtAction(nameof(GetCars), new { id = newCar.Id }, newCar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carToDelete = await _carRepository.Get(id);
            if ( carToDelete == null)
                return NotFound();
            await _carRepository.Delete(carToDelete.Id);
            return NoContent(); 
        }

        [HttpPut]
        public async Task<ActionResult> PutCars(int id, [FromBody] Car car)
        {
            if (id != car.Id)
                return BadRequest();
            await _carRepository.Update(car);
            return NoContent();
        }
    }
}
