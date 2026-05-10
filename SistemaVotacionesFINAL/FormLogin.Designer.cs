namespace SistemaVotacionesFINAL
{
    partial class FormLogin
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
            this.lbllogin = new System.Windows.Forms.Label();
            this.lblmatric = new System.Windows.Forms.Label();
            this.lblcontra = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnregis = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbllogin
            // 
            this.lbllogin.AutoSize = true;
            this.lbllogin.Location = new System.Drawing.Point(235, 64);
            this.lbllogin.Name = "lbllogin";
            this.lbllogin.Size = new System.Drawing.Size(48, 20);
            this.lbllogin.TabIndex = 0;
            this.lbllogin.Text = "Login";
            this.lbllogin.Click += new System.EventHandler(this.lbllogin_Click);
            // 
            // lblmatric
            // 
            this.lblmatric.AutoSize = true;
            this.lblmatric.Location = new System.Drawing.Point(77, 124);
            this.lblmatric.Name = "lblmatric";
            this.lblmatric.Size = new System.Drawing.Size(73, 20);
            this.lblmatric.TabIndex = 1;
            this.lblmatric.Text = "Matricula";
            // 
            // lblcontra
            // 
            this.lblcontra.AutoSize = true;
            this.lblcontra.Location = new System.Drawing.Point(77, 213);
            this.lblcontra.Name = "lblcontra";
            this.lblcontra.Size = new System.Drawing.Size(92, 20);
            this.lblcontra.TabIndex = 2;
            this.lblcontra.Text = "Contraseña";
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(81, 340);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(126, 51);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "Iniciar Sesion";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnregis
            // 
            this.btnregis.Location = new System.Drawing.Point(354, 340);
            this.btnregis.Name = "btnregis";
            this.btnregis.Size = new System.Drawing.Size(126, 51);
            this.btnregis.TabIndex = 4;
            this.btnregis.Text = "Registrarse";
            this.btnregis.UseVisualStyleBackColor = true;
            this.btnregis.Click += new System.EventHandler(this.btnregis_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 26);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 245);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(429, 26);
            this.textBox2.TabIndex = 6;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnregis);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.lblcontra);
            this.Controls.Add(this.lblmatric);
            this.Controls.Add(this.lbllogin);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllogin;
        private System.Windows.Forms.Label lblmatric;
        private System.Windows.Forms.Label lblcontra;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnregis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}