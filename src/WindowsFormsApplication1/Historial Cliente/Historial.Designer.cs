namespace MercadoEnvio.Historial_Cliente
{
    partial class Historial
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Titulo = new System.Windows.Forms.Label();
            this.groupBox_filtro = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ofertas = new System.Windows.Forms.Button();
            this.btn_compras = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox_paginas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_filtro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_paginas
            // 
            this.groupBox_paginas.Controls.Add(this.btn_primera_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_ultima_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_anterior);
            this.groupBox_paginas.Controls.Add(this.btn_siguiente);
            this.groupBox_paginas.Controls.Add(this.btn_limpiar);
            this.groupBox_paginas.Location = new System.Drawing.Point(166, 332);
            this.groupBox_paginas.Name = "groupBox_paginas";
            this.groupBox_paginas.Size = new System.Drawing.Size(542, 51);
            this.groupBox_paginas.TabIndex = 19;
            this.groupBox_paginas.TabStop = false;
            this.groupBox_paginas.Text = "Controles de navegacion";
            // 
            // btn_primera_pagina
            // 
            this.btn_primera_pagina.Location = new System.Drawing.Point(5, 19);
            this.btn_primera_pagina.Name = "btn_primera_pagina";
            this.btn_primera_pagina.Size = new System.Drawing.Size(75, 23);
            this.btn_primera_pagina.TabIndex = 9;
            this.btn_primera_pagina.Text = "<< Primera";
            this.btn_primera_pagina.UseVisualStyleBackColor = true;
            this.btn_primera_pagina.Click += new System.EventHandler(this.btn_primera_pagina_Click);
            // 
            // btn_ultima_pagina
            // 
            this.btn_ultima_pagina.Location = new System.Drawing.Point(461, 19);
            this.btn_ultima_pagina.Name = "btn_ultima_pagina";
            this.btn_ultima_pagina.Size = new System.Drawing.Size(75, 23);
            this.btn_ultima_pagina.TabIndex = 8;
            this.btn_ultima_pagina.Text = "Ultima >>";
            this.btn_ultima_pagina.UseVisualStyleBackColor = true;
            this.btn_ultima_pagina.Click += new System.EventHandler(this.btn_ultima_pagina_Click);
            // 
            // btn_anterior
            // 
            this.btn_anterior.Location = new System.Drawing.Point(86, 19);
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(75, 23);
            this.btn_anterior.TabIndex = 0;
            this.btn_anterior.Text = "Anterior";
            this.btn_anterior.UseVisualStyleBackColor = true;
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_Click);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.Location = new System.Drawing.Point(386, 19);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(75, 23);
            this.btn_siguiente.TabIndex = 1;
            this.btn_siguiente.Text = "Siguiente";
            this.btn_siguiente.UseVisualStyleBackColor = true;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // labelNrosDePagina
            // 
            this.labelNrosDePagina.AutoSize = true;
            this.labelNrosDePagina.Location = new System.Drawing.Point(9, 361);
            this.labelNrosDePagina.Name = "labelNrosDePagina";
            this.labelNrosDePagina.Size = new System.Drawing.Size(60, 13);
            this.labelNrosDePagina.TabIndex = 21;
            this.labelNrosDePagina.Text = "Pagina 0/0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(696, 230);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(259, 76);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(156, 17);
            this.Titulo.TabIndex = 22;
            this.Titulo.Text = "Compras Realizadas";
            // 
            // groupBox_filtro
            // 
            this.groupBox_filtro.Controls.Add(this.button3);
            this.groupBox_filtro.Controls.Add(this.button2);
            this.groupBox_filtro.Controls.Add(this.button1);
            this.groupBox_filtro.Controls.Add(this.btn_ofertas);
            this.groupBox_filtro.Controls.Add(this.btn_compras);
            this.groupBox_filtro.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtro.Name = "groupBox_filtro";
            this.groupBox_filtro.Size = new System.Drawing.Size(696, 55);
            this.groupBox_filtro.TabIndex = 27;
            this.groupBox_filtro.TabStop = false;
            this.groupBox_filtro.Text = "Condiciones de busqueda";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Resumen de Calificaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Compras no Calificadas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ofertas
            // 
            this.btn_ofertas.Location = new System.Drawing.Point(147, 19);
            this.btn_ofertas.Name = "btn_ofertas";
            this.btn_ofertas.Size = new System.Drawing.Size(135, 23);
            this.btn_ofertas.TabIndex = 9;
            this.btn_ofertas.Text = "Ofertas Realizadas";
            this.btn_ofertas.UseVisualStyleBackColor = true;
            this.btn_ofertas.Click += new System.EventHandler(this.btn_ofertas_Click);
            // 
            // btn_compras
            // 
            this.btn_compras.Location = new System.Drawing.Point(6, 19);
            this.btn_compras.Name = "btn_compras";
            this.btn_compras.Size = new System.Drawing.Size(135, 23);
            this.btn_compras.TabIndex = 8;
            this.btn_compras.Text = "Compras Realizadas";
            this.btn_compras.UseVisualStyleBackColor = true;
            this.btn_compras.Click += new System.EventHandler(this.btn_compras_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(246, 19);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 7;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(579, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Mis Facturas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Ver Detalle";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Text = "Ver Detalle";
            this.Seleccionar.UseColumnTextForButtonValue = true;
            this.Seleccionar.Visible = false;
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 391);
            this.Controls.Add(this.groupBox_filtro);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.groupBox_paginas);
            this.Controls.Add(this.labelNrosDePagina);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Historial";
            this.Text = "Historial Cliente";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.groupBox_paginas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_filtro.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.GroupBox groupBox_filtro;
        private System.Windows.Forms.Button btn_compras;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_ofertas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
    }
}