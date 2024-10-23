using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites.Busket
{
    public class CustomerBasket
    {

        public CustomerBasket(string id)
        {
            Id = id;
            Items =  new List<BasketItem>();
        }

        public string Id { get; set; }
        public List<BasketItem>  Items{ get; set; }
    }
}
