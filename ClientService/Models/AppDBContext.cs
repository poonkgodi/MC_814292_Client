using Microsoft.EntityFrameworkCore;

namespace ClientService.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ClientRequest> ClientRequests { get; set; }
        public DbSet<ClientResponse> ClientResponses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
