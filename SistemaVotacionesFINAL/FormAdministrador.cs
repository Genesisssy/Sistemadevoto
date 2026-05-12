using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public partial class FormAdministrador : Form
    {
        private string usuarioRol;
        private string usuarioNombre;

        public FormAdministrador()
        {
            InitializeComponent();
        }

        public FormAdministrador(string rol, string nombre) : this()
        {
            usuarioRol = rol;
            usuarioNombre = nombre;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FormRegistro frm = new FormRegistro();
            frm.ShowDialog();
            CargarUsuarios();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                string matricula = dgvUsuarios.CurrentRow.Cells["Matricula"].Value.ToString();
                FormRegistro frm = new FormRegistro(matricula); // opcional: pasar matrícula
                frm.ShowDialog();
                CargarUsuarios();
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string rolSeleccionado = dgvUsuarios.SelectedRows[0].Cells["Rol"].Value.ToString();

                if (rolSeleccionado != "Votante")
                {
                    MessageBox.Show("Solo se pueden eliminar votantes desde aquí.",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSeleccionado = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);

                bool exito = UsuarioDAL.EliminarUsuario(idSeleccionado);

                if (exito)
                {
                    MessageBox.Show("Votante eliminado correctamente ✅", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el votante.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un votante para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Beige;
            this.Text = "Panel de Administración";

            // 🔹 Título principal
            Label lblTitulo = new Label();
            lblTitulo.Text = "Panel de Administración";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

            // 🔹 Título Usuarios
            Label lblUsuarios = new Label();
            lblUsuarios.Text = "Gestión de Usuarios";
            lblUsuarios.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblUsuarios.ForeColor = Color.DarkSlateGray;
            lblUsuarios.Location = new Point(btnAgregarUsuario.Left, btnAgregarUsuario.Top - 40);
            lblUsuarios.AutoSize = true;
            this.Controls.Add(lblUsuarios);

            // 🔹 Título Resultados
            Label lblResultados = new Label();
            lblResultados.Text = "Resultados de Votación";
            lblResultados.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblResultados.ForeColor = Color.DarkOliveGreen;
            lblResultados.Location = new Point(dvresultado.Left, dvresultado.Top - 30);
            lblResultados.AutoSize = true;
            this.Controls.Add(lblResultados);

            // 🔹 Botones con diseño
            ConfigurarBoton(btnAgregarUsuario, "Agregar Usuario", Color.DarkSlateGray);
            ConfigurarBoton(btnEditarUsuario, "Editar Usuario", Color.DarkSlateGray);
            ConfigurarBoton(btnEliminarUsuario, "Eliminar Usuario", Color.DarkSlateGray);

            ConfigurarBoton(btnVerDetalles, "Ver Detalles", Color.DarkOliveGreen);
            ConfigurarBoton(btnvolveralmenu, "Volver al Menú", Color.Peru);

            // 🔹 Cargar datos iniciales
            CargarUsuarios();
            CargarResultados();
        }

        private void ConfigurarBoton(Button boton, string texto, Color colorFondo)
        {
            boton.Text = texto;
            boton.BackColor = colorFondo;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Size = new Size(130, 40);
        }

        private void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Matricula, Nombre, Curso, Seccion, Rol FROM Usuarios", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsuarios.DataSource = dt;
            }
        }

        private void CargarResultados()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True"))
            {
                string query = "SELECT PlanchaId, COUNT(*) AS Votos FROM Votos GROUP BY PlanchaId";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dvresultado.DataSource = dt;
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            FormResultados frm = new FormResultados();
            frm.ShowDialog();
        }

        private void btnvolveralmenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu frm = new FormMenu(usuarioRol, "Roja", usuarioNombre, 0);
            frm.Show();
        }
    }
}
