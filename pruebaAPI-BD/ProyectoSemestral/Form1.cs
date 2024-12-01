﻿using System;
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

            try
            {
                var respuesta = await UserService.ObtenerTodosLosUsuarios(user);

                if (respuesta != null && respuesta.Count > 0)
                {
                    // Inicio de sesión exitoso
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 form2 = new Form2(usuario);
                    form2.Show();

                    this.Hide();
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

