namespace ProyectoSemestral
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditarLibro = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAñadirLibro = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPortada = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbxUsuarios = new System.Windows.Forms.ListBox();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a Librery Corp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Explora nuestro catálogo y descubre nuevas historias";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(592, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(192, 274);
            this.listBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Titulo del libro:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnEditarLibro
            // 
            this.btnEditarLibro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarLibro.Location = new System.Drawing.Point(592, 358);
            this.btnEditarLibro.Name = "btnEditarLibro";
            this.btnEditarLibro.Size = new System.Drawing.Size(192, 36);
            this.btnEditarLibro.TabIndex = 4;
            this.btnEditarLibro.Text = "Editar libro";
            this.btnEditarLibro.UseVisualStyleBackColor = true;
            this.btnEditarLibro.Click += new System.EventHandler(this.btnEditarLibro_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(15, 130);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(160, 20);
            this.txtTitulo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Añadir libro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Autor:";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(15, 188);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(160, 20);
            this.txtAutor.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(202, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Género:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ficción",
            "Ciencia ficción",
            "Románce",
            "Misterio",
            "Fantasia"});
            this.comboBox1.Location = new System.Drawing.Point(205, 266);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // btnAñadirLibro
            // 
            this.btnAñadirLibro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirLibro.Location = new System.Drawing.Point(15, 358);
            this.btnAñadirLibro.Name = "btnAñadirLibro";
            this.btnAñadirLibro.Size = new System.Drawing.Size(353, 78);
            this.btnAñadirLibro.TabIndex = 13;
            this.btnAñadirLibro.Text = "Guardar libro";
            this.btnAñadirLibro.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "URL portada del libro:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(692, 26);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 18);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "TextoLindo";
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(7, 6);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(55, 30);
            this.BtnBack.TabIndex = 18;
            this.BtnBack.Text = " < Atras";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(692, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "Admin";
            // 
            // txtPortada
            // 
            this.txtPortada.Location = new System.Drawing.Point(15, 268);
            this.txtPortada.Name = "txtPortada";
            this.txtPortada.Size = new System.Drawing.Size(160, 20);
            this.txtPortada.TabIndex = 20;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(205, 126);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(163, 20);
            this.txtPrecio.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(202, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Precio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(202, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(205, 190);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(163, 20);
            this.txtDescripcion.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(592, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 36);
            this.button1.TabIndex = 25;
            this.button1.Text = "Eliminar libro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbxUsuarios
            // 
            this.lbxUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxUsuarios.FormattingEnabled = true;
            this.lbxUsuarios.ItemHeight = 18;
            this.lbxUsuarios.Location = new System.Drawing.Point(394, 66);
            this.lbxUsuarios.Name = "lbxUsuarios";
            this.lbxUsuarios.Size = new System.Drawing.Size(192, 274);
            this.lbxUsuarios.TabIndex = 26;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarUsuario.Location = new System.Drawing.Point(394, 358);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(192, 36);
            this.btnEditarUsuario.TabIndex = 27;
            this.btnEditarUsuario.Text = "Editar usuario";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(394, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 36);
            this.button3.TabIndex = 28;
            this.button3.Text = "Eliminar usuario";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.lbxUsuarios);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtPortada);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAñadirLibro);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnEditarLibro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditarLibro;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAñadirLibro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPortada;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbxUsuarios;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button button3;
    }
}