using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormPlanchaVerde : Form
    {
        int usuarioIdActual;
        int planchaId = 3; // Verde

        public FormPlanchaVerde()
        {
            InitializeComponent();
        }

        public FormPlanchaVerde(int idUsuario)
        {
            InitializeComponent();
            usuarioIdActual = idUsuario;
        }

        private void FormPlanchaVerde_Load(object sender, EventArgs e)
        {
            // Fondo general
            this.BackColor = Color.Honeydew;
            this.Text = "Plancha Verde";

            // Encabezado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Plancha Verde";
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = Color.ForestGreen;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 70;
            this.Controls.Add(lblTitulo);

            // Paneles para cargos
            string[] cargos = { "Presidente", "Vicepresidente", "Tesorero" };
            int x = 50;
            foreach (string cargo in cargos)
            {
                Panel panel = new Panel();
                panel.BackColor = Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(200, 220);
                panel.Location = new Point(x, 100);

                Label lblCargo = new Label();
                lblCargo.Text = cargo;
                lblCargo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblCargo.ForeColor = Color.White;
                lblCargo.BackColor = Color.ForestGreen;
                lblCargo.Dock = DockStyle.Top;
                lblCargo.Height = 35;
                lblCargo.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lblCargo);

                PictureBox foto = new PictureBox();
                foto.Size = new Size(120, 120);
                foto.Location = new Point(40, 50);
                foto.BackColor = Color.LightGray;
                foto.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(foto);

                Label lblNombre = new Label();
                lblNombre.Text = "Candidato " + cargo[0];
                lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblNombre.Location = new Point(50, 180);
                lblNombre.AutoSize = true;
                panel.Controls.Add(lblNombre);

                this.Controls.Add(panel);
                x += 230;
            }

            // Botón Confirmar Voto
            Button btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar Voto";
            btnConfirmar.BackColor = Color.MediumSeaGreen;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnConfirmar.Size = new Size(160, 45);
            btnConfirmar.Location = new Point(120, 350);
            btnConfirmar.Click += BtnConfirmar_Click;
            this.Controls.Add(btnConfirmar);

            // Botón Volver al Menú
            Button btnMenu = new Button();
            btnMenu.Text = "Volver al Menú";
            btnMenu.BackColor = Color.Gray;
            btnMenu.ForeColor = Color.White;
            btnMenu.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnMenu.Size = new Size(160, 45);
            btnMenu.Location = new Point(320, 350);
            btnMenu.Click += BtnMenu_Click;
            this.Controls.Add(btnMenu);

            // Botón Voto Nulo
            Button btnNulo = new Button();
            btnNulo.Text = "Voto Nulo";
            btnNulo.BackColor = Color.DarkRed;
            btnNulo.ForeColor = Color.White;
            btnNulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnNulo.Size = new Size(180, 45);
            btnNulo.Location = new Point(220, 410);
            btnNulo.Click += BtnNulo_Click;
            this.Controls.Add(btnNulo);
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (usuarioIdActual <= 0)
            {
                MessageBox.Show("Error: el ID del usuario no es válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (VotoDAL.YaVoto(usuarioIdActual))
            {
                MessageBox.Show("Ya has votado antes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exito = VotoDAL.RegistrarVoto(usuarioIdActual, planchaId);

            if (exito)
            {
                MessageBox.Show("Voto registrado correctamente en Plancha Verde ✅", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el voto.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormMenu("Votante", "Verde", "Usuario", usuarioIdActual).Show();
        }

        private void BtnNulo_Click(object sender, EventArgs e)
        {
            if (usuarioIdActual <= 0)
            {
                MessageBox.Show("Error: el ID del usuario no es válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = VotoDAL.RegistrarVoto(usuarioIdActual, 0, true);
            if (exito)
            {
                MessageBox.Show("¡Voto nulo registrado!", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new FormResultados().Show();
            }
            else
            {
                MessageBox.Show("Error al registrar el voto nulo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


