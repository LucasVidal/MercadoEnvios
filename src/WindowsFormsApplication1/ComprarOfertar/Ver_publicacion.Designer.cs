namespace MercadoEnvio.ComprarOfertar
{
    partial class Ver_publicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.costo_envio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vencimiento = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rubro = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.TextBox();
            this.numericUpDown_cantidad = new System.Windows.Forms.NumericUpDown();
            this.Cantidad = new System.Windows.Forms.Label();
            this.precio = new System.Windows.Forms.NumericUpDown();
            this.calificacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Costo de Envio:";
            // 
            // costo_envio
            // 
            this.costo_envio.Location = new System.Drawing.Point(201, 193);
            this.costo_envio.Name = "costo_envio";
            this.costo_envio.Size = new System.Drawing.Size(55, 20);
            this.costo_envio.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Stock:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(86, 144);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(107, 20);
            this.stock.TabIndex = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 122;
            this.label12.Text = "Descripción:";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(86, 40);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(436, 20);
            this.descripcion.TabIndex = 121;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 120;
            this.label8.Text = "Vencimiento:";
            // 
            // vencimiento
            // 
            this.vencimiento.Location = new System.Drawing.Point(86, 170);
            this.vencimiento.Name = "vencimiento";
            this.vencimiento.Size = new System.Drawing.Size(107, 20);
            this.vencimiento.TabIndex = 119;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 118;
            this.checkBox1.Text = "Tiene Envio";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(86, 11);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(56, 20);
            this.id.TabIndex = 117;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "ID:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(447, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 115;
            this.button3.Text = "Comprar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 113;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 130;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 132;
            this.label5.Text = "Rubro:";
            // 
            // rubro
            // 
            this.rubro.Location = new System.Drawing.Point(86, 66);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(436, 20);
            this.rubro.TabIndex = 131;
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(414, 11);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(108, 20);
            this.usuario.TabIndex = 134;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Usuario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 136;
            this.label7.Text = "Tipo:";
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(86, 92);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(107, 20);
            this.tipo.TabIndex = 135;
            // 
            // numericUpDown_cantidad
            // 
            this.numericUpDown_cantidad.Location = new System.Drawing.Point(86, 219);
            this.numericUpDown_cantidad.Name = "numericUpDown_cantidad";
            this.numericUpDown_cantidad.Size = new System.Drawing.Size(107, 20);
            this.numericUpDown_cantidad.TabIndex = 137;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSize = true;
            this.Cantidad.Location = new System.Drawing.Point(12, 221);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Size = new System.Drawing.Size(52, 13);
            this.Cantidad.TabIndex = 138;
            this.Cantidad.Text = "Cantidad:";
            // 
            // precio
            // 
            this.precio.Location = new System.Drawing.Point(86, 119);
            this.precio.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(107, 20);
            this.precio.TabIndex = 139;
            // 
            // calificacion
            // 
            this.calificacion.Location = new System.Drawing.Point(311, 11);
            this.calificacion.Name = "calificacion";
            this.calificacion.Size = new System.Drawing.Size(25, 20);
            this.calificacion.TabIndex = 141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 140;
            this.label9.Text = "Calificación del Vendedor:";
            // 
            // Ver_publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 290);
            this.Controls.Add(this.calificacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.Cantidad);
            this.Controls.Add(this.numericUpDown_cantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rubro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.costo_envio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vencimiento);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Ver_publicacion";
            this.Text = "Ver_publicacion";
            this.Load += new System.EventHandler(this.Ver_publicacion_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox costo_envio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stock;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox vencimiento;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rubro;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tipo;
        private System.Windows.Forms.NumericUpDown numericUpDown_cantidad;
        private System.Windows.Forms.Label Cantidad;
        private System.Windows.Forms.NumericUpDown precio;
        private System.Windows.Forms.TextBox calificacion;
        private System.Windows.Forms.Label label9;
    }
}