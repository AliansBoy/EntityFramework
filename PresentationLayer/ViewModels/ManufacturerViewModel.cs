using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ManufacturerViewModel
    {
        public string Name { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
        public IEnumerable<DetailViewModel> Details { get; set; }
    }
}
