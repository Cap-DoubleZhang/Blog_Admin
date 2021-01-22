using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace AdminBlog.EntityFramework.Core
{
    [AppDbContext("ConnectionStrings:DbConnectionString", DbProvider.SqlServer)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}