using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_management_backend.Data;
using user_management_backend.DTOs;
using user_management_backend.Models;
using user_management_backend.Servicies;

namespace user_management_backend.controllers
{
    [ApiController]
    [Route("api/[controller]")]// api/users
    public class UsersController : ControllerBase
    {
        public readonly UserServicie _userServicie; // Creamos una variable privada userServicie para acceder a los servicios de usuario
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserServicie userServicie, ILogger<UsersController> logger) // Inyectamos el servicio UserServicie en el constructor
        {
            _userServicie = userServicie;
            _logger = logger;
        }

        [HttpGet] // Endpoint para obtener todos los usuarios
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userServicie.GetAllUsersAsync(); // Llama al método GetAllUsersAsync del servicio y espera a que se complete
            return Ok(users); // 200 OK con lista de usuarios
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            await _userServicie.AddUserAsync(userDto);
            return Ok(); //cambiar statu code a 201
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userServicie.GetById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "ID inválido proporcionado");
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario no encontrado");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar usuario");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _userServicie.DeleteById(id);
                return NoContent(); // 204 No Content
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "ID inválido proporcionado");
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario no encontrado");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario");
                return StatusCode(500, ex.Message);
            }
        }

    }
}

