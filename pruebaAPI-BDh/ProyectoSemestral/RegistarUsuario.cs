using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSemestral.Models;
using ProyectoSemestral.Services;

namespace ProyectoSemestral
{
    public partial class RegistarUsuario : Form
    {
        private ClienteRequest cliente;
        private UserService userService;
        public RegistarUsuario()
        {
            InitializeComponent();
            cliente = new ClienteRequest();
            userService = new UserService();

        }

        private void txtCorreoUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseñaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccionUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        //boton para registrar el usuario
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreoUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccionUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text))
                {
                    MessageBox.Show("Por favor llena todos los campos solicitados para tu registro.");
                    return;
                }

                // Crear objeto cliente
                var cliente = new ClienteRequest
                {
                    nombre = txtNombreUsuario.Text.Trim(),
                    email = txtCorreoUsuario.Text.Trim(),
                    direccion = txtDireccionUsuario.Text.Trim(),
                    pass = txtContraseñaUsuario.Text.Trim()
                };

                // Llamar al servicio para registrar el cliente
                var respuesta = await userService.RegistrarCliente<ClienteResponse>(cliente);

                // Verificar si el registro fue exitoso
                if (respuesta == null)
                {
                    MessageBox.Show("Hubo un problema con el registro.");
                }
                else
                {
                    MessageBox.Show("Registro exitoso: " + respuesta.Mensajito);
                    //abre la nueva ventana y vuelve el form 1
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }




        private void RegistarUsuario_Load(object sender, EventArgs e)
        {

        }

        //boton para volver a la pantalla principal
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
