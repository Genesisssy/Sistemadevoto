using System;

namespace SistemaVotacionesFINAL
{
    partial class FormRegistro
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
            this.lblRegis = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblmatricula = new System.Windows.Forms.Label();
            this.lblcurso = new System.Windows.Forms.Label();
            this.lblsec = new System.Windows.Forms.Label();
            this.lblcontras = new System.Windows.Forms.Label();
            this.btnregistrofinal = new System.Windows.Forms.Button();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtmatricula = new System.Windows.Forms.TextBox();
            this.txtcurso = new System.Windows.Forms.TextBox();
            this.txtsecc = new System.Windows.Forms.TextBox();
            this.txtcontras = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRegis
            // 
            this.lblRegis.AutoSize = true;
            this.lblRegis.Location = new System.Drawing.Point(263, 48);
            this.lblRegis.Name = "lblRegis";
            this.lblRegis.Size = new System.Drawing.Size(91, 20);
            this.lblRegis.TabIndex = 0;
            this.lblRegis.Text = "Registrarse";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(54, 93);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(65, 20);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // lblmatricula
            // 
            this.lblmatricula.AutoSize = true;
            this.lblmatricula.Location = new System.Drawing.Point(54, 164);
            this.lblmatricula.Name = "lblmatricula";
            this.lblmatricula.Size = new System.Drawing.Size(73, 20);
            this.lblmatricula.TabIndex = 2;
            this.lblmatricula.Text = "Matricula";
            // 
            // lblcurso
            // 
            this.lblcurso.AutoSize = true;
            this.lblcurso.Location = new System.Drawing.Point(54, 230);
            this.lblcurso.Name = "lblcurso";
            this.lblcurso.Size = new System.Drawing.Size(51, 20);
            this.lblcurso.TabIndex = 3;
            this.lblcurso.Text = "Curso";
            // 
            // lblsec
            // 
            this.lblsec.AutoSize = true;
            this.lblsec.Location = new System.Drawing.Point(54, 298);
            this.lblsec.Name = "lblsec";
            this.lblsec.Size = new System.Drawing.Size(66, 20);
            this.lblsec.TabIndex = 4;
            this.lblsec.Text = "Seccion";
            // 
            // lblcontras
            // 
            this.lblcontras.AutoSize = true;
            this.lblcontras.Location = new System.Drawing.Point(54, 369);
            this.lblcontras.Name = "lblcontras";
            this.lblcontras.Size = new System.Drawing.Size(92, 20);
            this.lblcontras.TabIndex = 5;
            this.lblcontras.Text = "Contraseña";
            // 
            // btnregistrofinal
            // 
            this.btnregistrofinal.Location = new System.Drawing.Point(160, 463);
            this.btnregistrofinal.Name = "btnregistrofinal";
            this.btnregistrofinal.Size = new System.Drawing.Size(275, 52);
            this.btnregistrofinal.TabIndex = 6;
            this.btnregistrofinal.Text = "Registrarse";
            this.btnregistrofinal.UseVisualStyleBackColor = true;
            this.btnregistrofinal.Click += new System.EventHandler(this.btnregistrofinal_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(58, 126);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(502, 26);
            this.txtnombre.TabIndex = 7;
            // 
            // txtmatricula
            // 
            this.txtmatricula.Location = new System.Drawing.Point(58, 187);
            this.txtmatricula.Name = "txtmatricula";
            this.txtmatricula.Size = new System.Drawing.Size(502, 26);
            this.txtmatricula.TabIndex = 8;
            // 
            // txtcurso
            // 
            this.txtcurso.Location = new System.Drawing.Point(58, 253);
            this.txtcurso.Name = "txtcurso";
            this.txtcurso.Size = new System.Drawing.Size(502, 26);
            this.txtcurso.TabIndex = 9;
            // 
            // txtsecc
            // 
            this.txtsecc.Location = new System.Drawing.Point(58, 321);
            this.txtsecc.Name = "txtsecc";
            this.txtsecc.Size = new System.Drawing.Size(502, 26);
            this.txtsecc.TabIndex = 10;
            // 
            // txtcontras
            // 
            this.txtcontras.Location = new System.Drawing.Point(58, 392);
            this.txtcontras.Name = "txtcontras";
            this.txtcontras.Size = new System.Drawing.Size(502, 26);
            this.txtcontras.TabIndex = 11;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 568);
            this.Controls.Add(this.txtcontras);
            this.Controls.Add(this.txtsecc);
            this.Controls.Add(this.txtcurso);
            this.Controls.Add(this.txtmatricula);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.btnregistrofinal);
            this.Controls.Add(this.lblcontras);
            this.Controls.Add(this.lblsec);
            this.Controls.Add(this.lblcurso);
            this.Controls.Add(this.lblmatricula);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.lblRegis);
            this.Name = "FormRegistro";
            this.Text = "FormRegistro";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegis;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblmatricula;
        private System.Windows.Forms.Label lblcurso;
        private System.Windows.Forms.Label lblsec;
        private System.Windows.Forms.Label lblcontras;
        private System.Windows.Forms.Button btnregistrofinal;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtmatricula;
        private System.Windows.Forms.TextBox txtcurso;
        private System.Windows.Forms.TextBox txtsecc;
        private System.Windows.Forms.TextBox txtcontras;
    }
}