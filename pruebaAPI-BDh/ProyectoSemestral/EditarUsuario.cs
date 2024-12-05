using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProyectoSemestral.Models;
using ProyectoSemestral.Services;

namespace ProyectoSemestral
{
    public partial class EditarUsuario : Form
    {
        private List<Cliente> clientes;
        private string usuario;
        private UserService userService;
        public EditarUsuario(string usuario, List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = new List<Cliente>();
            this.userService = new UserService();
            this.clientes = clientes;
            this.usuario = usuario;
          
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreoUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccionUsuario.Text))
                {
                    MessageBox.Show("Por favor llena todos los campos antes de continuar.", "Campos Vacíos");
                    return;
                }

                // Verificar cliente seleccionado
                var clienteSeleccionado = this.clientes.FirstOrDefault();
                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("No hay un cliente seleccionado para editar.", "Cliente no Seleccionado");
                    return;
                }

                // Crear objeto ClienteRequest
                var clienteRequest = new ClienteRequest
                {
                    nombre = txtNombreUsuario.Text.Trim(),
                    email = txtCorreoUsuario.Text.Trim(),
                    pass = txtContraseñaUsuario.Text.Trim(),
                    direccion = txtDireccionUsuario.Text.Trim(),
                };


                // Llamar al servicio
                var respuesta = await userService.EditarCliente<ClienteResponse>(clienteSeleccionado.idCliente, clienteRequest);

                // Manejar la respuesta
                if (respuesta == null)
                {
                    MessageBox.Show("Hubo un problema al editar el usuario. Por favor, intenta de nuevo.", "Error");
                }
                else
                {
                    MessageBox.Show("Edición exitosa: " + respuesta.Mensajito, "Éxito");

                    // Abrir siguiente formulario
                    var form3 = new Form3(txtNombreUsuario.Text.Trim(), this.clientes);
                    form3.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al editar el usuario: {ex.Message}", "Error");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this.usuario, this.clientes);
            form3.Show();
            this.Hide();
        }
    }
}
