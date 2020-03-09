using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DetailType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
