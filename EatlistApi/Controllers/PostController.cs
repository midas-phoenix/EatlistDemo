﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatlistApi.Models;
using Microsoft.EntityFrameworkCore;
using EatListDataService.DataBase;
using EatListDataService.Repository;
using EatListDataService.DataTables;
using Microsoft.Extensions.Logging;
using EatlistApi.ViewsModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    //Pls, kindly change the TestController to BaseController for IDS
    public class PostController : Controller
    {
        //private static readonly ApplicationDbContext _post = new ApplicationDbContext();
        //private readonly PostRepository _postRepo = new PostRepository(_post);
        //readonly ILogger<PostController> _log;
        private Posts _Posts = new Posts();
        private PostsMedia _Media = new PostsMedia();
        public readonly PostRepository _postRepo = new PostRepository();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();

        //public string UserID
        //{
        //    get
        //    {
        //        return _userManager.GetUserId(User);
        //    }
        //    set { }

        //}

        //UserID will be changed
        //string UserID = "03503819-15ce-489c-946e-ff86a5324189";

        public PostController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: api/<controller>
        /// <summary>
        /// gets all posts.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("getviewablepost")]
        public async Task<ActionResult> GetViewable()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_postRepo.GetViewableForUser(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }

        }

        // GET api/<controller>/5
        /// <summary>
        /// gets a specific post by PostID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("getuserpost")]
        public async Task<ActionResult> Get()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_postRepo.GetAllbyUserID(userId.Id,userId.Id).ToList());
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }

        }

        // GET api/<controller>/5
        /// <summary>
        /// gets a specific post by PostID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("getpostsbyUserId")]
        public async Task<ActionResult> Get(string Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser userid = await GetCurrentUserAsync();
                    return Ok(_postRepo.GetAllbyUserID(Id,userid.Id).ToList());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        /// <summary>
        /// endpoint to create new posts
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]Post post)
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();//await _userManager.GetUserAsync(User);
                _log.LogInformation(userid.Id);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //_Posts = new Posts();
                _Posts.Caption = post.Caption;
                _Posts.DishID = post.DishID;
                _Posts.DateCreated = DateTime.UtcNow;
                _Posts.CreatedBy = userid.Id;
                _Posts.RestaurantID = post.RestaurantID;// UserID;
                var ret = _postRepo.Insert(_Posts);

                if (post.PostFiles != null)
                {
                    foreach (var file in post.PostFiles)
                    {
                        PostsMedia postEntity = new PostsMedia { FileType = file.FileType, FileURL = file.FileURL, PostID = ret.PostID };
                        _postRepo.Insert(postEntity);
                    }
                }

                return Ok(_postRepo.GetAllbyUserID(userid.Id, userid.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ModelState.ToString());
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        ///// <summary>
        ///// endpoint to update posts.
        ///// </summary>
        ///// <param name="update"></param>
        ///// <returns></returns>
        //[HttpPut, Route("update")]
        //public IActionResult Update(Update update)
        //{
        //    try
        //    {


        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        _Posts = new Posts();
        //        _Posts.PostID = update.PostID;
        //        _Posts.FileURL = update.FileURL;
        //        _Posts.FileType = update.FileType;

        //        _postRepo.Update(_Posts);
        //        var res = _postRepo.Update(_Posts);
        //        if (res.GetType() == typeof(KeyNotFoundException))
        //        {
        //            _log.LogInformation(res.ToString());
        //            return StatusCode(500);
        //        }
        //        return Ok(res);
        //        //return Ok(_postRepo.Update(_Posts));
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogInformation(ex.Message.ToString());
        //        return StatusCode(500);
        //    }
        //}

        // DELETE api/<controller>/5

        /// <summary>
        /// delete posts
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost, Route("comment")]
        public IActionResult comment(VM_Comment _vmComment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Comments _comment = new Comments();

                    _comment.Content = _vmComment.Content;
                    _comment.Image = _vmComment.Image;
                    _comment.PostID = _vmComment.PostID;

                    var res = _postRepo.CommentInsert(_comment);
                    if (res.GetType() == typeof(System.InvalidOperationException))
                    {
                        _log.LogInformation(res.ToString());
                        return StatusCode(500);
                    }
                    return Ok(_postRepo.FetchComments(_comment.PostID));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException);
                _log.LogInformation(" Ends here... ");

                return null;
            }

        }

        [HttpGet, Route("comment")]
        public IActionResult postComment(int PostID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var comments= _postRepo.FetchComments(PostID);
                    var res = _postRepo.FetchComments(PostID);
                    if (res.GetType() == typeof(System.InvalidOperationException) || res.GetType() == typeof(System.ArgumentNullException))
                    {
                        _log.LogInformation("Exception thrown from comments");
                        return StatusCode(500);
                    }
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException);
                // _log.LogInformation(" Ends here... ");

                return null;
            }

        }

        [HttpPost, Route("like")]
        public async Task<IActionResult> LikePost(int PostID)
        {
            try
            {
                dynamic res="";
                ApplicationUser userid = await GetCurrentUserAsync();
                Posts _postObject = _postRepo.Get(Convert.ToInt32(PostID));
                if (_postObject != null)
                {
                    if (!_postRepo.LikeExist(_postObject.PostID, userid.Id))
                    {
                        Likes _likes = new Likes();
                        _likes.PostID = PostID;
                        _likes.CreatedBy = userid.Id;
                        _likes.DateCreated = DateTime.UtcNow.Date;
                        //_likes.IsLiked = !_likes.IsLiked;
                        //success insert
                        res = _postRepo.LikeInsert(_likes);
                        if (res.GetType() == typeof(System.InvalidOperationException) || res.GetType() == typeof(System.ArgumentNullException))
                        {
                            _log.LogInformation((string)res);
                            return StatusCode(500);
                        }
                        return Ok(res);
                    }
                    else if(!_postRepo.LikeDelete(_postObject.PostID, userid.Id))
                    {
                        return StatusCode(500, "Operation could not be completed");
                    }
                    //success delete
                    return Ok(_postRepo.Get(PostID));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException);
                _log.LogInformation(" Ends here... ");

                return null;
            }
        }

        [HttpGet, Route("like")]
        public IActionResult postLikes(int PostID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var comments= _postRepo.FetchComments(PostID);
                    var res = _postRepo.FetchLikes(PostID);
                    if (res.GetType() == typeof(System.InvalidOperationException) || res.GetType() == typeof(System.ArgumentNullException))
                    {
                        _log.LogInformation("Exception thrown from comments");
                        return StatusCode(500);
                    }
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException);
                // _log.LogInformation(" Ends here... ");

                return null;
            }

        }

    }
}
