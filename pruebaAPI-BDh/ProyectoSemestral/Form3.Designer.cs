namespace ProyectoSemestral
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.lbxLibrosDisponibles = new System.Windows.Forms.ListBox();
            this.btnVerInfoLibro = new System.Windows.Forms.Button();
            this.btnComprarLibro = new System.Windows.Forms.Button();
            this.lbxTusLibros = new System.Windows.Forms.ListBox();
            this.btnInfoC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVenderLibro = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxLibrosDisponibles
            // 
            this.lbxLibrosDisponibles.FormattingEnabled = true;
            this.lbxLibrosDisponibles.ItemHeight = 24;
            this.lbxLibrosDisponibles.Location = new System.Drawing.Point(1047, 94);
            this.lbxLibrosDisponibles.Margin = new System.Windows.Forms.Padding(6);
            this.lbxLibrosDisponibles.Name = "lbxLibrosDisponibles";
            this.lbxLibrosDisponibles.Size = new System.Drawing.Size(394, 556);
            this.lbxLibrosDisponibles.TabIndex = 0;
            this.lbxLibrosDisponibles.SelectedIndexChanged += new System.EventHandler(this.lbxLibrosDisponibles_SelectedIndexChanged);
            // 
            // btnVerInfoLibro
            // 
            this.btnVerInfoLibro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInfoLibro.Location = new System.Drawing.Point(1047, 665);
            this.btnVerInfoLibro.Margin = new System.Windows.Forms.Padding(6);
            this.btnVerInfoLibro.Name = "btnVerInfoLibro";
            this.btnVerInfoLibro.Size = new System.Drawing.Size(398, 66);
            this.btnVerInfoLibro.TabIndex = 1;
            this.btnVerInfoLibro.Text = "Ver información del libro";
            this.btnVerInfoLibro.UseVisualStyleBackColor = true;
            this.btnVerInfoLibro.Click += new System.EventHandler(this.btnVerInfoLibro_Click);
            // 
            // btnComprarLibro
            // 
            this.btnComprarLibro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprarLibro.Location = new System.Drawing.Point(1047, 742);
            this.btnComprarLibro.Margin = new System.Windows.Forms.Padding(6);
            this.btnComprarLibro.Name = "btnComprarLibro";
            this.btnComprarLibro.Size = new System.Drawing.Size(398, 66);
            this.btnComprarLibro.TabIndex = 2;
            this.btnComprarLibro.Text = "Comprar libro";
            this.btnComprarLibro.UseVisualStyleBackColor = true;
            this.btnComprarLibro.Click += new System.EventHandler(this.btnComprarLibro_Click);
            // 
            // lbxTusLibros
            // 
            this.lbxTusLibros.FormattingEnabled = true;
            this.lbxTusLibros.ItemHeight = 24;
            this.lbxTusLibros.Location = new System.Drawing.Point(638, 94);
            this.lbxTusLibros.Margin = new System.Windows.Forms.Padding(6);
            this.lbxTusLibros.Name = "lbxTusLibros";
            this.lbxTusLibros.Size = new System.Drawing.Size(394, 556);
            this.lbxTusLibros.TabIndex = 3;
            this.lbxTusLibros.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnInfoC
            // 
            this.btnInfoC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoC.Location = new System.Drawing.Point(638, 665);
            this.btnInfoC.Margin = new System.Windows.Forms.Padding(6);
            this.btnInfoC.Name = "btnInfoC";
            this.btnInfoC.Size = new System.Drawing.Size(398, 66);
            this.btnInfoC.TabIndex = 4;
            this.btnInfoC.Text = "Ver información de tú libro";
            this.btnInfoC.UseVisualStyleBackColor = true;
            this.btnInfoC.Click += new System.EventHandler(this.btnInfoC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(557, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "!Bienvenido a Librery Corp¡";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Explora nuestro catalogo y descubre nuevas aventuras";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(22, 22);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(6);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(138, 42);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.Text = "< Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "!Bienvenido¡";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(22, 155);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(193, 27);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Nombre Usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(528, 135);
            this.label5.TabIndex = 10;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // btnVenderLibro
            // 
            this.btnVenderLibro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenderLibro.Location = new System.Drawing.Point(634, 743);
            this.btnVenderLibro.Margin = new System.Windows.Forms.Padding(6);
            this.btnVenderLibro.Name = "btnVenderLibro";
            this.btnVenderLibro.Size = new System.Drawing.Size(398, 66);
            this.btnVenderLibro.TabIndex = 11;
            this.btnVenderLibro.Text = "Vender libro";
            this.btnVenderLibro.UseVisualStyleBackColor = true;
            this.btnVenderLibro.Click += new System.EventHandler(this.btnVenderLibro_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarUsuario.Location = new System.Drawing.Point(123, 548);
            this.btnEditarUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(352, 66);
            this.btnEditarUsuario.TabIndex = 28;
            this.btnEditarUsuario.Text = "Editar usuario";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 498);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(529, 27);
            this.label4.TabIndex = 29;
            this.label4.Text = "No te gusta tu usuario?, cambialo si tu deseas\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnVenderLibro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInfoC);
            this.Controls.Add(this.lbxTusLibros);
            this.Controls.Add(this.btnComprarLibro);
            this.Controls.Add(this.btnVerInfoLibro);
            this.Controls.Add(this.lbxLibrosDisponibles);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxLibrosDisponibles;
        private System.Windows.Forms.Button btnVerInfoLibro;
        private System.Windows.Forms.Button btnComprarLibro;
        private System.Windows.Forms.ListBox lbxTusLibros;
        private System.Windows.Forms.Button btnInfoC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVenderLibro;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Label label4;
    }
}