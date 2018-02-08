using System;
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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private static readonly ApplicationDbContext _post = new ApplicationDbContext();
        private readonly PostRepository _postRepo = new PostRepository(_post);
        readonly ILogger<PostController> _log;
        private Posts _Posts = null;
        //UserID will be changed
        string UserID = "03503819-15ce-489c-946e-ff86a5324189";

        public PostController(ILogger<PostController> log)
        {
            _log = log;
        }

        // GET: api/<controller>
        /// <summary>
        /// gets all posts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        /// <summary>
        /// gets a specific post by PostID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /// <summary>
        /// endpoint to create new posts
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public IActionResult Post(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _Posts = new Posts();
            _Posts.FileURL = post.FileURL;
            _Posts.FileType = post.FileType;
            _Posts.DateCreated = DateTime.UtcNow;
            _Posts.CreatedBy = UserID;

            return Ok(_postRepo.Insert(_Posts));
        }

        /// <summary>
        /// endpoint to update posts.
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut, Route("update")]
        public IActionResult Update(Update update)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _Posts = new Posts();
                _Posts.PostID = update.PostID;
                _Posts.FileURL = update.FileURL;
                _Posts.FileType = update.FileType;

                _postRepo.Update(_Posts);
                return Ok(_postRepo.Update(_Posts));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message.ToString());
                return StatusCode(500);
            }
        }

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
                _log.LogInformation(" Ends here... ");

                return null;
            }

        }
    }
}
