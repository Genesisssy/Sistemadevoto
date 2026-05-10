using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Fondo general neutro
            this.BackColor = Color.Gainsboro;
            this.Text = "Inicio de Sesión";

            // Encabezado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Inicio de Sesión";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

            // Etiqueta Usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Matrícula:";
            lblUsuario.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblUsuario.ForeColor = Color.Gray;
            lblUsuario.Location = new Point(80, 120);
            this.Controls.Add(lblUsuario);

            // Caja de texto Usuario
            textBox1.Size = new Size(220, 30);
            textBox1.Location = new Point(180, 120);
            textBox1.Font = new Font("Segoe UI", 10);
            textBox1.ForeColor = Color.Black;
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            // Etiqueta Contraseña
            Label lblPassword = new Label();
            lblPassword.Text = "Contraseña:";
            lblPassword.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPassword.ForeColor = Color.Gray;
            lblPassword.Location = new Point(80, 170);
            this.Controls.Add(lblPassword);

            // Caja de texto Contraseña
            textBox2.Size = new Size(220, 30);
            textBox2.Location = new Point(180, 170);
            textBox2.Font = new Font("Segoe UI", 10);
            textBox2.ForeColor = Color.Black;
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.PasswordChar = '•';

            // Botón Iniciar Sesión
            btnlogin.Text = "Iniciar Sesión";
            btnlogin.BackColor = Color.DimGray;
            btnlogin.ForeColor = Color.White;
            btnlogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnlogin.Size = new Size(180, 40);
            btnlogin.Location = new Point(150, 230);
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.FlatAppearance.BorderSize = 0;

            // Botón Registrarse
            btnregis.Text = "Registrarse";
            btnregis.BackColor = Color.LightGray;
            btnregis.ForeColor = Color.Black;
            btnregis.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnregis.Size = new Size(100, 35);
            btnregis.Location = new Point(180, 290);
            btnregis.FlatStyle = FlatStyle.Flat;
            btnregis.FlatAppearance.BorderSize = 0;

            // Texto inferior
            Label lblFooter = new Label();
            lblFooter.Text = "¿Olvidó su contraseña?";
            lblFooter.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock = DockStyle.Bottom;
            lblFooter.Height = 30;
            this.Controls.Add(lblFooter);
        }
       

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string matricula = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese matrícula y contraseña.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UsuarioDAL.ValidarCredenciales(matricula, password))
            {
                bool esAdmin = UsuarioDAL.EsAdministrador(matricula);
                string rol = esAdmin ? "Administrador" : "Votante";

                string plancha = UsuarioDAL.ObtenerPlancha(matricula);
                string nombre = UsuarioDAL.ObtenerNombre(matricula);

                MessageBox.Show($"Bienvenido {rol}", "Inicio exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (rol == "Administrador")
                {
                    // 🔹 Enviar al menú principal, no al panel de administración
                    new FormMenu(rol, plancha, nombre).Show();
                }
                else
                {
                    new FormMenu(rol, plancha, nombre).Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Matrícula o contraseña incorrecta.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregis_Click(object sender, EventArgs e)
        {
            new FormRegistro().Show();
            this.Hide();
        }

        private void lbllogin_Click(object sender, EventArgs e)
        {
        }
    }
}
