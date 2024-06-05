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

namespace appAlumnos
{
    public partial class AlumnoBaja : Form
    {
        SqlConnection MiConexion2;
        public AlumnoBaja(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion2 = MiConexion;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtDNI.Text);
            if (DNI == 0)
            {
                MessageBox.Show("Ingrese un DNI.", "Error");
            }
            else
            {
                try
                {
                    MiConexion2.Open();
                    string cadena = "DELETE FROM Alumnos WHERE DNI = @DNI;";
                    SqlCommand comando = new SqlCommand(cadena, MiConexion2);
                    comando.Parameters.AddWithValue("@DNI", DNI);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se eliminaron correctamente");
                    MiConexion2.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la operación", "Error");
                }
                finally
                {
                    MiConexion2.Close();
                }   
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
