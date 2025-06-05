using user_management_backend.DTOs;
using user_management_backend.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // si usas EF Core


namespace user_management_backend.Servicies
{
    public class UserServicie
    {
        private readonly IUserRepository _userRepository; // Creamos una variable privada _userRepository para acceder al repositorio de usuarios

        public UserServicie(IUserRepository userRepository) // Inyectamos el repositorio IUserRepository en el constructor
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync() // Método para obtener todos los usuarios
        {
            var users = await _userRepository.GetAllUsersAsync(); // Llama al método GetAllUsersAsync del repositorio y espera a que se complete

            return users.Select(user => new UserDto // Convierte cada usuario a un UserDto y devuelve la lista de UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                // Agregar otros campos según sea necesario
            });
        }
    }
}
