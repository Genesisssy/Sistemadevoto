using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormPlancha : Form
    {
        public FormPlancha()
        {
            InitializeComponent();
        }

        private void FormPlancha_Load(object sender, EventArgs e)
        {
            this.Text = "Gestión de Planchas";
            this.BackColor = Color.LightGray;
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 🔹 Título centrado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Registro de Planchas";
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 80;
            this.Controls.Add(lblTitulo);

            // 🔹 Asignar texto a tus labels
            lblnombreplancha.Text = "Nombre de Plancha:";
            lblpresidente.Text = "Presidente:";
            lblvicepresidente.Text = "Vicepresidente:";
            lbltesorero.Text = "Tesorero:";
            lblsecretario.Text = "Secretario:";

            // 🔹 Estilo general para etiquetas
            Font fuenteEtiqueta = new Font("Segoe UI", 12, FontStyle.Bold);
            Color colorEtiqueta = Color.Black;

            lblnombreplancha.Font = fuenteEtiqueta;
            lblpresidente.Font = fuenteEtiqueta;
            lblvicepresidente.Font = fuenteEtiqueta;
            lbltesorero.Font = fuenteEtiqueta;
            lblsecretario.Font = fuenteEtiqueta;

            lblnombreplancha.ForeColor = colorEtiqueta;
            lblpresidente.ForeColor = colorEtiqueta;
            lblvicepresidente.ForeColor = colorEtiqueta;
            lbltesorero.ForeColor = colorEtiqueta;
            lblsecretario.ForeColor = colorEtiqueta;

            // 🔹 Posiciones y tamaños (alineadas)
            int xLabel = 150;
            int xText = 340;
            int yStart = 120;
            int espacio = 45;

            lblnombreplancha.Location = new Point(xLabel, yStart);
            txtnombreplancha.Location = new Point(xText, yStart);
            txtnombreplancha.Size = new Size(280, 30);

            lblpresidente.Location = new Point(xLabel, yStart + espacio);
            txtpresidente.Location = new Point(xText, yStart + espacio);
            txtpresidente.Size = new Size(280, 30);

            lblvicepresidente.Location = new Point(xLabel, yStart + espacio * 2);
            txtvicepresidente.Location = new Point(xText, yStart + espacio * 2);
            txtvicepresidente.Size = new Size(280, 30);

            lbltesorero.Location = new Point(xLabel, yStart + espacio * 3);
            txttesorero.Location = new Point(xText, yStart + espacio * 3);
            txttesorero.Size = new Size(280, 30);

            lblsecretario.Location = new Point(xLabel, yStart + espacio * 4);
            txtsecretario.Location = new Point(xText, yStart + espacio * 4);
            txtsecretario.Size = new Size(280, 30);

            // 🔹 Estilo de los TextBox
            Font fuenteCaja = new Font("Segoe UI", 11);
            txtnombreplancha.Font = fuenteCaja;
            txtpresidente.Font = fuenteCaja;
            txtvicepresidente.Font = fuenteCaja;
            txttesorero.Font = fuenteCaja;
            txtsecretario.Font = fuenteCaja;

            // 🔹 Botones
            btnGuardarr.Text = "Registrar Plancha";
            btnGuardarr.BackColor = Color.DimGray;
            btnGuardarr.ForeColor = Color.White;
            btnGuardarr.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGuardarr.FlatStyle = FlatStyle.Flat;
            btnGuardarr.FlatAppearance.BorderSize = 0;
            btnGuardarr.Size = new Size(180, 45);
            btnGuardarr.Location = new Point(200, 360);

            btnCancelar.Text = "Cancelar";
            btnCancelar.BackColor = Color.DarkRed;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Location = new Point(400, 360);
        }

        // 🔹 Botón Guardar (Registrar Plancha)
        private void btnGuardarr_Click(object sender, EventArgs e)
        {
            string nombre = txtnombreplancha.Text.Trim();
            string presidente = txtpresidente.Text.Trim();
            string vice = txtvicepresidente.Text.Trim();
            string tesorero = txttesorero.Text.Trim();
            string secretario = txtsecretario.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(presidente))
            {
                MessageBox.Show("Complete los campos obligatorios (Nombre y Presidente).", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 Ahora InsertarPlancha recibe 5 parámetros
                UsuarioDAL.InsertarPlancha(nombre, presidente, vice, tesorero, secretario);
                MessageBox.Show("Plancha registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la plancha: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
