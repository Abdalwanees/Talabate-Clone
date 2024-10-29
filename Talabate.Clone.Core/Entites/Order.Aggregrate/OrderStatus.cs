using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabate.Clone.Core.Entites.Order.Aggregrate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "paymentSucceded")]
        paymentSucceded,
        [EnumMember(Value = "paymentFailed")]
        paymentFailed,
    }
}
