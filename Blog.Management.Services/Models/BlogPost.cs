using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Management.Services.Models
{
    /// <summary>
    /// Blog Post Class
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Blog Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// User Name 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Blog Creation Date
        /// </summary>
        public string DateCreated { get; set; }
        /// <summary>
        /// Blog Content
        /// </summary>
        public string Content { get; set; }
    }
}
