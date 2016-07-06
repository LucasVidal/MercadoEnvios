namespace MercadoEnvio.ALTA_Visibilidad
{
    partial class Alta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.porcentaje = new System.Windows.Forms.NumericUpDown();
            this.envio = new System.Windows.Forms.NumericUpDown();
            this.ordenamiento = new System.Windows.Forms.NumericUpDown();
            this.costo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.porcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.envio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costo)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Costo de Envio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Grado de ordenamiento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 108;
            this.label13.Text = "Costo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Nombre:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(136, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(119, 20);
            this.textBox4.TabIndex = 105;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "Porcentaje:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 102;
            this.checkBox1.Text = "Tiene Envio";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 101;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "ID:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 99;
            this.button3.Text = "GUARDAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 98;
            this.button2.Text = "ELIMINAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 97;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // porcentaje
            // 
            this.porcentaje.Location = new System.Drawing.Point(139, 95);
            this.porcentaje.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(119, 20);
            this.porcentaje.TabIndex = 140;
            // 
            // envio
            // 
            this.envio.Location = new System.Drawing.Point(198, 147);
            this.envio.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.envio.Name = "envio";
            this.envio.Size = new System.Drawing.Size(60, 20);
            this.envio.TabIndex = 141;
            // 
            // ordenamiento
            // 
            this.ordenamiento.Location = new System.Drawing.Point(139, 69);
            this.ordenamiento.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.ordenamiento.Name = "ordenamiento";
            this.ordenamiento.Size = new System.Drawing.Size(119, 20);
            this.ordenamiento.TabIndex = 142;
            // 
            // costo
            // 
            this.costo.Location = new System.Drawing.Point(139, 121);
            this.costo.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.costo.Name = "costo";
            this.costo.Size = new System.Drawing.Size(119, 20);
            this.costo.TabIndex = 143;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 241);
            this.Controls.Add(this.costo);
            this.Controls.Add(this.ordenamiento);
            this.Controls.Add(this.envio);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Alta";
            this.Text = "Alta";
            this.Load += new System.EventHandler(this.Alta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.porcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown porcentaje;
        private System.Windows.Forms.NumericUpDown envio;
        private System.Windows.Forms.NumericUpDown ordenamiento;
        private System.Windows.Forms.NumericUpDown costo;
    }
}