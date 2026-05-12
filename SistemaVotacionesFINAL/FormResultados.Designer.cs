namespace SistemaVotacionesFINAL
{
    partial class FormResultados
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvResultadosDetallados = new System.Windows.Forms.DataGridView();
            this.btnCANCELAR = new System.Windows.Forms.Button();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosDetallados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(249, 47);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label1";
            // 
            // dgvResultadosDetallados
            // 
            this.dgvResultadosDetallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadosDetallados.Location = new System.Drawing.Point(12, 128);
            this.dgvResultadosDetallados.Name = "dgvResultadosDetallados";
            this.dgvResultadosDetallados.RowHeadersWidth = 62;
            this.dgvResultadosDetallados.RowTemplate.Height = 28;
            this.dgvResultadosDetallados.Size = new System.Drawing.Size(641, 297);
            this.dgvResultadosDetallados.TabIndex = 1;
            // 
            // btnCANCELAR
            // 
            this.btnCANCELAR.Location = new System.Drawing.Point(402, 537);
            this.btnCANCELAR.Name = "btnCANCELAR";
            this.btnCANCELAR.Size = new System.Drawing.Size(155, 51);
            this.btnCANCELAR.TabIndex = 2;
            this.btnCANCELAR.Text = "button1";
            this.btnCANCELAR.UseVisualStyleBackColor = true;
            this.btnCANCELAR.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnactualizar
            // 
            this.btnactualizar.Location = new System.Drawing.Point(81, 537);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(155, 51);
            this.btnactualizar.TabIndex = 3;
            this.btnactualizar.Text = "button1";
            this.btnactualizar.UseVisualStyleBackColor = true;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(294, 476);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(51, 20);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "label1";
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 638);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnactualizar);
            this.Controls.Add(this.btnCANCELAR);
            this.Controls.Add(this.dgvResultadosDetallados);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormResultados";
            this.Text = "FormResultados";
            this.Load += new System.EventHandler(this.FormResultados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosDetallados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvResultadosDetallados;
        private System.Windows.Forms.Button btnCANCELAR;
        private System.Windows.Forms.Button btnactualizar;
        private System.Windows.Forms.Label lblMensaje;
    }
}