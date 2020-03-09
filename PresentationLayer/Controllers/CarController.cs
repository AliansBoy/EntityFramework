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
    public class CarController : IController<CarViewModel>
    {
        private readonly CarService carService;

        public CarController()
        {
            carService = new CarService();
        }
        public void Create(CarViewModel model)
        {
            var carModel = new CarModel
            {
                Model = model.Model,
                ManufacturerId = model.ManufacturerId,
                Details = model.Details?.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            carService.Create(carModel);
        }

        public void Delete(int id)
        {
            carService.Delete(id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            var cars = carService.GetAll();
            var carViewModels = cars.Select(x => new CarViewModel
            {
                Model = x.Model,
                ManufacturerId = x.ManufacturerId,
                Details = x.Details.Select(y => new DetailViewModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList()
            });
            return carViewModels;

        }

        public CarViewModel GetById(int id)
        {
            var car = carService.GetById(id);
            var carViewModel = new CarViewModel
            {
                Model = car.Model,
                ManufacturerId = car.ManufacturerId,
                Details = car.Details.Select(x => new DetailViewModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            return carViewModel;
        }

        public void Update(CarViewModel model)
        {
            var carModel = new CarModel()
            {
                Model = model.Model,
                ManufacturerId = model.ManufacturerId
            };
            carService.Update(carModel);

        }
    }
}
