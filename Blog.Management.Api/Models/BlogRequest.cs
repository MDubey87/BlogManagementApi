using System.ComponentModel.DataAnnotations;

namespace Blog.Management.Api.Models
{
    /// <summary>
    /// Blog Request Model
    /// </summary>
    public class BlogRequest
    {
        /// <summary>
        /// User Name 
        /// </summary>
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        /// <summary>
        /// Blog Creation Date
        /// </summary>
        [Required(ErrorMessage = "Creation date is required")]
        public string DateCreated { get; set; }
        /// <summary>
        /// Blog Content
        /// </summary>
        [Required(ErrorMessage = "Blog Content is required")]
        public string Content { get; set; }
    }
}
