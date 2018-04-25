using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IPostRepository: IRepository<Posts>
    {

        //dynamic GetViewableForUser(string UserID);
        dynamic UserPosts(string userid, bool allpost, string CUser);
        dynamic GetPostByID(long id, string CUser);
        List<PostsMedia> UploadPostMedia(PostsMedia[] medias);
    }

    public interface ICommentRepository : IRepository<Comments>
    {
        dynamic FetchComment(int PostID);
    }

    public interface ILikesRepository: IRepository<Likes>
    {
        dynamic FetchLikes(long PostID);
        bool LikeExist(int PostID, string UserID);
        Likes UserPostLike(int PostID, string UserID);
    }
}
