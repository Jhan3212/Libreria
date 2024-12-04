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
            
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarLibro_Click(object sender, EventArgs e)
        {

        }
    }
}
