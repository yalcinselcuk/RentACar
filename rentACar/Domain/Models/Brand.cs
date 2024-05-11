using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Brand : Entity<Guid>// Guid : ezmeyi önlemek amaçlı
    {

        public string NAME { get; set; }

        public Brand()
        {

        }

        public Brand(Guid id, string name)
        {
            ID= id;
            NAME = name;
        }
    }
}
