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
    public class DetailTypeService : IService<DetailTypeModel>
    {
        private readonly DetailTypeRepository detailTypeRepository;

        public DetailTypeService()
        {
            detailTypeRepository = new DetailTypeRepository();
        }
        public void Create(DetailTypeModel model)
        {
            var detailType = new DetailType
            {
                Type = model.Type,
                Details = model.Details?.Select(x => new Detail
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId

                }).ToList()
            };
            detailTypeRepository.Create(detailType);
        }

        public void Delete(int id)
        {
            detailTypeRepository.Delete(id);
        }

        public IEnumerable<DetailTypeModel> GetAll()
        {
            var types = detailTypeRepository.GetAll();
            var detailTypeModels = types.Select(x => new DetailTypeModel
            {
                Type = x.Type,
                Details = x.Details?.Select(y => new DetailModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList()
            });
            return detailTypeModels;
        }

        public DetailTypeModel GetById(int id)
        {
            var type = detailTypeRepository.GetById(id);
            var detailTypeModel = new DetailTypeModel
            {
                Type = type.Type,
                Details = type.Details?.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            return detailTypeModel;
        }

        public void Update(DetailTypeModel model)
        {
            var detailType = new DetailType
            {
                Type = model.Type
            };
            detailTypeRepository.Update(detailType);
        }
    }
}
