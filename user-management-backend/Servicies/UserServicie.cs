using user_management_backend.DTOs;
using user_management_backend.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using user_management_backend.Models; // si usas EF Core


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
                Age = user.Age,
                Email = user.Email,
                // Agregar otros campos según sea necesario
            });
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Age = userDto.Age,
                Email = userDto.Email
            };

            // Si el repositorio es síncrono, no uses await
            _userRepository.AddUser(user);
        }

        public async Task<UserDto?> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de usuario no valido");

            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new KeyNotFoundException("Usuario no encontrado");

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            };


        }
    }
}
