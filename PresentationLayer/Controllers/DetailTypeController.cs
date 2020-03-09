using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class DetailTypeController : IController<DetailTypeViewModel>
    {
        private readonly DetailTypeService detailTypeService;

        public DetailTypeController()
        {
            detailTypeService = new DetailTypeService();
        }
        public void Create(DetailTypeViewModel model)
        {
            var detailTypeModel = new DetailTypeModel
            {
                Type = model.Type,
                Details = model.Details?.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId

                }).ToList()
            };
            detailTypeService.Create(detailTypeModel);
        }

        public void Delete(int id)
        {
            detailTypeService.Delete(id);
        }

        public IEnumerable<DetailTypeViewModel> GetAll()
        {
            var types = detailTypeService.GetAll();
            var detailTypeViewModels = types.Select(x => new DetailTypeViewModel
            {
                Type = x.Type,
                Details = x.Details?.Select(y => new DetailViewModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList()
            });
            return detailTypeViewModels;
        }

        public DetailTypeViewModel GetById(int id)
        {
            var type = detailTypeService.GetById(id);
            var detailTypeViewModel = new DetailTypeViewModel
            {
                Type = type.Type,
                Details = type.Details?.Select(x => new DetailViewModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            return detailTypeViewModel;
        }

        public void Update(DetailTypeViewModel model)
        {
            var detailTypeModel = new DetailTypeModel
            {
                Type = model.Type
            };
            detailTypeService.Update(detailTypeModel);
        }
    }
}
