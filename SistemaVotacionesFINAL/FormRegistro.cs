using System;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnregistrofinal_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles (ajusta los nombres si son distintos)
            string nombre = txtnombre.Text.Trim();
            string matricula = txtmatricula.Text.Trim();
            string curso = txtcurso.Text.Trim();
            string seccion = txtsecc.Text.Trim();
            string password = txtcontras.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nombre, Matrícula y Contraseña son obligatorios.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Insertar con el nuevo método (parámetros simples, no entidad)
                UsuarioDAL.InsertarUsuario(matricula, nombre, password, false, curso, seccion);
                MessageBox.Show("Usuario registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ir al menú como votante
                string rol = "Votante";
                string plancha = "Ninguna";
                new FormMenu(rol, plancha).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            
        }
    }
}