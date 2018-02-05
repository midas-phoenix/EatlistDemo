using EatlistApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.Interface
{
    public interface IPostRepository
    {
        void Add(Post p);
        void Edit(Post p);
        void Remove(int Id);
        IEnumerable GetPosts(); Post FindById(int Id);
    }
} 
    

