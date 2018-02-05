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

        public PostController(ILogger<PostController> log)
        {
            _log = log;
        }

        //private Post _post 
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void PostIns([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //[ActionName("commentIns")]
        [HttpPost]
        public async Task<IActionResult> commentIns(Comments post)
        {

            if (ModelState.IsValid)
            {

                // _upload.IsProfile = true;
                // _upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
                // _upload.FileUrl = upload.FileUrl;

                // await DbContext.Posts.AddAsync(_upload);
                // await _context.SaveChangesAsync();
                return Ok(_postRepo.CommentInsert(post));
            }
            else
            {
                return BadRequest();
            }
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
                        _log.LogInformation(res.ToString ());
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

                _log.LogInformation(ex.Message+" : "+ex.InnerException);
                _log.LogInformation( " Ends here... " );
                
                return null;
            }

        }
    }
}
