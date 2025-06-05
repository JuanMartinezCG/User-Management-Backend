using user_management_backend.Models; // Importa el modelo User
using Microsoft.EntityFrameworkCore;

namespace user_management_backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } // DbSet para la entidad User, representa la tabla Users en la base de datos

    }
}
