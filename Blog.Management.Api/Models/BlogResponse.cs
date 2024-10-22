namespace Blog.Management.Api.Models
{
    /// <summary>
    /// Blog Response Model
    /// </summary>
    public class BlogResponse
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
