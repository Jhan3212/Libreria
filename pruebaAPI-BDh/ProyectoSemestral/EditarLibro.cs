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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoSemestral
{
    public partial class EditarLibro : Form
    {
        private string usuario;
        private int _idlibro;
        private LibroService libroService;
        public EditarLibro(string usuario, int _idlibro)
        {
            InitializeComponent();
            this.usuario = usuario;
            this._idlibro = _idlibro;
            this.libroService = new LibroService();
        }

        //boton para guardar los cambios en la base de datos
        private async void button2_Click(object sender, EventArgs e)
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
                if (cbxGeneroLibro.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un género.");
                    return;
                }

                // Obtener el género seleccionado y asignar su ID
                int idGenero = 0;
                string generoSeleccionado = cbxGeneroLibro.SelectedItem.ToString();

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
                var respuesta = await libroService.EditarLibro<ApiRespuesta>(this._idlibro, libro);


                // Validar la respuesta del servicio
                if (respuesta != null && !string.IsNullOrWhiteSpace(respuesta.Titulo))
                {
                    MessageBox.Show($"{respuesta.Titulo}\n{respuesta.Mensaje}");
                    Form2 form2 = new Form2(this.usuario);
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al editar el libro. Revisa la información e intenta de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        

        //boton para retroceder
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.usuario);
            form2.Show();
            this.Hide();
        }
    }
}
