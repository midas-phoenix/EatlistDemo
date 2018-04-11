using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IPostRepository: IRepository<Posts>
    {
        dynamic GetViewableForUser(string UserID);
        void NewPost(Posts post, PostsMedia pm);
        dynamic GetPostmedia(long id, string CUser);
    }

    public interface ICommentRepository : IRepository<Comments>
    {
        dynamic FetchComment(int PostID);


    }
}
