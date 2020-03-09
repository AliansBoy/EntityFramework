using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DetailTypeRepository : IRepository<DetailType>
    {
        private readonly CarContext _ctx;
        public DetailTypeRepository()
        {
            _ctx = new CarContext();
        }
        public void Create(DetailType model)
        {
            _ctx.Types.Add(model);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var TypeRemove = _ctx.Types.FirstOrDefault(x => x.Id == id);
            _ctx.Types.Remove(TypeRemove);
            _ctx.SaveChanges();
        }

        public IEnumerable<DetailType> GetAll()
        {
            return _ctx.Types.AsNoTracking().ToList();
        }

        public DetailType GetById(int id)
        {
            return _ctx.Types.FirstOrDefault(x => x.Id == id);
        }

        public void Update(DetailType model)
        {
            var TypeUpdate = _ctx.Types.FirstOrDefault(x => x.Id == model.Id);

            TypeUpdate.Type = model.Type;

            _ctx.SaveChanges();
        }
    }
}
