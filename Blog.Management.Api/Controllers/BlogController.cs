using AutoMapper;
using Blog.Management.Api.Models;
using Blog.Management.Services;
using Blog.Management.Services.Helpers;
using Blog.Management.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServcie _blogServcie;
        private readonly IMapper _mapper;
        /// <summary>
        /// Controller Constructor
        /// </summary>
        /// <param name="blogServcie">Blog Service</param>
        /// <param name="mapper">Mapper</param>
        public BlogController(IBlogServcie blogServcie,IMapper mapper)
        {
            _blogServcie = blogServcie;
            _mapper = mapper;
        }
        /// <summary>
        /// Get List of All Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<BlogResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs= await _blogServcie.GetAllBlogs();
            return Ok(_mapper.Map<List<BlogResponse>>(blogs));
        }
        /// <summary>
        /// Get Blog By BlogId
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Blog Post</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBlogById(Guid id)
        {
            var blog = await _blogServcie.GetBlogById(id);
            if (blog == null) return NotFound();
            return Ok(_mapper.Map<BlogResponse>(blog));
        }
        /// <summary>
        /// Create New Blog
        /// </summary>
        /// <param name="newBlog">Blog Request Model</param>
        /// <returns>New Blog Post</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequest newBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = await _blogServcie.CreateBlog(_mapper.Map<BlogPost>(newBlog));
            return Ok(blog.Id);
        }

        /// <summary>
        /// Update Blog Post
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <param name="updatedBlog">Updated Blog Post Model</param>
        /// <returns>Update Status</returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBlog([Required]Guid id, [FromBody] BlogRequest updatedBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = await _blogServcie.UpdateBlog(id, _mapper.Map<BlogPost>(updatedBlog));
            if (blog == null) return NotFound();
            return Ok();
        }

        /// <summary>
        /// Delete Blog Post
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Delete Status</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var blog = await _blogServcie.DeleteBlog(id);
            if (blog == null) return NotFound();
            return Ok();
        }
    }
}
