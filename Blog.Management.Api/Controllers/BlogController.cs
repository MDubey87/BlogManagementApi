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
        public ActionResult<List<BlogResponse>> GetBlogs()
        {
            var blogs= _blogServcie.GetAllBlogs();
            return _mapper.Map<List<BlogResponse>>(blogs);
        }
        /// <summary>
        /// Get Blog By BlogId
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Blog Post</returns>

        [HttpGet("{id}")]
        public ActionResult<BlogResponse> GetBlogById(Guid id)
        {
            var blog = _blogServcie.GetBlogById(id);
            if (blog == null) return NotFound();
            return _mapper.Map<BlogResponse>(blog);
        }
        /// <summary>
        /// Create New Blog
        /// </summary>
        /// <param name="newBlog">Blog Request Model</param>
        /// <returns>New Blog Post</returns>
        [HttpPost]
        public ActionResult CreateBlog([FromBody] BlogRequest newBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = _blogServcie.CreateBlog(_mapper.Map<BlogPost>(newBlog));
            return Ok();
        }

        /// <summary>
        /// Update Blog Post
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <param name="updatedBlog">Updated Blog Post Model</param>
        /// <returns>Update Status</returns>

        [HttpPut("{id}")]
        public ActionResult UpdateBlog([Required]Guid id, [FromBody] BlogRequest updatedBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = _blogServcie.UpdateBlog(id, _mapper.Map<BlogPost>(updatedBlog));
            if (blog == null) return NotFound();
            return Ok();
        }

        /// <summary>
        /// Delete Blog Post
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Delete Status</returns>
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(Guid id)
        {
            var blog = _blogServcie.DeleteBlog(id);
            if (blog == null) return NotFound();
            return Ok();
        }
    }
}
