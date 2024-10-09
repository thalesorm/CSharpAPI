using System;
using Microsoft.EntityFrameworkCore;
using ActionModel = ApiGap.Models.Action;
using UserModel = ApiGap.Models.User;

namespace ApiGap.Data
{
    public class GapApiDBContext : DbContext
    {
        public GapApiDBContext(DbContextOptions<GapApiDBContext> options)
            : base(options)
        {
        }

        public DbSet<ActionModel> Actions { get; set; }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
