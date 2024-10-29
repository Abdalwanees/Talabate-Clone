using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.Core.Specifications.OrderSpecifications
{
    public class OrderSpecification :BaseSpecifications<Order>
    {
        public OrderSpecification(string buyerEmail):base(O=>O.BuyerEmail==buyerEmail)
        {
            Includes.Add(O => O.Delivarymethod);
            Includes.Add(O => O.Items);
            AddOrderBy(O => O.OrderBata);
        }
        public OrderSpecification(int orderId,string buyerEmail):base(O=>O.Id==orderId &&O.BuyerEmail==buyerEmail)
        {
            Includes.Add(O => O.Delivarymethod);
            Includes.Add(O => O.Items);
        }
    }
}
