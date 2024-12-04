using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using ProyectoSemestral.Models;
using ProyectoSemestral.Services;
using System.Security.Policy;
using System.IO;

namespace ProyectoSemestral
{
    public partial class Form3 : Form
    {
        private string usuario;
        private List<Cliente> cliente;
        private LibroService libroService;

        public Form3(string usuario, List<Cliente> cliente)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.cliente = new List<Cliente>();
            this.cliente = cliente;
            libroService = new LibroService(); 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario;

            this.CargarListBoxLibros();

            this.CargarMisLibros();
        }




        //metodo para cargar la listbox
        private async void CargarListBoxLibros()
        {
            var libros = await libroService.ObtenerTodosLosLibros();

            lbxLibrosDisponibles.Items.Clear();
            foreach (var libro in libros)
            {
                lbxLibrosDisponibles.Items.Add(libro);
            }
        }

        //metodo para cargar la listbox de los libros del cliente

        private void CargarMisLibros()
        {
            lbxTusLibros.Items.Clear(); // Limpiar los elementos previos del ListBox

            // Aquí recorres los libros del cliente (suponiendo que 'cliente' es una lista de objetos Cliente)
            foreach (var cli in cliente)
            {
                // Aquí recorres los libros del cliente
                foreach (var libro in cli.libros)
                {
                    lbxTusLibros.Items.Add(libro); // Agregar cada libro del cliente al ListBox
                }
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnInfoC_Click(object sender, EventArgs e)
        {
            // Obtener el objeto seleccionado de los libros del cliente
            Libros libroSeleccionado = (Libros)lbxTusLibros.SelectedItem;

            if (libroSeleccionado != null)
            {
                string generito;
                if (libroSeleccionado.idgenero == 1)
                {
                    generito = "Ciencia ficcion";
                }
                else if (libroSeleccionado.idgenero == 2)
                {
                    generito = "Fantasia";
                }
                else if (libroSeleccionado.idgenero == 3)
                {
                    generito = "Romance";
                }
                else 
                {
                    generito = "Misterio";
                }
                MessageBox.Show("Informacion del Libro " + libroSeleccionado.titulo + "\n\n" +
                    "Autor: " + libroSeleccionado.autor + "\nPrecio: " + libroSeleccionado.precio + "\n" +
                    "Genero: "+ generito + "\n"+ "Url Portada: " + libroSeleccionado.urlPortada + "\n" +
                    "Sinopsis: " + libroSeleccionado.Descripcion);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un libro.");
            }
        }

        private void btnVerInfoLibro_Click(object sender, EventArgs e)
        {
            // Obtener el objeto seleccionado de listbox libros disponibles
            Libros libroSeleccionado = (Libros)lbxLibrosDisponibles.SelectedItem;

            if (libroSeleccionado != null)
            {
                string generito;
                if (libroSeleccionado.idgenero == 1)
                {
                    generito = "Ciencia ficcion";
                }
                else if (libroSeleccionado.idgenero == 2)
                {
                    generito = "Fantasia";
                }
                else if (libroSeleccionado.idgenero == 3)
                {
                    generito = "Romance";
                }
                else
                {
                    generito = "Misterio";
                }
                MessageBox.Show("Informacion del Libro " + libroSeleccionado.titulo + "\n\n" +
                    "Autor: " + libroSeleccionado.autor + "\nPrecio: " + libroSeleccionado.precio + "\n" +
                    "Genero: " + generito + "\n" + "Url Portada: " + libroSeleccionado.urlPortada + "\n" +
                    "Sinopsis: " + libroSeleccionado.Descripcion);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un libro.");
            }
        }

        private async void btnVenderLibro_Click(object sender, EventArgs e)
        {

            try
            {
                Libros libroseleccionado = (Libros)lbxTusLibros.SelectedItem;

                if (libroseleccionado == null)
                {
                    MessageBox.Show("Por favor, selecciona un libro.");
                    return;
                }

                var respuesta = await libroService.VenderLibroAsync(libroseleccionado.idlibro);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            
        }

        private async void btnComprarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el libro seleccionado
                Libros libroSeleccionado = (Libros)lbxLibrosDisponibles.SelectedItem;

                if (libroSeleccionado == null)
                {
                    MessageBox.Show("Por favor, selecciona un libro.");
                    return;
                }

                // Obtener el cliente (asumiendo que solo hay un cliente en la lista)
                var clienteSeleccionado = cliente.FirstOrDefault();

                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("No hay un cliente asociado para realizar la compra.");
                    return;
                }

                // Obtener los IDs necesarios
                int _idUser = clienteSeleccionado.idCliente;
                int _idLibro = libroSeleccionado.idlibro;

                // Llamar al servicio para realizar la compra
                var respuesta = await libroService.ComprarLibroAsync(_idUser, _idLibro);

                


                // Mostrar el resultado
                MessageBox.Show("todo salio bien :), libro comprado, vuelve a iniciar sesion para ver tus libros nuevos");
                this.CargarListBoxLibros();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

    }
}
