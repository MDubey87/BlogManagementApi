using Blog.Management.Services.Helpers;
using Blog.Management.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Management.Services
{
    /// <summary>
    /// Blog Service Interface for CRUD Operation
    /// </summary>
    public interface IBlogServcie
    {
        /// <summary>
        /// Get List of All Blogs
        /// </summary>
        /// <returns></returns>
        public Task<List<BlogPost>> GetAllBlogs();
        /// <summary>
        /// Get Blog by Blog Id
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Blog Post</returns>
        public Task<BlogPost?> GetBlogById(Guid id);

        /// <summary>
        /// Create New Blog
        /// </summary>
        /// <param name="newBlog">New Blog Request Model</param>
        /// <returns>Created Blog</returns>
        public Task<BlogPost> CreateBlog(BlogPost newBlog);

        /// <summary>
        /// Update Existing Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <param name="updatedBlog">Updated Blog Request Model</param>
        /// <returns>Updated Blog</returns>
        public Task<BlogPost?> UpdateBlog(Guid id, BlogPost updatedBlog);
        /// <summary>
        /// Delete Existing Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns>Return Deleted Blog</returns>
        public Task<BlogPost?> DeleteBlog(Guid id);
    }
    /// <summary>
    /// Blog Service Implementation
    /// </summary>
    public class BlogService : IBlogServcie
    {
        /// <inheritdoc/>>
        public async Task<List<BlogPost>> GetAllBlogs()
        {
            return await JsonFileHelper.ReadFromJsonFile<BlogPost>();
        }
        /// <inheritdoc/>>
        public async Task<BlogPost?> GetBlogById(Guid id)
        {
            var blogs = await JsonFileHelper.ReadFromJsonFile<BlogPost>();
            var blog = blogs.FirstOrDefault(p => p.Id == id);
            return blog;
        }
        /// <inheritdoc/>>
        public async Task<BlogPost> CreateBlog(BlogPost newBlog)
        {
            var blogs = await JsonFileHelper.ReadFromJsonFile<BlogPost>();
            newBlog.Id = Guid.NewGuid();
            blogs.Add(newBlog);
            JsonFileHelper.WriteToJsonFile(blogs);
            return newBlog;
        }
        /// <inheritdoc/>>
        public async Task<BlogPost?> UpdateBlog(Guid id, BlogPost updatedBlog)
        {
            var blogs = await JsonFileHelper.ReadFromJsonFile<BlogPost>();
            var blog = blogs.FirstOrDefault(p => p.Id == id);

            if (blog == null)
            {
                return null;
            }

            blog.UserName = updatedBlog.UserName;
            blog.Content = updatedBlog.Content;
            blog.DateCreated = updatedBlog.DateCreated;
            JsonFileHelper.WriteToJsonFile(blogs);

            return blog;
        }
        /// <inheritdoc/>>
        public async Task<BlogPost?> DeleteBlog(Guid id)
        {
            var blogs = await JsonFileHelper.ReadFromJsonFile<BlogPost>();
            var blog = blogs.FirstOrDefault(p => p.Id == id);

            if (blog == null)
            {
                return null;
            }

            blogs.Remove(blog);
            JsonFileHelper.WriteToJsonFile(blogs);

            return blog;
        }
    }
}

