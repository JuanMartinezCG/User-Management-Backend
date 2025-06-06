using Microsoft.EntityFrameworkCore;
using user_management_backend.Data;
using user_management_backend.Repository;
using user_management_backend.Servicies;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar el servicio de DbContext con la cadena de conexión a PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration
    .GetConnectionString("DefaultConnection")));

// 2. Agregar servicios para controladores (API REST)
builder.Services.AddControllers();

// 3. Inyectar repositorios y servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserServicie>();

// 4. Agregar Swagger (documentación interactiva para probar tus endpoints)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configurar middleware (Swagger, HTTPS, rutas, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Forzar HTTPS

//app.UseAuthorization(); // Para seguridad (si usas autenticación en el futuro)

app.MapControllers(); // Enlaza los controladores con las rutas HTTP

app.Run(); // Ejecuta la app
