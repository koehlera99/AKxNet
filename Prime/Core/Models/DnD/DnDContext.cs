using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.DnD
{
    public class DnDContext : DbContext
    {
        public DnDContext(DbContextOptions<DnDContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Blog Name")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class DnD2Context : DbContext
    {
        public DnD2Context(DbContextOptions<DnDContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
