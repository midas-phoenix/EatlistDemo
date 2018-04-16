using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IPostRepository: IRepository<Posts>
    {

        //dynamic GetViewableForUser(string UserID);
        Posts NewPost(Posts post);
        dynamic UserPosts(string userid, bool allpost, string CUser);
        dynamic GetPostByID(long id, string CUser);
        List<PostsMedia> UploadPostMedia(PostsMedia[] medias);
    }

    public interface ICommentRepository : IRepository<Comments>
    {
        dynamic FetchComment(int PostID);


    }
}
