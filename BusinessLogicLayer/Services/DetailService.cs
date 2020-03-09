using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DetailService : IService<DetailModel>
    {
        private readonly DetailRepository detailRepository;

        public DetailService()
        {
            detailRepository = new DetailRepository();
        }
        public void Create(DetailModel model)
        {
            var detail = new Detail
            {
                Price = model.Price,
                CarId = model.CarId,
                ManufacturerId = model.ManufacturerId,
                TypeId = model.TypeId
            };
            detailRepository.Create(detail);
        }

        public void Delete(int id)
        {
            detailRepository.Delete(id);
        }

        public IEnumerable<DetailModel> GetAll()
        {
            var details = detailRepository.GetAll();
            var detailModels = details.Select(x => new DetailModel
            {
                Price = x.Price,
                CarId = x.CarId,
                ManufacturerId = x.ManufacturerId,
                TypeId = x.TypeId
            });
            return detailModels;
        }

        public DetailModel GetById(int id)
        {
            var detail = detailRepository.GetById(id);
            var detailModel = new DetailModel
            {
                Price = detail.Price,
                CarId = detail.CarId,
                ManufacturerId = detail.ManufacturerId,
                TypeId = detail.TypeId
            };
            return detailModel;
        }

        public void Update(DetailModel model)
        {
            var detail = new Detail
            {
                Price = model.Price,
                CarId = model.CarId,
                ManufacturerId = model.ManufacturerId,
                TypeId = model.TypeId
            };
            detailRepository.Update(detail);
        }
    }
}
