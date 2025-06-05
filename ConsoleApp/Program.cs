using ConsoleApp.BD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Necesario para usar List<T>
using System.Linq; // Para usar LINQ (búsquedas más eficientes)
using ConsoleApp.Entidades;
using Microsoft.EntityFrameworkCore;

namespace UserManagementSystem
{
    class Program
    {        
        // Punto de entrada del programa.
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Gestión de Usuarios (Backend) ===");

            // Menú principal
            while (true) // Bucle infinito hasta que el usuario elija salir.
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Mostrar usuarios");
                Console.WriteLine("3. Buscar usuario por nombre");
                Console.WriteLine("4. Eliminar usuario por email");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine(); // Lee la entrada del usuario.

                switch (option)
                {
                    case "1":
                        RegisterUser(); // Lógica para registrar usuario.
                        break;
                    case "2":
                        ShowUsers(); // Lógica para mostrar usuarios.
                        break;
                    case "3":
                        SearchUser(); // Lógica para buscar usuario.
                        break;
                    case "4":
                        DeleteUserByEmail(); //logica Eliminar Usuario por Email
                        break;
                    case "0":
                        Environment.Exit(0); // Cierra la aplicación.
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.Clear();
                        break;
                }
            }
        }

        // Método para registrar un nuevo usuario.
        static void RegisterUser()
        {
            while (true)
            {
                using (var db = new AppDbContext()) // Abre conexión a la BD
                {
                    Console.WriteLine("\n--- Registro de Usuario ---");
                    var newUser = new User(); // Crea una instancia de User.

                    try
                    {
                        Console.Write("Nombre: ");
                        newUser.Name = Console.ReadLine(); // Asigna el nombre.

                        Console.Write("Edad: "); // Asigna la edad
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            throw new Exception("Se debe ingresar un número entero válido");
                        }

                        if (age < 0) throw new Exception("La Edad no puede ser negativa");
                        newUser.Age = age; // Asigna la edad al usuario

                        Console.Write("Email: ");       // Asigna el Email.
                        newUser.Email = Console.ReadLine();

                        // Validación usando los atributos del modelo
                        var validationErrors = new List<ValidationResult>();
                        if (!Validator.TryValidateObject(newUser, new ValidationContext(newUser), validationErrors, true))
                        {
                            Console.WriteLine("\n--- Errores de validación ---");
                            foreach (var error in validationErrors)
                            {
                                Console.WriteLine($"- {error.ErrorMessage}");
                            }
                            Console.WriteLine("----------------------------");
                            continue; // Vuelve al inicio del bucle
                        }

                        db.Users.Add(newUser); // Prepara el "INSERT" en la BD
                        db.SaveChanges();      // Ejecuta el comando SQL
                        Console.WriteLine("¡Usuario registrado en PostgreSQL!");
                        break; // Sale del bucle si todo fue exitoso

                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine($"Error de formato: {e.Message}");
                        Console.WriteLine("------------------------");
                    }
                    catch (DbUpdateException e)
                    {
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine($"Error al guardar en la base de datos: {e.InnerException?.Message}");
                        Console.WriteLine("------------------------");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine($"Error inesperado: {e.Message}");
                        Console.WriteLine("------------------------");
                    }
                 
                    // Preguntar si desea intentar nuevamente
                    Console.Write("\n¿Desea volver intentar registrar el usuario? (s/n): ");
                    if (Console.ReadLine().ToLower() != "s")
                        break;
                }
            }
        }

        // Método para mostrar todos los usuarios registrados.
        static void ShowUsers()
        {
            /*Console.WriteLine("\n--- Lista de Usuarios ---\n");

            if (users.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

            // Itera sobre cada usuario en la lista.
            foreach (var user in users)
            {
                Console.WriteLine($"Nombre: {user.Name}," +
                    $" Edad: {user.Age}, " +
                    $"Email: {user.Email}");
            }
            Console.WriteLine("\n------------------------");
            Console.Write("Presione Enter para continuar");Console.ReadKey();
            Console.Clear();*/
        }

        // Método para buscar usuarios por nombre (case-insensitive).
        static void SearchUser()
        {
            /*Console.WriteLine("\n--- Buscar Usuario ---\n");
            Console.Write("Ingrese el nombre a buscar: ");
            string searchName = Console.ReadLine();

            // Busca usuarios cuyo nombre contenga el texto ingresado (ignorando mayúsculas/minúsculas).
            var foundUsers = users.FindAll(u => u.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundUsers.Count == 0)
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("No se encontraron usuarios.");
                Console.WriteLine("------------------------");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

            Console.WriteLine($"Resultados ({foundUsers.Count}):");
            foreach (var user in foundUsers)
            {
                Console.WriteLine($"Nombre: {user.Name}, " +
                    $"Edad: {user.Age}, " +
                    $"Email: {user.Email}");
            }
            Console.ReadKey();
            Console.Clear();*/

        }

        static void DeleteUserByEmail()
        {
            /*Console.WriteLine("\n--- Elimanar Usuario por Email---\n");
            Console.Write("Ingrese el Email a buscar: ");
            string searchEamil = Console.ReadLine();

            User foundUsers = users.FirstOrDefault(u => u.Email.Equals(searchEamil, StringComparison.OrdinalIgnoreCase));

            if (foundUsers != null)
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine($"Nombre: {foundUsers.Name}, " +
                    $"Edad: {foundUsers.Age}, " +
                    $"Email: {foundUsers.Email}");
                Console.WriteLine("\n------------------------");
                users.Remove(foundUsers);
                Console.WriteLine("Usuario eliminado correctamente.");
                Console.WriteLine("\n------------------------");
                Console.ReadKey(); 
                Console.Clear();

            }
            else
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("No se encontró un usuario con ese email.");
                Console.WriteLine("------------------------");
                DeleteUserByEmail();
            }*/
        }
    }
}
