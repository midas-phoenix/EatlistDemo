using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class Enums
    {
    }

    public enum OrderStatus { CreateOrder= 0, ApproveOrder= 1, CancelOrder= 2, RejectOrder = 3};
    public enum MediaType { Image = 0, Audio = 1, Video = 2 };
}
