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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvResultadosDetallados = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosDetallados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dgvResultadosDetallados
            // 
            this.dgvResultadosDetallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadosDetallados.Location = new System.Drawing.Point(37, 94);
            this.dgvResultadosDetallados.Name = "dgvResultadosDetallados";
            this.dgvResultadosDetallados.RowHeadersWidth = 62;
            this.dgvResultadosDetallados.RowTemplate.Height = 28;
            this.dgvResultadosDetallados.Size = new System.Drawing.Size(494, 415);
            this.dgvResultadosDetallados.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(203, 536);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(155, 51);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "button1";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 599);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvResultadosDetallados);
            this.Controls.Add(this.label1);
            this.Name = "FormResultados";
            this.Text = "FormResultados";
            this.Load += new System.EventHandler(this.FormResultados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosDetallados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvResultadosDetallados;
        private System.Windows.Forms.Button btnCerrar;
    }
}