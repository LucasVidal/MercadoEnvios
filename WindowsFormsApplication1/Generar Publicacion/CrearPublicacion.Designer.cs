namespace MercadoEnvio.Generar_Publicación
{
    partial class Publicacion
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
            this.Limpiar = new System.Windows.Forms.Button();
            this.Btn_Crear = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.label_titulo_principal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_envio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_visibilidades = new System.Windows.Forms.ComboBox();
            this.textBox_descr = new System.Windows.Forms.TextBox();
            this.textBox_precio_unidad = new System.Windows.Forms.TextBox();
            this.comboBox_preguntas = new System.Windows.Forms.ComboBox();
            this.comboBox_rubro = new System.Windows.Forms.ComboBox();
            this.comboBox_tipo_publ = new System.Windows.Forms.ComboBox();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.numericUpDown_stock = new System.Windows.Forms.NumericUpDown();
            this.label_rubro = new System.Windows.Forms.Label();
            this.label_descr = new System.Windows.Forms.Label();
            this.label_estado_publ = new System.Windows.Forms.Label();
            this.label_tipo_visibilidad = new System.Windows.Forms.Label();
            this.label_preguntas = new System.Windows.Forms.Label();
            this.label_precio_unidad = new System.Windows.Forms.Label();
            this.label_tipo_publ = new System.Windows.Forms.Label();
            this.label_stock = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stock)).BeginInit();
            this.SuspendLayout();
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(193, 440);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 18;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Btn_Crear
            // 
            this.Btn_Crear.Location = new System.Drawing.Point(355, 440);
            this.Btn_Crear.Name = "Btn_Crear";
            this.Btn_Crear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Crear.TabIndex = 17;
            this.Btn_Crear.Text = "Crear";
            this.Btn_Crear.UseVisualStyleBackColor = true;
            this.Btn_Crear.Click += new System.EventHandler(this.Btn_Crear_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(21, 440);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 16;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // label_titulo_principal
            // 
            this.label_titulo_principal.AutoSize = true;
            this.label_titulo_principal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo_principal.Location = new System.Drawing.Point(178, 9);
            this.label_titulo_principal.Name = "label_titulo_principal";
            this.label_titulo_principal.Size = new System.Drawing.Size(132, 20);
            this.label_titulo_principal.TabIndex = 15;
            this.label_titulo_principal.Text = "Crear Publicacion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_envio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_visibilidades);
            this.groupBox1.Controls.Add(this.textBox_descr);
            this.groupBox1.Controls.Add(this.textBox_precio_unidad);
            this.groupBox1.Controls.Add(this.comboBox_preguntas);
            this.groupBox1.Controls.Add(this.comboBox_rubro);
            this.groupBox1.Controls.Add(this.comboBox_tipo_publ);
            this.groupBox1.Controls.Add(this.comboBox_estado);
            this.groupBox1.Controls.Add(this.numericUpDown_stock);
            this.groupBox1.Controls.Add(this.label_rubro);
            this.groupBox1.Controls.Add(this.label_descr);
            this.groupBox1.Controls.Add(this.label_estado_publ);
            this.groupBox1.Controls.Add(this.label_tipo_visibilidad);
            this.groupBox1.Controls.Add(this.label_preguntas);
            this.groupBox1.Controls.Add(this.label_precio_unidad);
            this.groupBox1.Controls.Add(this.label_tipo_publ);
            this.groupBox1.Controls.Add(this.label_stock);
            this.groupBox1.Location = new System.Drawing.Point(20, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 379);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complete las siguientes opciones por favor";
            // 
            // comboBox_envio
            // 
            this.comboBox_envio.FormattingEnabled = true;
            this.comboBox_envio.Location = new System.Drawing.Point(189, 230);
            this.comboBox_envio.Name = "comboBox_envio";
            this.comboBox_envio.Size = new System.Drawing.Size(193, 21);
            this.comboBox_envio.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Posibilidad De Envio";
            // 
            // comboBox_visibilidades
            // 
            this.comboBox_visibilidades.FormattingEnabled = true;
            this.comboBox_visibilidades.Location = new System.Drawing.Point(190, 111);
            this.comboBox_visibilidades.Name = "comboBox_visibilidades";
            this.comboBox_visibilidades.Size = new System.Drawing.Size(192, 21);
            this.comboBox_visibilidades.TabIndex = 17;
            // 
            // textBox_descr
            // 
            this.textBox_descr.Location = new System.Drawing.Point(114, 264);
            this.textBox_descr.MaxLength = 254;
            this.textBox_descr.MinimumSize = new System.Drawing.Size(196, 100);
            this.textBox_descr.Multiline = true;
            this.textBox_descr.Name = "textBox_descr";
            this.textBox_descr.Size = new System.Drawing.Size(268, 100);
            this.textBox_descr.TabIndex = 13;
            // 
            // textBox_precio_unidad
            // 
            this.textBox_precio_unidad.Location = new System.Drawing.Point(190, 172);
            this.textBox_precio_unidad.MaxLength = 21;
            this.textBox_precio_unidad.Name = "textBox_precio_unidad";
            this.textBox_precio_unidad.Size = new System.Drawing.Size(192, 20);
            this.textBox_precio_unidad.TabIndex = 16;
            // 
            // comboBox_preguntas
            // 
            this.comboBox_preguntas.FormattingEnabled = true;
            this.comboBox_preguntas.Location = new System.Drawing.Point(189, 200);
            this.comboBox_preguntas.Name = "comboBox_preguntas";
            this.comboBox_preguntas.Size = new System.Drawing.Size(193, 21);
            this.comboBox_preguntas.TabIndex = 11;
            // 
            // comboBox_rubro
            // 
            this.comboBox_rubro.FormattingEnabled = true;
            this.comboBox_rubro.Location = new System.Drawing.Point(189, 85);
            this.comboBox_rubro.Name = "comboBox_rubro";
            this.comboBox_rubro.Size = new System.Drawing.Size(193, 21);
            this.comboBox_rubro.TabIndex = 14;
            // 
            // comboBox_tipo_publ
            // 
            this.comboBox_tipo_publ.FormattingEnabled = true;
            this.comboBox_tipo_publ.Location = new System.Drawing.Point(189, 55);
            this.comboBox_tipo_publ.Name = "comboBox_tipo_publ";
            this.comboBox_tipo_publ.Size = new System.Drawing.Size(193, 21);
            this.comboBox_tipo_publ.TabIndex = 15;
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Location = new System.Drawing.Point(189, 28);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(193, 21);
            this.comboBox_estado.TabIndex = 12;
            // 
            // numericUpDown_stock
            // 
            this.numericUpDown_stock.Location = new System.Drawing.Point(190, 142);
            this.numericUpDown_stock.Name = "numericUpDown_stock";
            this.numericUpDown_stock.Size = new System.Drawing.Size(192, 20);
            this.numericUpDown_stock.TabIndex = 11;
            // 
            // label_rubro
            // 
            this.label_rubro.AutoSize = true;
            this.label_rubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rubro.Location = new System.Drawing.Point(21, 84);
            this.label_rubro.Name = "label_rubro";
            this.label_rubro.Size = new System.Drawing.Size(49, 18);
            this.label_rubro.TabIndex = 1;
            this.label_rubro.Text = "Rubro";
            // 
            // label_descr
            // 
            this.label_descr.AutoSize = true;
            this.label_descr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_descr.Location = new System.Drawing.Point(21, 263);
            this.label_descr.Name = "label_descr";
            this.label_descr.Size = new System.Drawing.Size(87, 18);
            this.label_descr.TabIndex = 0;
            this.label_descr.Text = "Descripcion";
            // 
            // label_estado_publ
            // 
            this.label_estado_publ.AutoSize = true;
            this.label_estado_publ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_estado_publ.Location = new System.Drawing.Point(21, 27);
            this.label_estado_publ.Name = "label_estado_publ";
            this.label_estado_publ.Size = new System.Drawing.Size(135, 18);
            this.label_estado_publ.TabIndex = 8;
            this.label_estado_publ.Text = "Estado Publicacion";
            // 
            // label_tipo_visibilidad
            // 
            this.label_tipo_visibilidad.AutoSize = true;
            this.label_tipo_visibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tipo_visibilidad.Location = new System.Drawing.Point(21, 114);
            this.label_tipo_visibilidad.Name = "label_tipo_visibilidad";
            this.label_tipo_visibilidad.Size = new System.Drawing.Size(72, 18);
            this.label_tipo_visibilidad.TabIndex = 2;
            this.label_tipo_visibilidad.Text = "Visibilidad";
            // 
            // label_preguntas
            // 
            this.label_preguntas.AutoSize = true;
            this.label_preguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_preguntas.Location = new System.Drawing.Point(20, 203);
            this.label_preguntas.Name = "label_preguntas";
            this.label_preguntas.Size = new System.Drawing.Size(130, 18);
            this.label_preguntas.TabIndex = 7;
            this.label_preguntas.Text = "Permite Preguntas";
            // 
            // label_precio_unidad
            // 
            this.label_precio_unidad.AutoSize = true;
            this.label_precio_unidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_precio_unidad.Location = new System.Drawing.Point(21, 174);
            this.label_precio_unidad.Name = "label_precio_unidad";
            this.label_precio_unidad.Size = new System.Drawing.Size(51, 18);
            this.label_precio_unidad.TabIndex = 6;
            this.label_precio_unidad.Text = "Precio";
            // 
            // label_tipo_publ
            // 
            this.label_tipo_publ.AutoSize = true;
            this.label_tipo_publ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tipo_publ.Location = new System.Drawing.Point(21, 54);
            this.label_tipo_publ.Name = "label_tipo_publ";
            this.label_tipo_publ.Size = new System.Drawing.Size(37, 18);
            this.label_tipo_publ.TabIndex = 4;
            this.label_tipo_publ.Text = "Tipo";
            // 
            // label_stock
            // 
            this.label_stock.AutoSize = true;
            this.label_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stock.Location = new System.Drawing.Point(21, 142);
            this.label_stock.Name = "label_stock";
            this.label_stock.Size = new System.Drawing.Size(47, 18);
            this.label_stock.TabIndex = 5;
            this.label_stock.Text = "Stock";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 471);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Btn_Crear);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.label_titulo_principal);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Publicacion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Btn_Crear;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Label label_titulo_principal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_envio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_visibilidades;
        private System.Windows.Forms.TextBox textBox_descr;
        private System.Windows.Forms.TextBox textBox_precio_unidad;
        private System.Windows.Forms.ComboBox comboBox_preguntas;
        private System.Windows.Forms.ComboBox comboBox_rubro;
        private System.Windows.Forms.ComboBox comboBox_tipo_publ;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.NumericUpDown numericUpDown_stock;
        private System.Windows.Forms.Label label_rubro;
        private System.Windows.Forms.Label label_descr;
        private System.Windows.Forms.Label label_estado_publ;
        private System.Windows.Forms.Label label_tipo_visibilidad;
        private System.Windows.Forms.Label label_preguntas;
        private System.Windows.Forms.Label label_precio_unidad;
        private System.Windows.Forms.Label label_tipo_publ;
        private System.Windows.Forms.Label label_stock;
    }
}