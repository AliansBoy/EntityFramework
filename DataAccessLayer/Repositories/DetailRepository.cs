using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DetailRepository : IRepository<Detail>
    {
        private readonly CarContext _ctx;
        public DetailRepository()
        {
            _ctx = new CarContext();
        }
        public void Create(Detail model)
        {
            _ctx.Details.Add(model);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var DetailRemove = _ctx.Details.FirstOrDefault(x => x.Id == id);
            _ctx.Details.Remove(DetailRemove);
            _ctx.SaveChanges();
        }

        public Detail GetById(int id)
        {
            return _ctx.Details.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Detail> GetAll()
        {
            return _ctx.Details.AsNoTracking().ToList();
        }

        public void Update(Detail model)
        {
            var DetailUpdate = _ctx.Details.FirstOrDefault(x => x.Id == model.Id);

            DetailUpdate.Price = model.Price;
            DetailUpdate.ManufacturerId = model.ManufacturerId;
            DetailUpdate.TypeId = model.TypeId;
            DetailUpdate.CarId = model.CarId;

            _ctx.SaveChanges();
        }
    }
}
