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
    public partial class FormMenu : Form
    {
        private string usuarioRol;
        private string planchaAsignada;
        private string usuarioNombre;

        public FormMenu()
        {
            InitializeComponent();
        }

        // Nuevo constructor que acepta rol y plancha
        public FormMenu(string rol, string plancha, string nombre) : this()
        {
            usuarioRol = rol;
            planchaAsignada = plancha;
            this.Text = $"FormMenu - {rol} - {plancha}";
            usuarioNombre = nombre;
        }

        private void btnplanchaazul_Click(object sender, EventArgs e)
        {
            if (usuarioRol == "Administrador" && planchaAsignada != "Azul")
            {
                MessageBox.Show("No tiene permiso para entrar a otra plancha.");
                return;
            }

            new FormPlanchaAzul().Show();
            this.Hide();
        }

        private void btnplancharoja_Click(object sender, EventArgs e)
        {
            if (usuarioRol == "Administrador" && planchaAsignada != "Roja")
            {
                MessageBox.Show("No tiene permiso para entrar a otra plancha.");
                return;
            }

            new FormPlanchaRoja().Show();
            this.Hide();
        }

        private void btnplanchaverde_Click(object sender, EventArgs e)
        {
            if (usuarioRol == "Administrador" && planchaAsignada != "Verde")
            {
                MessageBox.Show("No tiene permiso para entrar a otra plancha.");
                return;
            }

            new FormPlanchaVerde().Show();
            this.Hide();
        }

        private void btnplanchaamarilla_Click(object sender, EventArgs e)
        {
            if (usuarioRol == "Administrador" && planchaAsignada != "Amarilla")
            {
                MessageBox.Show("No tiene permiso para entrar a otra plancha.");
                return;
            }

            new FormPlanchaAmarilla().Show();
            this.Hide();
        }

        private void btnnulo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto registrado como NULO.");
            this.Hide();
            new FormLogin().Show();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Beige;
            this.Text = "Menú de Votación";

            Label lblUsuario = new Label();
            lblUsuario.Text = $"{usuarioRol}: {usuarioNombre}";
            lblUsuario.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblUsuario.ForeColor = Color.DimGray;
            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lblUsuario.Dock = DockStyle.Top;
            lblUsuario.Height = 40;
            this.Controls.Add(lblUsuario);

            // Encabezado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Menú de Votación";
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 70;
            this.Controls.Add(lblTitulo);

            // Estilo de botones
            btnplanchaazul.Text = "Plancha Azul";
            btnplanchaazul.BackColor = Color.RoyalBlue;
            btnplanchaazul.ForeColor = Color.White;
            btnplanchaazul.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnplanchaazul.FlatStyle = FlatStyle.Flat;
            btnplanchaazul.FlatAppearance.BorderSize = 0;

            btnplancharoja.Text = "Plancha Roja";
            btnplancharoja.BackColor = Color.Firebrick;
            btnplancharoja.ForeColor = Color.White;
            btnplancharoja.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnplancharoja.FlatStyle = FlatStyle.Flat;
            btnplancharoja.FlatAppearance.BorderSize = 0;

            btnplanchaverde.Text = "Plancha Verde";
            btnplanchaverde.BackColor = Color.ForestGreen;
            btnplanchaverde.ForeColor = Color.White;
            btnplanchaverde.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnplanchaverde.FlatStyle = FlatStyle.Flat;
            btnplanchaverde.FlatAppearance.BorderSize = 0;

            btnplanchaamarilla.Text = "Plancha Amarilla";
            btnplanchaamarilla.BackColor = Color.Goldenrod;
            btnplanchaamarilla.ForeColor = Color.White;
            btnplanchaamarilla.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnplanchaamarilla.FlatStyle = FlatStyle.Flat;
            btnplanchaamarilla.FlatAppearance.BorderSize = 0;

            btnnulo.Text = "Voto Nulo";
            btnnulo.BackColor = Color.Gray;
            btnnulo.ForeColor = Color.White;
            btnnulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnnulo.FlatStyle = FlatStyle.Flat;
            btnnulo.FlatAppearance.BorderSize = 0;

            btnsalir.Text = "Salir";
            btnsalir.BackColor = Color.DarkSlateGray;
            btnsalir.ForeColor = Color.White;
            btnsalir.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.FlatAppearance.BorderSize = 0;

            // Footer
            Label lblFooter = new Label();
            lblFooter.Text = "Seleccione su plancha o voto nulo";
            lblFooter.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock = DockStyle.Bottom;
            lblFooter.Height = 40;
            this.Controls.Add(lblFooter);

            // Botón Administrar
            btnAdministrar.Text = "Administrar";
            btnAdministrar.BackColor = Color.DarkOrange;
            btnAdministrar.ForeColor = Color.White;
            btnAdministrar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAdministrar.FlatStyle = FlatStyle.Flat;
            btnAdministrar.FlatAppearance.BorderSize = 0;
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            if (usuarioRol == "Administrador")
            {
                FormAdministrador frm = new FormAdministrador(usuarioRol, usuarioNombre);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso denegado. Solo administradores pueden entrar.");
            }
        }
    }
}


