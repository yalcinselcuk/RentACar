using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity<TId>//TId önemsiz, gönderilen tipi tutuyor
    {
        public TId ID{ get; set; }

        public DateTime? CreatedDate{ get; set; }//ilk başta girilmek zorunda olmadığından '?' => nullable olarak tanımladık

        public DateTime? UpdatedDate { get; set;}
        
        public DateTime? DeletedDate { get; set; }// soft delete

        public Entity()
        {
            ID = default; //hiçbir şey girilmezse bu id'nin default'u neyse o atansın. örn : int ise default değeri 0 gibi     
        }

        public Entity(TId id)
        {
            ID = id;
        }
    }
}
