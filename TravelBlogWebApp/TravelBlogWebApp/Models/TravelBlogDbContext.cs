﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelBlogWebApp.Models
{
    public class TravelBlogDbContext : IdentityDbContext<IdentityUser>
    {
        public TravelBlogDbContext(DbContextOptions<TravelBlogDbContext> options)
            : base(options) { }

        public DbSet<Blog>? Blogs { get; set; }

        public DbSet<Post>? Posts { get; set; }

        public DbSet<Section>? Sections { get; set; }

        public DbSet<Comment>? Comments { get; set; }

        public DbSet<Destination>? Destinations { get; set; }

        public DbSet<User>? Users { get; set; }

    }
}
