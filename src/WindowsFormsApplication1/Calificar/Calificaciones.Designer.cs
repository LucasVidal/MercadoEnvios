namespace MercadoEnvio.Calificar
{
    partial class Calificaciones
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_calificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Titulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.estrellas_1 = new System.Windows.Forms.TextBox();
            this.estrellas_2 = new System.Windows.Forms.TextBox();
            this.estrellas_3 = new System.Windows.Forms.TextBox();
            this.estrellas_4 = new System.Windows.Forms.TextBox();
            this.estrellas_5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btn_calificar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 152);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_calificar
            // 
            this.btn_calificar.HeaderText = "Calificar";
            this.btn_calificar.Name = "btn_calificar";
            this.btn_calificar.Text = "Calificar";
            this.btn_calificar.UseColumnTextForButtonValue = true;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(249, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(190, 20);
            this.Titulo.TabIndex = 67;
            this.Titulo.Text = "Calificaciones Pendientes";
            this.Titulo.Click += new System.EventHandler(this.Factura_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "Ultimas 5 Calificaciones";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 223);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(660, 158);
            this.dataGridView2.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Total de calificaciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Calificaciones con 1 Estrella:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Calificaciones con 2 Estrellas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Calificaciones con 3 Estrellas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 533);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Calificaciones con 4 Estrellas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 575);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Calificaciones con 5 Estrellas:";
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(147, 487);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(100, 20);
            this.total.TabIndex = 78;
            // 
            // estrellas_1
            // 
            this.estrellas_1.Location = new System.Drawing.Point(432, 402);
            this.estrellas_1.Name = "estrellas_1";
            this.estrellas_1.Size = new System.Drawing.Size(100, 20);
            this.estrellas_1.TabIndex = 79;
            // 
            // estrellas_2
            // 
            this.estrellas_2.Location = new System.Drawing.Point(432, 445);
            this.estrellas_2.Name = "estrellas_2";
            this.estrellas_2.Size = new System.Drawing.Size(100, 20);
            this.estrellas_2.TabIndex = 80;
            // 
            // estrellas_3
            // 
            this.estrellas_3.Location = new System.Drawing.Point(432, 487);
            this.estrellas_3.Name = "estrellas_3";
            this.estrellas_3.Size = new System.Drawing.Size(100, 20);
            this.estrellas_3.TabIndex = 81;
            // 
            // estrellas_4
            // 
            this.estrellas_4.Location = new System.Drawing.Point(432, 530);
            this.estrellas_4.Name = "estrellas_4";
            this.estrellas_4.Size = new System.Drawing.Size(100, 20);
            this.estrellas_4.TabIndex = 82;
            // 
            // estrellas_5
            // 
            this.estrellas_5.Location = new System.Drawing.Point(432, 572);
            this.estrellas_5.Name = "estrellas_5";
            this.estrellas_5.Size = new System.Drawing.Size(100, 20);
            this.estrellas_5.TabIndex = 83;
            // 
            // Calificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 598);
            this.Controls.Add(this.estrellas_5);
            this.Controls.Add(this.estrellas_4);
            this.Controls.Add(this.estrellas_3);
            this.Controls.Add(this.estrellas_2);
            this.Controls.Add(this.estrellas_1);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Calificaciones";
            this.Text = "Calificaciones Pendientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridViewButtonColumn btn_calificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.TextBox estrellas_1;
        private System.Windows.Forms.TextBox estrellas_2;
        private System.Windows.Forms.TextBox estrellas_3;
        private System.Windows.Forms.TextBox estrellas_4;
        private System.Windows.Forms.TextBox estrellas_5;
    }
}