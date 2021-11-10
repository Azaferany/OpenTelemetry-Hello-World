using Microsoft.EntityFrameworkCore;

namespace OpenTelemetry
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}