using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class UserInfo
    {
        public string ConnectionId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string RestaurantName { get; set; }

        public bool IsRestaurant { get; set; }

        public string Profilepic { get; set; }
    }
}
