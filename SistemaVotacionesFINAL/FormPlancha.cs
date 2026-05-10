using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormPlancha : Form
    {
        private string nombrePlanchaEditar;

        public FormPlancha()
        {
            InitializeComponent();
            nombrePlanchaEditar = null;
        }

        private void FormPlancha_Load(object sender, EventArgs e)
        {
            this.Text = "Gestión de Planchas";
            this.BackColor = Color.LightGray;
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 🔹 Título principal
            Label lblTitulo = new Label();
            lblTitulo.Text = "Registro de Planchas";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

            // 🔹 Etiquetas y cajas de texto
            string[] etiquetas = { "Nombre de Plancha:", "Presidente:", "Vicepresidente:", "Tesorero:", "Secretario:" };
            TextBox[] cajas = new TextBox[5];

            int y = 90;
            for (int i = 0; i < etiquetas.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text = etiquetas[i];
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lbl.ForeColor = Color.Black;
                lbl.Location = new Point(80, y);
                lbl.Size = new Size(150, 25);
                this.Controls.Add(lbl);

                cajas[i] = new TextBox();
                cajas[i].Name = $"txt{i}";
                cajas[i].Size = new Size(250, 25);
                cajas[i].Location = new Point(240, y);
                cajas[i].Font = new Font("Segoe UI", 10);
                this.Controls.Add(cajas[i]);

                y += 40;
            }

            // 🔹 Botón Guardar
            Button btnGuardar = new Button();
            btnGuardar.Text = "Registrar Plancha";
            btnGuardar.BackColor = Color.DimGray;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Size = new Size(180, 40);
            btnGuardar.Location = new Point(120, 300);
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            // 🔹 Botón Actualizar
            Button btnActualizar = new Button();
            btnActualizar.Text = "Actualizar Plancha";
            btnActualizar.BackColor = Color.Gray;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Size = new Size(180, 40);
            btnActualizar.Location = new Point(320, 300);
            btnActualizar.Click += BtnActualizar_Click;
            this.Controls.Add(btnActualizar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Plancha registrada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Plancha actualizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

