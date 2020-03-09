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
    public class DetailController : IController<DetailViewModel>
    {
        private readonly DetailService detailService;

        public DetailController()
        {
            detailService = new DetailService();
        }
        public void Create(DetailViewModel model)
        {
            var detailModel = new DetailModel
            {
                Price = model.Price,
                CarId = model.CarId,
                ManufacturerId = model.ManufacturerId,
                TypeId = model.TypeId
            };
            detailService.Create(detailModel);
        }

        public void Delete(int id)
        {
            detailService.Delete(id);
        }

        public IEnumerable<DetailViewModel> GetAll()
        {
            var details = detailService.GetAll();
            var detailViewModels = details.Select(x => new DetailViewModel
            {
                Price = x.Price,
                CarId = x.CarId,
                ManufacturerId = x.ManufacturerId,
                TypeId = x.TypeId
            });
            return detailViewModels;
        }

        public DetailViewModel GetById(int id)
        {
            var detail = detailService.GetById(id);
            var detailViewModel = new DetailViewModel
            {
                Price = detail.Price,
                CarId = detail.CarId,
                ManufacturerId = detail.ManufacturerId,
                TypeId = detail.TypeId
            };
            return detailViewModel;
        }

        public void Update(DetailViewModel model)
        {
            var detailModel = new DetailModel
            {
                Price = model.Price,
                CarId = model.CarId,
                ManufacturerId = model.ManufacturerId,
                TypeId = model.TypeId
            };
            detailService.Update(detailModel);
        }
    }
}
