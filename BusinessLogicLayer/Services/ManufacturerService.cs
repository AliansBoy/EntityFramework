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
    public class ManufacturerService : IService<ManufacturerModel>
    {
        private readonly ManufacturerRepository manufacturerRepository;

        public ManufacturerService()
        {
            manufacturerRepository = new ManufacturerRepository();
        }
        public void Create(ManufacturerModel model)
        {
            var manufacturer = new Manufacturer
            {
                Name = model.Name,
                Details = model.Details.Select(x => new Detail
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList(),
                Cars = model.Cars.Select(x => new Car
                {
                    Model = x.Model,
                    ManufacturerId = x.ManufacturerId
                }).ToList()
            };
            manufacturerRepository.Create(manufacturer);
        }

        public void Delete(int id)
        {
            manufacturerRepository.Delete(id);
        }

        public IEnumerable<ManufacturerModel> GetAll()
        {
            var manufacturers = manufacturerRepository.GetAll();
            var manufactererModels = manufacturers.Select(x => new ManufacturerModel
            {
                Name = x.Name,
                Details = x.Details.Select(y => new DetailModel
                {
                    Price = y.Price,
                    CarId = y.CarId,
                    ManufacturerId = y.ManufacturerId,
                    TypeId = y.TypeId
                }).ToList(),
                Cars = x.Cars.Select(y => new CarModel
                {
                    Model = y.Model,
                    ManufacturerId = y.ManufacturerId
                }).ToList()
            });
            return manufactererModels;
        }

        public ManufacturerModel GetById(int id)
        {
            var manufacturer = manufacturerRepository.GetById(id);
            var manufactererModel = new ManufacturerModel
            {
                Name = manufacturer.Name,
                Details = manufacturer.Details.Select(x => new DetailModel
                {
                    Price = x.Price,
                    CarId = x.CarId,
                    ManufacturerId = x.ManufacturerId,
                    TypeId = x.TypeId
                }).ToList(),
                Cars = manufacturer.Cars.Select(x => new CarModel
                {
                    Model = x.Model,
                    ManufacturerId = x.ManufacturerId
                }).ToList()
            };
            return manufactererModel;
        }

        public void Update(ManufacturerModel model)
        {
            var manufacturer = new Manufacturer
            {
                Name = model.Name
            };
            manufacturerRepository.Update(manufacturer);
        }

        public IEnumerable<CarManufacturerModel> GetMostExpensiveCar()
        {
            var mostExpensiveCar = manufacturerRepository.GetAll();

            var result = mostExpensiveCar.Select(x =>
            {
                var temp = x.Cars.OrderByDescending(y => y.Details.Sum(z => z.Price)).FirstOrDefault();
                var manufacturerCar = new CarManufacturerModel
                {
                    Manufacturer = new ManufacturerModel
                    {
                        Name = x.Name
                    },
                    MostExpensiveCar = new CarModel
                    {
                        Model = temp.Model,
                        ManufacturerId = temp.ManufacturerId
                    }
                };
                return manufacturerCar;
            }).ToList();

            return result;
        }
    }
}
