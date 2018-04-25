using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatlistApi.Models;
using Microsoft.Extensions.Logging;
using EatlistApi.ViewsModel;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EatlistDAL;
using EatlistDAL.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    //Pls, kindly change the TestController to BaseController for IDS
    public class PostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private Posts _Posts = new Posts();
        private PostsMedia _Media = new PostsMedia();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();
        public static IConfiguration Configuration;
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

        public PostController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            Configuration = configuration;
            _unitOfWork = unitOfWork;
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
                //return Ok(_postRepo.GetViewableForUser(userId.Id));
                return Ok(_unitOfWork.posts.UserPosts(userId.Id, true, userId.Id));
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
                //return Ok(_postRepo.GetAllbyUserID(userId.Id, userId.Id));
                return Ok(_unitOfWork.posts.UserPosts(userId.Id, false, userId.Id));
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
                    return Ok(_unitOfWork.posts.UserPosts(Id, false, userid.Id));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("GetPostByID")]
        public async Task<ActionResult> GetPost(long Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser userid = await GetCurrentUserAsync();
                    return Ok(_unitOfWork.posts.GetPostByID(Id, userid.Id).ToList());
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
                Account acc = new Account(Configuration["my_cloud_name"], Configuration["my_api_key"], Configuration["my_api_secret"]);
                Cloudinary cloudinary = new Cloudinary(acc);
                ApplicationUser userid = await GetCurrentUserAsync();//await _userManager.GetUserAsync(User);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var NPosts = new Posts();
                NPosts.Caption = post.Caption;
                if (post.DishID > 0)
                {
                    var dsh = _unitOfWork.Dishes.Get((int)post.DishID);
                    if (dsh!=null)
                        NPosts.Dish = dsh;
                    else
                        return BadRequest("the selected dish is invalid");
                };

                NPosts.DateCreated = DateTime.UtcNow;
                NPosts.CreatedBy = userid;
                if (post.RestaurantID != "")
                {
                    var resuser = _userManager.Users.Where(i => i.Id == post.RestaurantID).ToList();
                    if (resuser.Any())
                        NPosts.Restaurant = resuser.FirstOrDefault();
                    else
                        return BadRequest("the selected restaurant is invalid");
                }// UserID;
                //var ret = _postRepo.Insert(_Posts);
                var ret = _unitOfWork.posts.Add(NPosts);

                if (post.PostFiles != null)
                {
                    List<EatlistDAL.Models.PostsMedia> files = new List<EatlistDAL.Models.PostsMedia>();
                    foreach (var file in post.PostFiles)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileURL),
                            Folder = "Eatlist/Posts/"
                        };
                        var uploadResult = cloudinary.Upload(uploadParams);
                        var user = JsonConvert.SerializeObject(uploadResult);
                        _log.LogInformation(user);

                        //PostsMedia postEntity = new PostsMedia { FileType = file.FileType, FileURL = uploadResult.SecureUri.AbsoluteUri, PostID = ret.Id, FileName = uploadResult.PublicId };
                        //_postRepo.Insert(postEntity);
                        files.Add(new EatlistDAL.Models.PostsMedia
                        {
                            FileName = uploadResult.PublicId,
                            FileType = file.FileType,
                            FileURL = uploadResult.SecureUri.AbsoluteUri,
                            Post = ret,
                            CreatedBy =userid,
                            DateCreated = DateTime.UtcNow
                        });
                    }
                    _unitOfWork.posts.UploadPostMedia(files.ToArray());
                }

                //return Ok(_postRepo.GetAllbyUserID(userid.Id, userid.Id));
                return Ok(_unitOfWork.posts.UserPosts(userid.Id, true, userid.Id));
            }
            catch (Exception ex)
            {
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

        [HttpPost, Route("addcomment")]
        public async Task<IActionResult> commentAsync([FromBody]VM_Comment _vmComment)
        {
            try
            {
                EatlistDAL.Models.ApplicationUser userid = await GetCurrentUserAsync();
                if (ModelState.IsValid)
                {
                    Comments _comment = new Comments();

                    _comment.Content = _vmComment.Content;
                    _comment.Image = _vmComment.Image;
                    _comment.Post = _unitOfWork.posts.Get( _vmComment.PostID);
                    _comment.CreatedBy = userid;
                    _comment.DateCreated = DateTime.Now;

                    var res = _unitOfWork.Comments.Add(_comment);
                    if (res.GetType() == typeof(System.InvalidOperationException))
                    {
                        _log.LogInformation(res.ToString());
                        return StatusCode(500);
                    }
                    return Ok(_unitOfWork.Comments.FetchComment(_vmComment.PostID));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                _log.LogInformation(" Ends here... ");

                return StatusCode(500);
            }

        }

        [HttpGet, Route("getcomments/{PostID}")]
        public IActionResult postComment(int PostID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var comments= _postRepo.FetchComments(PostID);
                    var res = _unitOfWork.Comments.FetchComment(PostID);
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

                _log.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                // _log.LogInformation(" Ends here... ");

                return StatusCode(500);
            }

        }

        [HttpPost, Route("addlike/{PostID}")]
        public async Task<IActionResult> LikePost(int PostID)
        {
            try
            {

                dynamic res = "";
                Posts _postObject = _unitOfWork.posts.Get(Convert.ToInt32(PostID));
                //ApplicationUser userid = await _userManager.FindByIdAsync("0ee0f590-f921-4e96-b295-f420680627b6");
                ApplicationUser userid = await GetCurrentUserAsync();


                if (_postObject != null)
                {
                    if (!_unitOfWork.Likes.LikeExist(_postObject.Id, userid.Id))
                    {
                        Likes _likes = new Likes();
                        _likes.Post = _postObject;
                        _likes.CreatedBy = userid;
                        _likes.DateCreated = DateTime.UtcNow.Date;
                        //_likes.IsLiked = !_likes.IsLiked;
                        //success insert
                        res = _unitOfWork.Likes.Add(_likes);
                        if (res.GetType() == typeof(InvalidOperationException) || res.GetType() == typeof(ArgumentNullException))
                        {
                            _log.LogInformation((string)res);
                            return StatusCode(500);
                        }
                    }

                    else //if (!_unitOfWork.Likes.LikeDelete(_postObject.PostID, userid.Id))
                    {
                        //return StatusCode(500, "Operation could not be completed");
                        var likeobj = _unitOfWork.Likes.UserPostLike(_postObject.Id, userid.Id);
                        if (!_unitOfWork.Likes.Remove(likeobj))
                        {
                            return StatusCode(500, "Operation could not be completed");
                        }
                    }
                    return Ok(_unitOfWork.posts.GetPostByID(PostID, userid.Id));

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet, Route("getlikes")]
        public IActionResult postLikes(long PostID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var comments= _postRepo.FetchComments(PostID);
                    var res = _unitOfWork.Likes.FetchLikes(PostID);
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

                return StatusCode(500);
            }

        }

    }
}
