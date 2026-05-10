namespace SistemaVotacionesFINAL
{
    partial class FormMenu
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
            this.lblmenu = new System.Windows.Forms.Label();
            this.lblselec = new System.Windows.Forms.Label();
            this.btnplanchaazul = new System.Windows.Forms.Button();
            this.btnplancharoja = new System.Windows.Forms.Button();
            this.btnplanchaverde = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnnulo = new System.Windows.Forms.Button();
            this.btnplanchaamarilla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblmenu
            // 
            this.lblmenu.AutoSize = true;
            this.lblmenu.Location = new System.Drawing.Point(300, 53);
            this.lblmenu.Name = "lblmenu";
            this.lblmenu.Size = new System.Drawing.Size(138, 20);
            this.lblmenu.TabIndex = 0;
            this.lblmenu.Text = "Menú de Votación";
            // 
            // lblselec
            // 
            this.lblselec.AutoSize = true;
            this.lblselec.Location = new System.Drawing.Point(263, 390);
            this.lblselec.Name = "lblselec";
            this.lblselec.Size = new System.Drawing.Size(249, 20);
            this.lblselec.TabIndex = 1;
            this.lblselec.Text = "Seleccione su plancha o voto nulo";
            // 
            // btnplanchaazul
            // 
            this.btnplanchaazul.Location = new System.Drawing.Point(56, 124);
            this.btnplanchaazul.Name = "btnplanchaazul";
            this.btnplanchaazul.Size = new System.Drawing.Size(195, 75);
            this.btnplanchaazul.TabIndex = 2;
            this.btnplanchaazul.Text = "button1";
            this.btnplanchaazul.UseVisualStyleBackColor = true;
            this.btnplanchaazul.Click += new System.EventHandler(this.btnplanchaazul_Click);
            // 
            // btnplancharoja
            // 
            this.btnplancharoja.Location = new System.Drawing.Point(279, 124);
            this.btnplancharoja.Name = "btnplancharoja";
            this.btnplancharoja.Size = new System.Drawing.Size(195, 75);
            this.btnplancharoja.TabIndex = 3;
            this.btnplancharoja.Text = "button2";
            this.btnplancharoja.UseVisualStyleBackColor = true;
            this.btnplancharoja.Click += new System.EventHandler(this.btnplancharoja_Click);
            // 
            // btnplanchaverde
            // 
            this.btnplanchaverde.Location = new System.Drawing.Point(517, 124);
            this.btnplanchaverde.Name = "btnplanchaverde";
            this.btnplanchaverde.Size = new System.Drawing.Size(195, 75);
            this.btnplanchaverde.TabIndex = 4;
            this.btnplanchaverde.Text = "button3";
            this.btnplanchaverde.UseVisualStyleBackColor = true;
            this.btnplanchaverde.Click += new System.EventHandler(this.btnplanchaverde_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(517, 233);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(195, 75);
            this.btnsalir.TabIndex = 5;
            this.btnsalir.Text = "button4";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnnulo
            // 
            this.btnnulo.Location = new System.Drawing.Point(279, 233);
            this.btnnulo.Name = "btnnulo";
            this.btnnulo.Size = new System.Drawing.Size(195, 75);
            this.btnnulo.TabIndex = 6;
            this.btnnulo.Text = "button5";
            this.btnnulo.UseVisualStyleBackColor = true;
            this.btnnulo.Click += new System.EventHandler(this.btnnulo_Click);
            // 
            // btnplanchaamarilla
            // 
            this.btnplanchaamarilla.Location = new System.Drawing.Point(56, 233);
            this.btnplanchaamarilla.Name = "btnplanchaamarilla";
            this.btnplanchaamarilla.Size = new System.Drawing.Size(195, 75);
            this.btnplanchaamarilla.TabIndex = 7;
            this.btnplanchaamarilla.Text = "button6";
            this.btnplanchaamarilla.UseVisualStyleBackColor = true;
            this.btnplanchaamarilla.Click += new System.EventHandler(this.btnplanchaamarilla_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnplanchaamarilla);
            this.Controls.Add(this.btnnulo);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnplanchaverde);
            this.Controls.Add(this.btnplancharoja);
            this.Controls.Add(this.btnplanchaazul);
            this.Controls.Add(this.lblselec);
            this.Controls.Add(this.lblmenu);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmenu;
        private System.Windows.Forms.Label lblselec;
        private System.Windows.Forms.Button btnplanchaazul;
        private System.Windows.Forms.Button btnplancharoja;
        private System.Windows.Forms.Button btnplanchaverde;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnnulo;
        private System.Windows.Forms.Button btnplanchaamarilla;
    }
}