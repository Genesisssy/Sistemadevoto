using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormMenu : Form
    {
        private string usuarioRol;
        private string planchaAsignada;
        private string usuarioNombre;
        private int usuarioId;

        public FormMenu()
        {
            InitializeComponent();
        }

        public FormMenu(string rol, string plancha, string nombre, int idUsuario) : this()
        {
            usuarioRol = rol;
            planchaAsignada = plancha;
            usuarioNombre = nombre;
            usuarioId = idUsuario;

            this.Text = $"FormMenu - {rol} - {plancha}";
        }

        private bool PuedeEntrar(string planchaSolicitada)
        {
            if (usuarioRol == "Administrador" && planchaAsignada != planchaSolicitada)
            {
                MessageBox.Show("No tiene permiso para entrar a otra plancha.",
                                "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // 🔹 Botones de planchas: ahora abren el formulario correspondiente
        private void btnplanchaazul_Click(object sender, EventArgs e)
        {
            if (!PuedeEntrar("Azul")) return;
            new FormPlanchaAzul(usuarioId).Show();
            this.Hide();
        }

        private void btnplancharoja_Click(object sender, EventArgs e)
        {
            if (!PuedeEntrar("Roja")) return;
            new FormPlanchaRoja(usuarioId).Show();
            this.Hide();
        }

        private void btnplanchaverde_Click(object sender, EventArgs e)
        {
            if (!PuedeEntrar("Verde")) return;
            new FormPlanchaVerde(usuarioId).Show();
            this.Hide();
        }

        private void btnplanchaamarilla_Click(object sender, EventArgs e)
        {
            if (!PuedeEntrar("Amarilla")) return;
            new FormPlanchaAmarilla(usuarioId).Show();
            this.Hide();
        }

        // 🔹 El voto nulo sí se registra directo
        private void btnnulo_Click(object sender, EventArgs e)
        {
            if (usuarioId <= 0)
            {
                MessageBox.Show("Error: el ID del usuario no es válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuarioDAL.YaVoto(usuarioId))
            {
                MessageBox.Show("Ya has votado antes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exito = UsuarioDAL.RegistrarVoto(usuarioId, 0, true);

            if (exito)
            {
                MessageBox.Show("¡Voto nulo registrado!", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new FormResultados().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el voto nulo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            Label lblTitulo = new Label();
            lblTitulo.Text = "Menú de Votación";
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 70;
            this.Controls.Add(lblTitulo);

            ConfigurarBoton(btnplanchaazul, "Plancha Azul", Color.RoyalBlue);
            ConfigurarBoton(btnplancharoja, "Plancha Roja", Color.Firebrick);
            ConfigurarBoton(btnplanchaverde, "Plancha Verde", Color.ForestGreen);
            ConfigurarBoton(btnplanchaamarilla, "Plancha Amarilla", Color.Goldenrod);
            ConfigurarBoton(btnnulo, "Voto Nulo", Color.Gray);
            ConfigurarBoton(btnsalir, "Salir", Color.DarkSlateGray);
            ConfigurarBoton(btnAdministrar, "Administrar", Color.DarkOrange);

            btnAdministrar.Visible = usuarioRol == "Administrador";

            Label lblFooter = new Label();
            lblFooter.Text = "Seleccione su plancha o voto nulo";
            lblFooter.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock = DockStyle.Bottom;
            lblFooter.Height = 40;
            this.Controls.Add(lblFooter);
        }

        private void ConfigurarBoton(Button boton, string texto, Color colorFondo)
        {
            boton.Text = texto;
            boton.BackColor = colorFondo;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
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
