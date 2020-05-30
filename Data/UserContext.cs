using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data

{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options): base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
    }
}

