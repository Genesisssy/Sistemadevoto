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
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaVotacionesFINAL
{
    public partial class FormResultadoVotante : Form
    {
        public FormResultadoVotante()
        {
            InitializeComponent();
        }

        private void FormResultadoVotante_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexion = ConexionDAL.ObtenerConexion())
            {
                conexion.Open();

                // 🔹 Consulta: votos por plancha
                string query = @"
                    SELECT p.NombrePlancha, COUNT(v.Id) AS TotalVotos
                    FROM Votos v
                    INNER JOIN Planchas p ON v.PlanchaId = p.Id
                    WHERE v.EsNulo = 0
                    GROUP BY p.NombrePlancha
                    ORDER BY TotalVotos DESC";

                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                // Mostrar en tabla
                dataGridView1.DataSource = tabla;

                // Configurar gráfico circular
                chart1.Series.Clear();
                chart1.Series.Add("Resultados");
                chart1.Series["Resultados"].ChartType = SeriesChartType.Pie;

                foreach (DataRow fila in tabla.Rows)
                {
                    chart1.Series["Resultados"].Points.AddXY(fila["NombrePlancha"], fila["TotalVotos"]);
                }

                // 🔹 Agregar votos nulos al gráfico
                string queryNulos = "SELECT COUNT(*) FROM Votos WHERE EsNulo = 1";
                SqlCommand cmdNulos = new SqlCommand(queryNulos, conexion);
                int votosNulos = (int)cmdNulos.ExecuteScalar();

                if (votosNulos > 0)
                {
                    chart1.Series["Resultados"].Points.AddXY("Nulos", votosNulos);
                }
            }
        }
    }
}
        