using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormResultados : Form
    {
        public FormResultados()
        {
            InitializeComponent();
        }

        private void FormResultados_Load(object sender, EventArgs e)
        {
            // 🔹 Configuración general del formulario
            this.Text = "Resultados de Votación";
            this.BackColor = Color.Beige;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 🔹 Estilo del título (usa el label del diseñador, ej. label1)
            label1.Text = "Resultados de Votación";
            label1.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Dock = DockStyle.Top;
            label1.Height = 60;

            // 🔹 Estilo del DataGridView (usa el del diseñador, ej. dgvResultadosDetallados)
            dgvResultadosDetallados.BackgroundColor = Color.WhiteSmoke;
            dgvResultadosDetallados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultadosDetallados.ReadOnly = true;
            dgvResultadosDetallados.AllowUserToAddRows = false;
            dgvResultadosDetallados.AllowUserToDeleteRows = false;
            dgvResultadosDetallados.BorderStyle = BorderStyle.FixedSingle;

            // 🔹 Estilo del botón (usa el del diseñador, ej. btnCerrar)
            btnCerrar.Text = "Cancelar";
            btnCerrar.BackColor = Color.Peru;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += BtnCancelar_Click;

            // 🔹 Cargar datos desde BD
            dgvResultadosDetallados.DataSource = UsuarioDAL.ObtenerResultados();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}

