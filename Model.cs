using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Assignment;


public class User
{
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }


       public List<int>? Posts = new List<int>();

}
    public class Post
    {
        public int? PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int? BlogId { get; set; }

        public Blog? Blog { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }

    public class Blog
    {
        public int? BlogId { get; set; }
        public string? Url { get; set; }

        public string? Name { get; set; }

        public List<int>? Posts = new List<int>();

        

    }
    public class BloggingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Csvinsert.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>

            options.UseSqlite($"Data Source ={DbPath}");

    }







