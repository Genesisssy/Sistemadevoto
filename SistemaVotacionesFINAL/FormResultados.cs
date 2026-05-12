using System;
using System.Data;
using System.Drawing;
using System.Linq;
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
            // 🔹 Configuración general
            this.Text = "Resultados de Votación";
            this.BackColor = Color.Beige;

            lblTitulo.Text = "Resultados de Votación";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkOliveGreen;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            dgvResultadosDetallados.BackgroundColor = Color.WhiteSmoke;
            dgvResultadosDetallados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultadosDetallados.ReadOnly = true;
            dgvResultadosDetallados.AllowUserToAddRows = false;
            dgvResultadosDetallados.AllowUserToDeleteRows = false;
            dgvResultadosDetallados.BorderStyle = BorderStyle.FixedSingle;

            btnactualizar.Text = "Actualizar";
            btnactualizar.BackColor = Color.RoyalBlue;
            btnactualizar.ForeColor = Color.White;
            btnactualizar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnactualizar.FlatStyle = FlatStyle.Flat;
            btnactualizar.FlatAppearance.BorderSize = 0;
            btnactualizar.Click += btnactualizar_Click;

            btnCANCELAR.Text = "Cancelar";
            btnCANCELAR.BackColor = Color.Peru;
            btnCANCELAR.ForeColor = Color.White;
            btnCANCELAR.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCANCELAR.FlatStyle = FlatStyle.Flat;
            btnCANCELAR.FlatAppearance.BorderSize = 0;
            btnCANCELAR.Click += BtnCancelar_Click;

            lblMensaje.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblMensaje.ForeColor = Color.DarkSlateGray;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;

            // 🔹 Cargar datos iniciales
            CargarResultados();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarResultados()
        {
            DataTable resultados = UsuarioDAL.ObtenerResultados();
            dgvResultadosDetallados.DataSource = resultados;

            if (resultados.Rows.Count == 0)
            {
                lblMensaje.Text = "No hay votos registrados aún.";
                return;
            }

            int maxVotos = resultados.AsEnumerable().Max(r => Convert.ToInt32(r["TotalVotos"]));
            var ganadores = resultados.AsEnumerable()
                .Where(r => Convert.ToInt32(r["TotalVotos"]) == maxVotos)
                .Select(r => r["Plancha"].ToString())
                .ToList();

            if (ganadores.Count == 1)
            {
                lblMensaje.Text = $"¡Plancha {ganadores[0]} va ganando con {maxVotos} votos!";
                lblMensaje.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblMensaje.Text = $"Empate entre {string.Join(" y ", ganadores)} con {maxVotos} votos cada uno.";
                lblMensaje.ForeColor = Color.DarkOrange;
            }
        }
    

private void btnactualizar_Click(object sender, EventArgs e)
        {

            CargarResultados();
        }
    }
}
