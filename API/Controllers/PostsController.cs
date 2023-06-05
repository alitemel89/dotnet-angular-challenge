using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<PostsController> _logger;

        public PostsController(DataContext context, ILogger<PostsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            try
            {
                var posts = _context.Posts.ToList();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "An error occurred while retrieving the posts.");
                return StatusCode(500, "An error occurred while retrieving the posts.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostDto postDTO)
        {
            try
            {
                // Check if the user exists
                var user = await _context.Users.FindAsync(Guid.Parse(postDTO.UserId));
                if (user == null)
                    return NotFound("User not found");

                // Map the DTO to a Post entity
                var post = new Post
                {
                    PostId = Guid.NewGuid(),
                    Caption = postDTO.Caption,
                    User = user
                };

                // Add the post to the context and save changes
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                _logger.LogError(ex, "An error occurred while creating the posts.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating post");
            }
        }

    }
}