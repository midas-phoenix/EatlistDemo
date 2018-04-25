using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IEatListRepository: IRepository<TodoDishes>
    {
        dynamic GetUserDishList(string UserID);

        TodoDishes EatlistExist(string UserId, int DishId);

        dynamic GetEatList(int ID);
    }
}
