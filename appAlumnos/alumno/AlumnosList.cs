using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appAlumnos
{
    public partial class AlumnosList : Form
    {
        SqlConnection MiConexion4;
        public AlumnosList(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion4 = MiConexion;
        }

        private void AlumnosList_Load(object sender, EventArgs e)
        {
            try
            {
                MiConexion4.Open();
                string cadena = "SELECT * FROM Alumnos;";
                SqlDataAdapter adaptador = new SqlDataAdapter(cadena, MiConexion4);
                DataSet conjunto = new DataSet();
                adaptador.Fill(conjunto, "Alumnos");
                dgvAlumnos.DataSource = conjunto;
                dgvAlumnos.DataMember = "Alumnos";
                MiConexion4.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo realizar la operación", "Error");
            }
            finally
            {
                MiConexion4.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
