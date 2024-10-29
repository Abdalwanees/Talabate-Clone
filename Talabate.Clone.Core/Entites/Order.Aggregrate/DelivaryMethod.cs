using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites.Order.Aggregrate
{
    public class DelivaryMethod:BaseEntity
    {
        public DelivaryMethod(string shortName, string description, string delivaryTime, decimal cost)
        {
            ShortName = shortName;
            Description = description;
            DeliveryTime = delivaryTime;
            Cost = cost;
        }
        public DelivaryMethod()
        {
            
        }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Cost { get; set; }
    }
}
