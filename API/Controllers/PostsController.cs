using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
using API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    namespace API.Controllers
    {
        [ApiController]
        [Route("api/posts")]
        public class PostsController : ControllerBase
        {
            private readonly DataContext _context;
            private readonly ILogger<PostsController> _logger;
            private readonly IMapper _mapper;

            public PostsController(DataContext context, ILogger<PostsController> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            [HttpGet]
            public ActionResult<IEnumerable<PostDto>> GetPosts()
            {
                try
                {
                    var posts = _context.Posts
                        .Include(p => p.User) // Include the User navigation property
                        .ToList();

                    var postDtos = _mapper.Map<List<Post>>(posts); // Map the Post entities to PostDto objects

                    return Ok(postDtos);
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

                    var createdPostDto = _mapper.Map<Post>(post); // Map the created Post entity to a PostDto object

                    return Ok(createdPostDto);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions and return an error response
                    _logger.LogError(ex, "An error occurred while creating the posts.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating post");
                }
            }


            [HttpDelete("{postId}")]
            public async Task<IActionResult> DeletePost(Guid postId)
            {
                try
                {
                    // Retrieve the post from the database
                    var post = await _context.Posts.FindAsync(postId);

                    // Check if the post exists
                    if (post == null)
                        return NotFound("Post not found");

                    // Remove the post from the context
                    _context.Posts.Remove(post);

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    return NoContent();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions and return an error response
                    _logger.LogError(ex, "An error occurred while deleting the post.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting post");
                }
            }
        }
    }
}