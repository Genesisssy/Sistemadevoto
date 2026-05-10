using System;
using System.Drawing;
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
            string nombre = txtnombre.Text.Trim();
            string matricula = txtmatricula.Text.Trim();
            string curso = txtcurso.Text.Trim();
            string seccion = txtsecc.Text.Trim();
            string password = txtcontras.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nombre, Matrícula y Contraseña son obligatorios.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool registrado = UsuarioDAL.RegistrarUsuario(matricula, nombre, password, curso, seccion);

                if (!registrado)
                {
                    MessageBox.Show("Ya existe un usuario con esa matrícula.", "Duplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Usuario registrado correctamente. Ahora puede iniciar sesión.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Volver al login
                new FormLogin().Show();
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
            // Fondo general neutro
            this.BackColor = Color.Gainsboro;
            this.Text = "Registro de Usuario";

            // Encabezado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Registro de Usuario";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

            // Etiquetas y cajas de texto
            int y = 100;
            string[] etiquetas = { "Nombre:", "Matrícula:", "Curso:", "Sección:", "Contraseña:" };
            TextBox[] cajas = { txtnombre, txtmatricula, txtcurso, txtsecc, txtcontras };

            for (int i = 0; i < etiquetas.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text = etiquetas[i];
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.ForeColor = Color.Gray;
                lbl.Location = new Point(80, y);
                this.Controls.Add(lbl);

                cajas[i].Size = new Size(220, 30);
                cajas[i].Location = new Point(200, y);
                cajas[i].Font = new Font("Segoe UI", 10);
                cajas[i].ForeColor = Color.Black;
                cajas[i].BackColor = Color.WhiteSmoke;
                cajas[i].BorderStyle = BorderStyle.FixedSingle;

                y += 50;
            }

            // Botón de registro
            btnregistrofinal.Text = "Registrar Usuario";
            btnregistrofinal.BackColor = Color.DimGray;
            btnregistrofinal.ForeColor = Color.White;
            btnregistrofinal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnregistrofinal.Size = new Size(200, 40);
            btnregistrofinal.Location = new Point(160, y + 20);
            btnregistrofinal.FlatStyle = FlatStyle.Flat;
            btnregistrofinal.FlatAppearance.BorderSize = 0;

            // Texto inferior
            Label lblFooter = new Label();
            lblFooter.Text = "Complete todos los campos antes de continuar";
            lblFooter.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock = DockStyle.Bottom;
            lblFooter.Height = 30;
            this.Controls.Add(lblFooter);
        }
    }
    }
