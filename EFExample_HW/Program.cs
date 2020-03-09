using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var manufactureService = new ManufacturerService();
            var mostExpensiveCar = manufactureService.GetMostExpensiveCar();

            foreach (var x in mostExpensiveCar)
            {
                Console.WriteLine($"{x.Manufacturer.Name} , {x.MostExpensiveCar.Model}");
            }


            Console.ReadKey();

        }
    }
}
