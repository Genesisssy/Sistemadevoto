using System;
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
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string matricula = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese matrícula y contraseña.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar credenciales con el DAL
            if (UsuarioDAL.ValidarCredenciales(matricula, password))
            {
                bool esAdmin = UsuarioDAL.EsAdministrador(matricula);
                string rol = esAdmin ? "Administrador" : "Votante";

                // Traer la plancha desde la BD
                string plancha = UsuarioDAL.ObtenerPlancha(matricula);

                MessageBox.Show($"Bienvenido {rol}", "Inicio exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pasar rol y plancha al menú
                new FormMenu(rol, plancha).Show();
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
