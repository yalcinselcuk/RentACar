using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Brand
    {
        public int ID { get; set; }

        public string NAME { get; set; }

        public bool IS_DELETED { get; set; }
    }
}
