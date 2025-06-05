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

        public UsersController(UserServicie userServicie) // Inyectamos el servicio UserServicie en el constructor
        {
            _userServicie = userServicie;
        }

        [HttpGet] // Endpoint para obtener todos los usuarios
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userServicie.GetAllUsersAsync(); // Llama al método GetAllUsersAsync del servicio y espera a que se complete
            return Ok(users); // 200 OK con lista de usuarios
        }  

    }
















        /*private readonly AppDbContext _db; //Creamos una variable privada _db para acceder a la base de datos (PostgreSQL).
        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {

            _db.Users.Add(user);
            await _db.SaveChangesAsync(); // Guarda en PostgreSQL



            return Ok(user); // Devuelve el usuario creado
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _db.Users.ToListAsync(); // Obtiene todos los usuarios
            return Ok(users);
        }*/
}

