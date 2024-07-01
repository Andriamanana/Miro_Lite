using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Miro.Lite.Api.Entities;

namespace Miro.Lite.Api.Data
{
    public class UserStoryDb(DbContextOptions<UserStoryDb> options) : DbContext(options)
    {
        public DbSet<UserStory> UserStories => Set<UserStory>();
    }
}

