using Microsoft.EntityFrameworkCore;
using MyCar.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MyCar.Repositories
{
    public class CarRepository : ICarRepository
    {
        public readonly CarContext _context;

        public CarRepository(CarContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task Delete(int id)
        {
            var carToDelete = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Car>> Get()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> Get(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }

}

