namespace MercadoEnvio.ComprarOfertar
{
    partial class Buscar_Publicaciones
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
            this.groupBox_paginas = new System.Windows.Forms.GroupBox();
            this.btn_primera_pagina = new System.Windows.Forms.Button();
            this.btn_ultima_pagina = new System.Windows.Forms.Button();
            this.btn_anterior = new System.Windows.Forms.Button();
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.labelNrosDePagina = new System.Windows.Forms.Label();
            this.groupBox_filtro = new System.Windows.Forms.GroupBox();
            this.label_descr = new System.Windows.Forms.Label();
            this.label_rubro = new System.Windows.Forms.Label();
            this.comboBox_rubro = new System.Windows.Forms.ComboBox();
            this.textBox_descr = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ver_Publicacion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox_paginas.SuspendLayout();
            this.groupBox_filtro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_paginas
            // 
            this.groupBox_paginas.Controls.Add(this.btn_primera_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_ultima_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_anterior);
            this.groupBox_paginas.Controls.Add(this.btn_siguiente);
            this.groupBox_paginas.Location = new System.Drawing.Point(166, 291);
            this.groupBox_paginas.Name = "groupBox_paginas";
            this.groupBox_paginas.Size = new System.Drawing.Size(506, 67);
            this.groupBox_paginas.TabIndex = 9;
            this.groupBox_paginas.TabStop = false;
            this.groupBox_paginas.Text = "Controles de navegacion";
            // 
            // btn_primera_pagina
            // 
            this.btn_primera_pagina.Location = new System.Drawing.Point(5, 38);
            this.btn_primera_pagina.Name = "btn_primera_pagina";
            this.btn_primera_pagina.Size = new System.Drawing.Size(75, 23);
            this.btn_primera_pagina.TabIndex = 9;
            this.btn_primera_pagina.Text = "<< Primera";
            this.btn_primera_pagina.UseVisualStyleBackColor = true;
            this.btn_primera_pagina.Click += new System.EventHandler(this.btn_primera_pagina_Click_1);
            // 
            // btn_ultima_pagina
            // 
            this.btn_ultima_pagina.Location = new System.Drawing.Point(419, 38);
            this.btn_ultima_pagina.Name = "btn_ultima_pagina";
            this.btn_ultima_pagina.Size = new System.Drawing.Size(75, 23);
            this.btn_ultima_pagina.TabIndex = 8;
            this.btn_ultima_pagina.Text = "Ultima >>";
            this.btn_ultima_pagina.UseVisualStyleBackColor = true;
            this.btn_ultima_pagina.Click += new System.EventHandler(this.btn_ultima_pagina_Click_1);
            // 
            // btn_anterior
            // 
            this.btn_anterior.Location = new System.Drawing.Point(86, 38);
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(75, 23);
            this.btn_anterior.TabIndex = 0;
            this.btn_anterior.Text = "Anterior";
            this.btn_anterior.UseVisualStyleBackColor = true;
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_Click_1);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.Location = new System.Drawing.Point(344, 38);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(75, 23);
            this.btn_siguiente.TabIndex = 1;
            this.btn_siguiente.Text = "Siguiente";
            this.btn_siguiente.UseVisualStyleBackColor = true;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click_1);
            // 
            // labelNrosDePagina
            // 
            this.labelNrosDePagina.AutoSize = true;
            this.labelNrosDePagina.Location = new System.Drawing.Point(9, 339);
            this.labelNrosDePagina.Name = "labelNrosDePagina";
            this.labelNrosDePagina.Size = new System.Drawing.Size(60, 13);
            this.labelNrosDePagina.TabIndex = 12;
            this.labelNrosDePagina.Text = "Pagina 0/0";
            // 
            // groupBox_filtro
            // 
            this.groupBox_filtro.Controls.Add(this.label_descr);
            this.groupBox_filtro.Controls.Add(this.label_rubro);
            this.groupBox_filtro.Controls.Add(this.comboBox_rubro);
            this.groupBox_filtro.Controls.Add(this.textBox_descr);
            this.groupBox_filtro.Location = new System.Drawing.Point(12, 14);
            this.groupBox_filtro.Name = "groupBox_filtro";
            this.groupBox_filtro.Size = new System.Drawing.Size(660, 55);
            this.groupBox_filtro.TabIndex = 11;
            this.groupBox_filtro.TabStop = false;
            this.groupBox_filtro.Text = "Condiciones de busqueda";
            // 
            // label_descr
            // 
            this.label_descr.AutoSize = true;
            this.label_descr.Location = new System.Drawing.Point(16, 23);
            this.label_descr.Name = "label_descr";
            this.label_descr.Size = new System.Drawing.Size(63, 13);
            this.label_descr.TabIndex = 2;
            this.label_descr.Text = "Descripcion";
            // 
            // label_rubro
            // 
            this.label_rubro.AutoSize = true;
            this.label_rubro.Location = new System.Drawing.Point(349, 25);
            this.label_rubro.Name = "label_rubro";
            this.label_rubro.Size = new System.Drawing.Size(36, 13);
            this.label_rubro.TabIndex = 3;
            this.label_rubro.Text = "Rubro";
            // 
            // comboBox_rubro
            // 
            this.comboBox_rubro.FormattingEnabled = true;
            this.comboBox_rubro.Location = new System.Drawing.Point(391, 22);
            this.comboBox_rubro.Name = "comboBox_rubro";
            this.comboBox_rubro.Size = new System.Drawing.Size(180, 21);
            this.comboBox_rubro.TabIndex = 4;
            // 
            // textBox_descr
            // 
            this.textBox_descr.Location = new System.Drawing.Point(85, 22);
            this.textBox_descr.MaxLength = 254;
            this.textBox_descr.Name = "textBox_descr";
            this.textBox_descr.Size = new System.Drawing.Size(180, 20);
            this.textBox_descr.TabIndex = 5;
            this.textBox_descr.TextChanged += new System.EventHandler(this.textBox_descr_TextChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(12, 75);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 6;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click_1);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(130, 75);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 2;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ver_Publicacion});
            this.dataGridView1.Location = new System.Drawing.Point(12, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 182);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ver_Publicacion
            // 
            this.ver_Publicacion.HeaderText = "Ver Publicacion";
            this.ver_Publicacion.Name = "ver_Publicacion";
            this.ver_Publicacion.Text = "Ver Publicacion";
            this.ver_Publicacion.UseColumnTextForButtonValue = true;
            // 
            // Buscar_Publicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 364);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.groupBox_paginas);
            this.Controls.Add(this.labelNrosDePagina);
            this.Controls.Add(this.groupBox_filtro);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Buscar_Publicaciones";
            this.Text = "Comprar/Ofertar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_paginas.ResumeLayout(false);
            this.groupBox_filtro.ResumeLayout(false);
            this.groupBox_filtro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_paginas;
        private System.Windows.Forms.Button btn_primera_pagina;
        private System.Windows.Forms.Button btn_ultima_pagina;
        private System.Windows.Forms.Button btn_anterior;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.Label labelNrosDePagina;
        private System.Windows.Forms.GroupBox groupBox_filtro;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Label label_descr;
        private System.Windows.Forms.Label label_rubro;
        private System.Windows.Forms.ComboBox comboBox_rubro;
        private System.Windows.Forms.TextBox textBox_descr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn ver_Publicacion;
    }
}