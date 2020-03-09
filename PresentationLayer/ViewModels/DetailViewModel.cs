using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class DetailViewModel
    {
        public int Price { get; set; }

        public int TypeId { get; set; }
        public DetailTypeViewModel Type { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }

        public int CarId { get; set; }
        public CarViewModel Car { get; set; }
    }
}
