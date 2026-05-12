using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                FormRegistro frm = new FormRegistro();
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
            lblTitulo.Location = new Point(this.Width / 2 - 200, 10);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            // 🔹 Título Usuarios (encima del bloque de botones de usuarios)
            Label lblUsuarios = new Label();
            lblUsuarios.Text = "Gestión de Usuarios";
            lblUsuarios.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblUsuarios.ForeColor = Color.DarkSlateGray;
            lblUsuarios.Location = new Point(btnAgregarUsuario.Left, btnAgregarUsuario.Top - 40);
            lblUsuarios.AutoSize = true;
            this.Controls.Add(lblUsuarios);

            // 🔹 Título Planchas (encima del primer botón de planchas)
            Label lblPlanchas = new Label();
            lblPlanchas.Text = "Gestión de Planchas";
            lblPlanchas.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblPlanchas.ForeColor = Color.SteelBlue;
            lblPlanchas.Location = new Point(btnCrearPlancha.Left, btnCrearPlancha.Top - 40);
            lblPlanchas.AutoSize = true;
            this.Controls.Add(lblPlanchas);

            // 🔹 Título Resultados (encima del DataGridView de resultados)
            Label lblResultados = new Label();
            lblResultados.Text = "Resultados de Votación";
            lblResultados.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblResultados.ForeColor = Color.DarkOliveGreen;
            lblResultados.Location = new Point(dvresultado.Left, dvresultado.Top - 30);
            lblResultados.AutoSize = true;
            this.Controls.Add(lblResultados);

            // 🔹 Botones con diseño neutro
            ConfigurarBoton(btnAgregarUsuario, "Agregar Usuario", Color.DarkSlateGray);
            ConfigurarBoton(btnEditarUsuario, "Editar Usuario", Color.DarkSlateGray);
            ConfigurarBoton(btnEliminarUsuario, "Eliminar Usuario", Color.DarkSlateGray);

            ConfigurarBoton(btnCrearPlancha, "Crear Plancha", Color.SteelBlue);
            ConfigurarBoton(btnEditarPlancha, "Editar Plancha", Color.SteelBlue);
            ConfigurarBoton(btnEliminarPlancha, "Eliminar Plancha", Color.SteelBlue);

            ConfigurarBoton(btnVerDetalles, "Ver Detalles", Color.DarkOliveGreen);
            ConfigurarBoton(btnvolveralmenu, "Volver al Menú", Color.Peru);
        }

        // 🔹 Método auxiliar único
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT Matricula, Nombre, Curso, Seccion FROM Usuarios", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsuarios.DataSource = dt;
            }
        }

        private void btnCrearPlancha_Click(object sender, EventArgs e)
        {
            FormPlancha frm = new FormPlancha();
            frm.ShowDialog();
            CargarPlanchas();
        }

        private void btnEditarPlancha_Click(object sender, EventArgs e)
        {
            FormPlancha frm = new FormPlancha();
            frm.ShowDialog();
            CargarPlanchas();
        }

        private void btnEliminarPlancha_Click(object sender, EventArgs e)
        {
            UsuarioDAL.EliminarPlancha("Roja");
            MessageBox.Show("Plancha eliminada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarPlanchas();
        }

        private void CargarPlanchas()
        {
            // Aquí puedes implementar la carga de planchas
        }

        private void CargarResultados()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True"))
            {
                string query = "SELECT Plancha, COUNT(*) AS Votos FROM Votos GROUP BY Plancha";
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
