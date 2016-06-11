namespace WindowsFormsApplication1.ABM_Usuario
{
    partial class UserEdit
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
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.nombreTxt = new System.Windows.Forms.TextBox();
            this.rolCmb = new System.Windows.Forms.ComboBox();
            this.idLbl = new System.Windows.Forms.Label();
            this.apellidoTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(53, 34);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(121, 20);
            this.usernameTxt.TabIndex = 0;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(53, 60);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(121, 20);
            this.passwordTxt.TabIndex = 1;
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(53, 110);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(121, 20);
            this.nombreTxt.TabIndex = 2;
            // 
            // rolCmb
            // 
            this.rolCmb.FormattingEnabled = true;
            this.rolCmb.Location = new System.Drawing.Point(53, 86);
            this.rolCmb.Name = "rolCmb";
            this.rolCmb.Size = new System.Drawing.Size(121, 21);
            this.rolCmb.TabIndex = 3;
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(50, 9);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(18, 13);
            this.idLbl.TabIndex = 4;
            this.idLbl.Text = "ID";
            // 
            // apellidoTxt
            // 
            this.apellidoTxt.Location = new System.Drawing.Point(53, 136);
            this.apellidoTxt.Name = "apellidoTxt";
            this.apellidoTxt.Size = new System.Drawing.Size(121, 20);
            this.apellidoTxt.TabIndex = 5;
            // 
            // UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 418);
            this.Controls.Add(this.apellidoTxt);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.rolCmb);
            this.Controls.Add(this.nombreTxt);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Name = "UserEdit";
            this.Text = "UserEdit";
            this.Load += new System.EventHandler(this.UserEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox nombreTxt;
        private System.Windows.Forms.ComboBox rolCmb;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.TextBox apellidoTxt;
    }
}