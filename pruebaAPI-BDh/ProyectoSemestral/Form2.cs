using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSemestral.Models;
using ProyectoSemestral.Services;

namespace ProyectoSemestral
{
    public partial class Form2 : Form
    {
        private string usuario;
        private LibroService libroService;
        private UserService userService;
        public Form2(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            userService = new UserService();
            libroService = new LibroService();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario;

            this.CargarListBoxLibros();

            this.CargarListBoxUsuarios();
        }

        //metodo para cargar la listbox
        private async void CargarListBoxLibros()
        {
            var libros = await libroService.ObtenerTodosLosLibritos();

            listBox1.Items.Clear();
            foreach (var libro in libros)
            {
                listBox1.Items.Add(libro);
            }
        }

        private async void CargarListBoxUsuarios()
        {
            var users = await userService.ObtenerTodosLosUsuariosNegros();

            lbxUsuarios.Items.Clear();
            foreach (var user in users)
            {
                lbxUsuarios.Items.Add(user);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        //boton para eliminar usuario selecionado en la listbox
        private async void button3_Click(object sender, EventArgs e)
        {
            Cliente clienteseleccionado = (Cliente)lbxUsuarios.SelectedItem;

            if (clienteseleccionado != null)
            {
                try
                {
                    // Llamamos al método estático EliminarCliente a través de la clase UserService
                    string mensaje = await UserService.EliminarCliente(clienteseleccionado.idCliente);
                    MessageBox.Show(mensaje); // Mostrar el mensaje de éxito o error
                    this.CargarListBoxUsuarios();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}"); // Si hay un error, lo mostramos
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar."); // Si no se ha seleccionado un cliente
                return;
            }
        }



        //este boton es para eliminar un libro selecionado
        private async void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                try
                {
                    Libros libritooo = (Libros)listBox1.SelectedItem;


                    var respuesta = await LibroService.EliminarLibro(libritooo.idlibro);

                    MessageBox.Show(respuesta);
                    this.CargarListBoxLibros();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}"); // Si hay un error, lo mostramos
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un libro para eliminar."); // Si no se ha seleccionado un libro
                return;
            }

        }

        //este boton abre la ventana para editar libro
        private void btnEditarLibro_Click(object sender, EventArgs e)
        {
            Libros libritoMagico = (Libros)listBox1.SelectedItem;
            
            EditarLibro editarLibro = new EditarLibro(this.usuario, libritoMagico.idlibro);
            editarLibro.Show();
            this.Hide();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //este metodo sirve para agregar un libro
        private async void btnAñadirLibro_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                    string.IsNullOrWhiteSpace(txtAutor.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPortada.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Por favor, llena todos los campos solicitados para tu registro.");
                    return;
                }

                // Validar que el precio sea un número válido
                if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Por favor, ingresa un precio válido (mayor o igual a 0).");
                    return;
                }

                // Validar que se haya seleccionado un género
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un género.");
                    return;
                }

                // Obtener el género seleccionado y asignar su ID
                int idGenero = 0;
                string generoSeleccionado = comboBox1.SelectedItem.ToString();

                if (generoSeleccionado.Equals("Ciencia ficcion", StringComparison.OrdinalIgnoreCase))
                {
                    idGenero = 1;
                }
                else if (generoSeleccionado.Equals("Fantasia", StringComparison.OrdinalIgnoreCase))
                {
                    idGenero = 2;
                }
                else if (generoSeleccionado.Equals("Romance", StringComparison.OrdinalIgnoreCase))
                {
                    idGenero = 3;
                }
                else
                {
                    idGenero = 4; // Género por defecto si no coincide con los anteriores
                }

                // Crear el objeto de solicitud
                LibrosRequest libro = new LibrosRequest
                {
                    titulo = txtTitulo.Text.Trim(),
                    autor = txtAutor.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    urlPortada = txtPortada.Text.Trim(),
                    precio = precio,
                    idgenero = idGenero
                };

                // Llamar al servicio para agregar el libro
                var respuesta = await libroService.IngresarLibro(libro);

                // Validar la respuesta del servicio
                if (respuesta != null && !string.IsNullOrWhiteSpace(respuesta.Titulo))
                {
                    MessageBox.Show($"{respuesta.Titulo}\n{respuesta.Mensaje}");
                    CargarListBoxLibros(); // Actualizar la lista de libros
                }
                else
                {
                    MessageBox.Show("Error al agregar el libro. Revisa la información e intenta de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


    }
}
