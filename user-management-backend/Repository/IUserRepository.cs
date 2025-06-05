using user_management_backend.Models;

namespace user_management_backend.Repository
{
    public interface IUserRepository //se encarga de acceder y manipular los datos en la base de datos.
    {
        Task<IEnumerable<User>> GetAllUsersAsync(); // Método para obtener todos los usuarios
        //User? GetById(int id); // Método para obtener un usuario por su ID
        //void add(User user); // Método para agregar un nuevo usuario
    }
}
