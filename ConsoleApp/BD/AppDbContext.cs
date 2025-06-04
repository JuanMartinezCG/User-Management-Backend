using ConsoleApp.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.BD
{
    internal class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }// Representa la tabla "Users"

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +// donde se conectara la BD
                "Database=userdb;" + //Nombre de la base de datos
                "Username=admin;" + // usario de la BD
                "Password=mysecretpassword"); // contraseña de la BD
        }
    }
}
