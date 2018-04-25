using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IOrderRepository: IRepository<Orders>
    {
        dynamic GetAllByUserID(string UserID, bool Restaurant);
    }

    public interface IOrderDishRepository : IRepository<OrderDish>
    {
        //dynamic GetAllByUserID(string UserID, bool Restaurant);
    }
}
