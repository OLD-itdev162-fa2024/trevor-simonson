using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET api/posts
        /// </summary>
        /// <returns>A list of posts</returns>
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get(){
            return _context.Posts.ToList();
        }


        /// <summary>
        /// GET api/posts/[id]
        /// </summary>
        /// <param name="id">Post id<</param>
        /// <returns>A single post</returns>
        [HttpGet(Name = "GetById")]
        public ActionResult<Post> Get(int id)
        {
            var post = _context.Posts.Find(id);
            
            if(post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}