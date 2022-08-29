using MyCar.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> Get();
        Task<Car> Get(int Id);
        Task<Car> Create (Car car);
        Task Update(Car car);
        Task Delete(int Id);
    }
}
