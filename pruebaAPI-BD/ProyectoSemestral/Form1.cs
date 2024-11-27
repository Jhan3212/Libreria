using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProyectoSemestral.Models; // Asegúrate de que este sea el namespace correcto

namespace ProyectoSemestral
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\ImgPrograma\Fondo1.png");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            _httpClient = new HttpClient();
        }

        private async Task<RespuestaLogin> EnviarValidarLoginAsync(LogueoUsuarioAdmin loginData)
        {
            try
            {
                // Convertir el objeto LoginData a JSON
                string jsonData = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST para validar el inicio de sesión
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:7061/api/users/validate", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Deserializar la respuesta de la API a un objeto de tipo RespuestaLogin
                    return JsonConvert.DeserializeObject<RespuestaLogin>(responseBody);
                }
                else
                {
                    MessageBox.Show("Error al intentar iniciar sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseñaUsuario.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("El campo de usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseñaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesionUsuario_Click(object sender, EventArgs e)
        {
            btnIniciarSesionUsuario_ClickAsync(sender, e);
        }

        private async void btnIniciarSesionUsuario_ClickAsync(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseñaUsuario.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Usuario y contraseña no pueden estar vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear una instancia de LogueoUsuarioAdmin con los datos del formulario
            var loginData = new LogueoUsuarioAdmin
            {
                Id = usuario,
                Password = contraseña
            };

            // Enviar los datos de login para validar
            var respuesta = await EnviarValidarLoginAsync(loginData);

            if (respuesta != null)
            {
                if (respuesta.Status == "Success")
                {
                    // Validación según el rol
                    if (respuesta.Role == "admin")
                    {
                        MessageBox.Show("Bienvenido, Administrador.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Aquí puedes abrir el formulario de administrador
                    }
                    else if (respuesta.Role == "user")
                    {
                        MessageBox.Show("Bienvenido, Usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Aquí puedes redirigir a un formulario de usuario
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
