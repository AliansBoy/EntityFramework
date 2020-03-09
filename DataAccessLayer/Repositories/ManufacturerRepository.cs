using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private readonly CarContext _ctx;
        public ManufacturerRepository()
        {
            _ctx = new CarContext();
        }
        public void Create(Manufacturer model)
        {
            _ctx.Manufacturers.Add(model);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var ManufacturerRemove = _ctx.Manufacturers.FirstOrDefault(x => x.Id == id);
            _ctx.Manufacturers.Remove(ManufacturerRemove);
            _ctx.SaveChanges();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _ctx.Manufacturers
                .Include(x => x.Cars.Select(y => y.Details))
                .Include(x => x.Details)
                .AsNoTracking()
                .ToList();
        }

        public Manufacturer GetById(int id)
        {
            return _ctx.Manufacturers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Manufacturer model)
        {
            var ManufacturerUpdate = _ctx.Manufacturers.FirstOrDefault(x => x.Id == model.Id);

            ManufacturerUpdate.Name = model.Name;

            _ctx.SaveChanges();
        }
    }
}
