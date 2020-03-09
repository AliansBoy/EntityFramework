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
    public class ManufacturerController : IController<ManufacturerViewModel>
    {
        private readonly ManufacturerService manufacturerService;

        public ManufacturerController()
        {
            manufacturerService = new ManufacturerService();
        }
        public void Create(ManufacturerViewModel model)
        {
            var manufacturerModel = new ManufacturerModel
            {
                Name = model.Name,
                Details = model.Details.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList(),
                Cars = model.Cars.Select(x => new CarModel
                {
                    Model = x.Model,
                    ManufacturerId = x.ManufacturerId
                }).ToList()
            };
            manufacturerService.Create(manufacturerModel);
        }

        public void Delete(int id)
        {
            manufacturerService.Delete(id);
        }

        public IEnumerable<ManufacturerViewModel> GetAll()
        {
            var manufacturers = manufacturerService.GetAll();
            var manufactererViewModels = manufacturers.Select(x => new ManufacturerViewModel
            {
                Name = x.Name,
                Details = x.Details.Select(y => new DetailViewModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList(),
                Cars = x.Cars.Select(y => new CarViewModel
                {
                    Model = y.Model,
                    ManufacturerId = y.ManufacturerId
                }).ToList()
            });
            return manufactererViewModels;
        }

        public ManufacturerViewModel GetById(int id)
        {
            var manufacturer = manufacturerService.GetById(id);
            var manufactererViewModel = new ManufacturerViewModel
            {
                Name = manufacturer.Name,
                Details = manufacturer.Details.Select(x => new DetailViewModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList(),
                Cars = manufacturer.Cars.Select(x => new CarViewModel
                {
                    Model = x.Model,
                    ManufacturerId = x.ManufacturerId
                }).ToList()
            };
            return manufactererViewModel;
        }

        public void Update(ManufacturerViewModel model)
        {
            var manufacturerModel = new ManufacturerModel
            {
                Name = model.Name
            };
            manufacturerService.Update(manufacturerModel);
        }
    }
}
