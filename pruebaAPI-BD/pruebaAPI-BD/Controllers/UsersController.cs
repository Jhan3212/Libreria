using Microsoft.AspNetCore.Mvc;
using MySqlConnector;




[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Valida si el usuario es un administrador o cliente.
    /// </summary>
    /// <param name="request">Datos del usuario para el login</param>
    /// <returns>Devuelve un mensaje indicando si es un admin o usuario.</returns>
    [HttpPost("validate")]
    public async Task<IActionResult> ValidateUser([FromBody] LogueoUsuarioAdmin request)
    {
        if (string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("El nombre de usuario o contraseña no pueden estar vacíos.");
        }

        try
        {
            using (var connection = new MySqlConnection("YourConnectionString"))
            {
                await connection.OpenAsync();

                // Verificar si es administrador
                string adminQuery = "SELECT idAdmin, nombreAdmin FROM admins WHERE idAdmin = @Id AND contraseñaAdmin = @Password";
                using (var adminCommand = new MySqlCommand(adminQuery, connection))
                {
                    adminCommand.Parameters.AddWithValue("@Id", request.Id);
                    adminCommand.Parameters.AddWithValue("@Password", request.Password);

                    using (var reader = await adminCommand.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // Se encontró un administrador con las credenciales correctas
                            var adminName = reader.GetString("nombreAdmin");
                            return Ok(new { role = "admin", message = $"Usuario {adminName} validado como administrador." });
                        }
                    }
                }

                // Verificar si es cliente
                string userQuery = "SELECT idCliente, nombre FROM Cliente WHERE email = @Id AND password = @Password";
                using (var userCommand = new MySqlCommand(userQuery, connection))
                {
                    userCommand.Parameters.AddWithValue("@Id", request.Id);
                    userCommand.Parameters.AddWithValue("@Password", request.Password);

                    int userCount = Convert.ToInt32(await userCommand.ExecuteScalarAsync());
                    if (userCount > 0)
                    {
                        return Ok(new { role = "user", message = "Usuario validado como cliente." });
                    }
                }

                return Unauthorized("Nombre de usuario o contraseña incorrectos.");
            }
        }
        catch (MySqlException ex)
        {
            return StatusCode(500, $"Error al conectarse a la base de datos: {ex.Message}");
        }
    }
    public class LogueoUsuarioAdmin
    {
        /// <summary>
        /// El ID o correo electrónico del usuario o administrador
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// La contraseña del usuario o administrador
        /// </summary>
        public string Password { get; set; }
    }

}

