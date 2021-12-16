using GeekBurger.Order.API.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GeekBurger.Order.API.Services.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        // public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<OrderModel> Order { get; set; }
    }
}
