using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IDishRepository: IRepository<Dishes>
    {
        dynamic GetDishByUserID(string UserID);

        dynamic GetDishByID(int Id);


    }
    public interface IDishMediaRepository : IRepository<DishMedia>
    {
        IEnumerable<DishMedia> GetMediaByDishID(int dishId);

    }
}
