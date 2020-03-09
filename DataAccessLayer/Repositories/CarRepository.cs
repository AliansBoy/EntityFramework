using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly CarContext _ctx;
        public CarRepository()
        {
            _ctx = new CarContext();
        }
        public void Create(Car model)
        {
            _ctx.Cars.Add(model);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var CarRemove = _ctx.Cars.FirstOrDefault(x => x.Id == id);
            _ctx.Cars.Remove(CarRemove);
            _ctx.SaveChanges();
        }

        public Car GetById(int id)
        {
            return _ctx.Cars.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _ctx.Cars.AsNoTracking().ToList();
        }

        public void Update(Car model)
        {
            var CarUpdate = _ctx.Cars.FirstOrDefault(x => x.Id == model.Id);

            CarUpdate.Model = model.Model;
            CarUpdate.ManufacturerId = model.ManufacturerId;

            _ctx.SaveChanges();
        }
    }
}
