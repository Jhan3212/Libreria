using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSemestral
{
    public partial class Form2 : Form
    {
        private string usuario;
        public Form2(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Configurar la ruta inicial basada en el directorio de inicio de la aplicación
                ofd.InitialDirectory = Application.StartupPath + @"\ImgPortadas";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Cargar la imagen seleccionada en el PictureBox
                        pbxPortada.Image = Image.FromFile(ofd.FileName);

                        // Ajustar la imagen para que se ajuste al tamaño del PictureBox
                        pbxPortada.SizeMode = PictureBoxSizeMode.StretchImage;

                        MessageBox.Show("Imagen cargada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
