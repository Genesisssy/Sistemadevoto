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
        public FormMenu() 
        {
            

            InitializeComponent();
        }

        // Nuevo constructor que acepta rol y plancha
        public FormMenu(string rol, string plancha) : this()
        {
            usuarioRol = rol;
            planchaAsignada = plancha;
            this.Text = $"FormMenu - {rol} - {plancha}";
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

        }
    }
}
