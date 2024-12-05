using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProyectoSemestral.Models;
using ProyectoSemestral.Services; // Asegúrate de que este sea el namespace correcto

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

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistarUsuario registarUsuario = new RegistarUsuario();
            registarUsuario.Show();
            this.Hide();
            
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseñaUsuario_TextChanged(object sender, EventArgs e)
        {

        }


        //es para inciniar sesion
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

            var user = new UserRequest()
            {
                Name = usuario,
                Password = contraseña
            };

            var userC = new Cliente()
            {
                nombre = usuario,
                pass = contraseña
            };

            try
            {
                var respuesta = await UserService.ObtenerTodosLosUsuarios(user);
                List<Cliente> cliente = await UserService.ObtenerTodosLosClientes(userC);

                if (respuesta != null && respuesta.Count > 0 || cliente!= null && cliente.Count > 0)
                {
                    // Inicio de sesión exitoso
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //para admin
                    if (user.Name == "Eduardo1234" && user.Password == "5555")
                    {
                        Form2 form2 = new Form2(usuario);
                        form2.Show();
                        this.Hide();
                    }
                    //para admin
                    else if (user.Name == "JuanPerez" && user.Password == "12345")
                    {
                        Form2 form2 = new Form2(usuario);
                        form2.Show();
                        this.Hide();
                    }
                    
                    //para usuarios
                    else
                    {
                        
                        Form3 form3 = new Form3(usuario, cliente);
                        form3.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    // Usuario no encontrado
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

