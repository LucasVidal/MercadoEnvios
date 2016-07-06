namespace MercadoEnvio.Calificar
{
    partial class Realizar_Calificacion
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
            this.comentario = new System.Windows.Forms.RichTextBox();
            this.restantes = new System.Windows.Forms.Label();
            this.comboBox_estrellas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Btn_Crear = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comentario
            // 
            this.comentario.Location = new System.Drawing.Point(12, 78);
            this.comentario.MaxLength = 255;
            this.comentario.Name = "comentario";
            this.comentario.Size = new System.Drawing.Size(397, 119);
            this.comentario.TabIndex = 0;
            this.comentario.Text = "";
            this.comentario.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // restantes
            // 
            this.restantes.AutoSize = true;
            this.restantes.Enabled = false;
            this.restantes.Location = new System.Drawing.Point(281, 200);
            this.restantes.Name = "restantes";
            this.restantes.Size = new System.Drawing.Size(128, 13);
            this.restantes.TabIndex = 1;
            this.restantes.Text = "Caracteres restantes: 255";
            // 
            // comboBox_estrellas
            // 
            this.comboBox_estrellas.FormattingEnabled = true;
            this.comboBox_estrellas.Location = new System.Drawing.Point(180, 39);
            this.comboBox_estrellas.Name = "comboBox_estrellas";
            this.comboBox_estrellas.Size = new System.Drawing.Size(193, 21);
            this.comboBox_estrellas.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Calificación deseada:";
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(178, 241);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 24;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Btn_Crear
            // 
            this.Btn_Crear.Location = new System.Drawing.Point(340, 241);
            this.Btn_Crear.Name = "Btn_Crear";
            this.Btn_Crear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Crear.TabIndex = 23;
            this.Btn_Crear.Text = "Aceptar";
            this.Btn_Crear.UseVisualStyleBackColor = true;
            this.Btn_Crear.Click += new System.EventHandler(this.Btn_Crear_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(6, 241);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 22;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(122, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(13, 20);
            this.Titulo.TabIndex = 68;
            this.Titulo.Text = " ";
            // 
            // Realizar_Calificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 270);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Btn_Crear);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.comboBox_estrellas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restantes);
            this.Controls.Add(this.comentario);
            this.Name = "Realizar_Calificacion";
            this.Text = "Realizar Calificación";
            this.Load += new System.EventHandler(this.Realizar_Calificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox comentario;
        private System.Windows.Forms.Label restantes;
        private System.Windows.Forms.ComboBox comboBox_estrellas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Btn_Crear;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Label Titulo;
    }
}