using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormPlanchaAmarilla : Form
    {
        public FormPlanchaAmarilla()
        {
            InitializeComponent();
        }

        private void FormPlanchaAmarilla_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LemonChiffon;
            this.Text = "Plancha Amarilla";

            Label lblTitulo = new Label();
            lblTitulo.Text = "Plancha Amarilla";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = Color.Goldenrod;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

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
                lblCargo.BackColor = Color.Goldenrod;
                lblCargo.Dock = DockStyle.Top;
                lblCargo.Height = 30;
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
                panel.Controls.Add(lblNombre);

                this.Controls.Add(panel);
                x += 230;
            }

            Button btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar Voto";
            btnConfirmar.BackColor = Color.Goldenrod;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnConfirmar.Size = new Size(150, 40);
            btnConfirmar.Location = new Point(150, 350);
            btnConfirmar.Click += BtnConfirmar_Click;
            this.Controls.Add(btnConfirmar);

            Button btnMenu = new Button();
            btnMenu.Text = "Volver al Menú";
            btnMenu.BackColor = Color.Gray;
            btnMenu.ForeColor = Color.White;
            btnMenu.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMenu.Size = new Size(150, 40);
            btnMenu.Location = new Point(350, 350);
            btnMenu.Click += BtnMenu_Click;
            this.Controls.Add(btnMenu);
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto confirmado para Plancha Amarilla ✅", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu();
            menu.Show();
        }
    }
}
       