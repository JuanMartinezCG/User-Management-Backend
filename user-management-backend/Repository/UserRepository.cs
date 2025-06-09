using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using user_management_backend.Data;
using user_management_backend.Models;

namespace user_management_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _db; // Creamos una variable privada _db para acceder a la base de datos (PostgreSQL).

        public UserRepository(AppDbContext db) // Inyectamos el contexto de la base de datos AppDbContext en el constructor
        {
            _db = db;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync() // Método para obtener todos los usuarios
        {
            return await _db.Users.ToListAsync(); // Devuelve una lista de todos los usuarios en la base de datos
        }
        public async void AddUser(User user) // Método para agregar un nuevo usuario
        {
            _db.Users.Add(user); // Agrega el usuario al contexto de la base de datos
            _db.SaveChanges(); // Guarda los cambios en la base de datos
        }

        public async Task<User?> GetById(int id)
        {
            return await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task DeleteById(User user)
        {
             _db.Users
                .Remove(user);

            await _db.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

    }
}
