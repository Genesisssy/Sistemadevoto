using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotacionesFINAL
{
    public static class VotacionHelper
    {
        public static void IniciarTimer(Form form, int usuarioId, int segundos, int planchaId)
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            int tiempoRestante = segundos;

            // Label para mostrar tiempo restante
            Label lblTimer = new Label();
            lblTimer.Name = "lblTimer";
            lblTimer.Text = $"Tiempo restante: {tiempoRestante}s";
            lblTimer.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTimer.ForeColor = Color.DarkRed;
            lblTimer.Location = new Point(220, 60);
            lblTimer.AutoSize = true;
            form.Controls.Add(lblTimer);

            // Evento del Timer
            timer.Tick += (s, e) =>
            {
                tiempoRestante--;
                lblTimer.Text = $"Tiempo restante: {tiempoRestante}s";

                if (tiempoRestante <= 0)
                {
                    timer.Stop();

                    // Si el usuario no ha votado, registrar voto nulo
                    if (!UsuarioDAL.YaVoto(usuarioId))
                    {
                        bool exito = UsuarioDAL.RegistrarVoto(usuarioId, 0, true);
                        if (exito)
                        {
                            MessageBox.Show("⏰ Tiempo agotado. ¡Voto nulo registrado!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            form.Hide();
                            new FormResultados().ShowDialog();
                            form.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el voto nulo.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            timer.Start();
        }
    }
}
