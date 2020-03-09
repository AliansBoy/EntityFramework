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
    public class CarService : IService<CarModel>
    {
        private readonly CarRepository carRepository;

        public CarService()
        {
            carRepository = new CarRepository();
        }
        public void Create(CarModel model)
        {
            var car = new Car
            {
                Model = model.Model,
                ManufacturerId = model.ManufacturerId,
                Details = model.Details?.Select(x => new Detail
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            carRepository.Create(car);
        }

        public void Delete(int id)
        {
            carRepository.Delete(id);
        }

        public IEnumerable<CarModel> GetAll()
        {
            var cars = carRepository.GetAll();
            var carModels = cars.Select(x => new CarModel
            {
                Model = x.Model,
                ManufacturerId = x.ManufacturerId,
                Details = x.Details.Select(y => new DetailModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList()
            });

            return carModels;
        }

        public CarModel GetById(int id)
        {
            var car = carRepository.GetById(id);
            var carModel = new CarModel
            {
                Model = car.Model,
                ManufacturerId = car.ManufacturerId,
                Details = car.Details.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList()
            };
            return carModel;
        }

        public void Update(CarModel model)
        {
            var car = new Car()
            {
                Model = model.Model,
                ManufacturerId = model.ManufacturerId
            };
            carRepository.Update(car);
        }

    }
}
