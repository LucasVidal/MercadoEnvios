namespace MercadoEnvio.Facturas
{
    partial class buscar_facturas
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
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.groupBox_paginas = new System.Windows.Forms.GroupBox();
            this.btn_primera_pagina = new System.Windows.Forms.Button();
            this.btn_ultima_pagina = new System.Windows.Forms.Button();
            this.btn_anterior = new System.Windows.Forms.Button();
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.labelNrosDePagina = new System.Windows.Forms.Label();
            this.groupBox_filtro = new System.Windows.Forms.GroupBox();
            this.factura_numero = new System.Windows.Forms.NumericUpDown();
            this.monto_hasta = new System.Windows.Forms.NumericUpDown();
            this.monto_desde = new System.Windows.Forms.NumericUpDown();
            this.dateTime_hasta = new System.Windows.Forms.DateTimePicker();
            this.dateTime_desde = new System.Windows.Forms.DateTimePicker();
            this.numero = new System.Windows.Forms.Label();
            this.label_item = new System.Windows.Forms.Label();
            this.comboBox_item = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_fecha = new System.Windows.Forms.Label();
            this.label_usuario = new System.Windows.Forms.Label();
            this.comboBox_usuario = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ver_Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox_paginas.SuspendLayout();
            this.groupBox_filtro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factura_numero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monto_hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monto_desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(12, 176);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 14;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(130, 176);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 13;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // groupBox_paginas
            // 
            this.groupBox_paginas.Controls.Add(this.btn_primera_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_ultima_pagina);
            this.groupBox_paginas.Controls.Add(this.btn_anterior);
            this.groupBox_paginas.Controls.Add(this.btn_siguiente);
            this.groupBox_paginas.Location = new System.Drawing.Point(166, 392);
            this.groupBox_paginas.Name = "groupBox_paginas";
            this.groupBox_paginas.Size = new System.Drawing.Size(506, 67);
            this.groupBox_paginas.TabIndex = 15;
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
            this.btn_primera_pagina.Click += new System.EventHandler(this.btn_primera_pagina_Click);
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
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // labelNrosDePagina
            // 
            this.labelNrosDePagina.AutoSize = true;
            this.labelNrosDePagina.Location = new System.Drawing.Point(9, 440);
            this.labelNrosDePagina.Name = "labelNrosDePagina";
            this.labelNrosDePagina.Size = new System.Drawing.Size(60, 13);
            this.labelNrosDePagina.TabIndex = 18;
            this.labelNrosDePagina.Text = "Pagina 0/0";
            // 
            // groupBox_filtro
            // 
            this.groupBox_filtro.Controls.Add(this.factura_numero);
            this.groupBox_filtro.Controls.Add(this.monto_hasta);
            this.groupBox_filtro.Controls.Add(this.monto_desde);
            this.groupBox_filtro.Controls.Add(this.dateTime_hasta);
            this.groupBox_filtro.Controls.Add(this.dateTime_desde);
            this.groupBox_filtro.Controls.Add(this.numero);
            this.groupBox_filtro.Controls.Add(this.label_item);
            this.groupBox_filtro.Controls.Add(this.comboBox_item);
            this.groupBox_filtro.Controls.Add(this.label3);
            this.groupBox_filtro.Controls.Add(this.label4);
            this.groupBox_filtro.Controls.Add(this.label_total);
            this.groupBox_filtro.Controls.Add(this.label2);
            this.groupBox_filtro.Controls.Add(this.label1);
            this.groupBox_filtro.Controls.Add(this.label_fecha);
            this.groupBox_filtro.Controls.Add(this.label_usuario);
            this.groupBox_filtro.Controls.Add(this.comboBox_usuario);
            this.groupBox_filtro.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtro.Name = "groupBox_filtro";
            this.groupBox_filtro.Size = new System.Drawing.Size(660, 155);
            this.groupBox_filtro.TabIndex = 17;
            this.groupBox_filtro.TabStop = false;
            this.groupBox_filtro.Text = "Condiciones de busqueda";
            this.groupBox_filtro.Enter += new System.EventHandler(this.groupBox_filtro_Enter);
            // 
            // factura_numero
            // 
            this.factura_numero.Location = new System.Drawing.Point(123, 23);
            this.factura_numero.Name = "factura_numero";
            this.factura_numero.Size = new System.Drawing.Size(121, 20);
            this.factura_numero.TabIndex = 140;
            // 
            // monto_hasta
            // 
            this.monto_hasta.Location = new System.Drawing.Point(297, 75);
            this.monto_hasta.Name = "monto_hasta";
            this.monto_hasta.Size = new System.Drawing.Size(121, 20);
            this.monto_hasta.TabIndex = 139;
            // 
            // monto_desde
            // 
            this.monto_desde.Location = new System.Drawing.Point(123, 75);
            this.monto_desde.Name = "monto_desde";
            this.monto_desde.Size = new System.Drawing.Size(121, 20);
            this.monto_desde.TabIndex = 138;
            // 
            // dateTime_hasta
            // 
            this.dateTime_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_hasta.Location = new System.Drawing.Point(297, 49);
            this.dateTime_hasta.Name = "dateTime_hasta";
            this.dateTime_hasta.Size = new System.Drawing.Size(121, 20);
            this.dateTime_hasta.TabIndex = 19;
            this.dateTime_hasta.ValueChanged += new System.EventHandler(this.dateTime_hasta_ValueChanged);
            // 
            // dateTime_desde
            // 
            this.dateTime_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_desde.Location = new System.Drawing.Point(123, 49);
            this.dateTime_desde.Name = "dateTime_desde";
            this.dateTime_desde.Size = new System.Drawing.Size(121, 20);
            this.dateTime_desde.TabIndex = 18;
            this.dateTime_desde.ValueChanged += new System.EventHandler(this.dateTime_desde_ValueChanged);
            // 
            // numero
            // 
            this.numero.AutoSize = true;
            this.numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero.Location = new System.Drawing.Point(16, 25);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(101, 13);
            this.numero.TabIndex = 16;
            this.numero.Text = "Factura Número:";
            // 
            // label_item
            // 
            this.label_item.AutoSize = true;
            this.label_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_item.Location = new System.Drawing.Point(17, 104);
            this.label_item.Name = "label_item";
            this.label_item.Size = new System.Drawing.Size(35, 13);
            this.label_item.TabIndex = 14;
            this.label_item.Text = "Item:";
            // 
            // comboBox_item
            // 
            this.comboBox_item.FormattingEnabled = true;
            this.comboBox_item.Location = new System.Drawing.Point(123, 101);
            this.comboBox_item.Name = "comboBox_item";
            this.comboBox_item.Size = new System.Drawing.Size(180, 21);
            this.comboBox_item.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desde:";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total.Location = new System.Drawing.Point(17, 78);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(40, 13);
            this.label_total.TabIndex = 9;
            this.label_total.Text = "Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde:";
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fecha.Location = new System.Drawing.Point(16, 52);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(46, 13);
            this.label_fecha.TabIndex = 2;
            this.label_fecha.Text = "Fecha:";
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.Location = new System.Drawing.Point(17, 131);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(54, 13);
            this.label_usuario.TabIndex = 3;
            this.label_usuario.Text = "Usuario:";
            // 
            // comboBox_usuario
            // 
            this.comboBox_usuario.FormattingEnabled = true;
            this.comboBox_usuario.Location = new System.Drawing.Point(123, 128);
            this.comboBox_usuario.Name = "comboBox_usuario";
            this.comboBox_usuario.Size = new System.Drawing.Size(180, 21);
            this.comboBox_usuario.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ver_Detalle});
            this.dataGridView1.Location = new System.Drawing.Point(12, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 182);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ver_Detalle
            // 
            this.ver_Detalle.HeaderText = "Ver Detalle";
            this.ver_Detalle.Name = "ver_Detalle";
            this.ver_Detalle.Text = "Ver Detalle";
            this.ver_Detalle.UseColumnTextForButtonValue = true;
            // 
            // buscar_facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 462);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.groupBox_paginas);
            this.Controls.Add(this.labelNrosDePagina);
            this.Controls.Add(this.groupBox_filtro);
            this.Controls.Add(this.dataGridView1);
            this.Name = "buscar_facturas";
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.buscar_facturas_Load);
            this.groupBox_paginas.ResumeLayout(false);
            this.groupBox_filtro.ResumeLayout(false);
            this.groupBox_filtro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factura_numero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monto_hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monto_desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.GroupBox groupBox_paginas;
        private System.Windows.Forms.Button btn_primera_pagina;
        private System.Windows.Forms.Button btn_ultima_pagina;
        private System.Windows.Forms.Button btn_anterior;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.Label labelNrosDePagina;
        private System.Windows.Forms.GroupBox groupBox_filtro;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.ComboBox comboBox_usuario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_item;
        private System.Windows.Forms.ComboBox comboBox_item;
        private System.Windows.Forms.DataGridViewButtonColumn ver_Detalle;
        private System.Windows.Forms.Label numero;
        private System.Windows.Forms.DateTimePicker dateTime_desde;
        private System.Windows.Forms.DateTimePicker dateTime_hasta;
        private System.Windows.Forms.NumericUpDown monto_hasta;
        private System.Windows.Forms.NumericUpDown monto_desde;
        private System.Windows.Forms.NumericUpDown factura_numero;
    }
}