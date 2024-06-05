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
    public partial class AlumnoMod : Form
    {
        SqlConnection MiConexion3;
        public AlumnoMod(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion3 = MiConexion;
        }

        private void AlumnoMod_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                MiConexion3.Open();
                int DNI_Control = int.Parse(txtDNIControl.Text);
                string cadena = "SELECT * FROM Alumnos WHERE DNI = @DNI_Control;";
                SqlCommand comando = new SqlCommand(cadena, MiConexion3);
                comando.Parameters.AddWithValue("@DNI_Control", DNI_Control);
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    txtDNI.Text = leer["DNI"].ToString();
                    txtNombre.Text = leer["Nombre"].ToString();
                    txtApellido.Text = leer["Apellido"].ToString();
                    txtDireccion.Text = leer["Direccion"].ToString();
                    txtCarrera.Text = leer["Carrera"].ToString();
                    txtSemestre.Text = leer["Semestre"].ToString();
                }
                MiConexion3.Close();
            }catch (SqlException)
            {
                MessageBox.Show("No se pudo realizar la operación", "Error");
            }
            finally
            {
                MiConexion3.Close();
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDNIControl.Text == "" || txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                || txtCarrera.Text == "" || txtDireccion.Text == "" || txtSemestre.Text == "")
            {
                MessageBox.Show("Complete todos los campos.", "Error");
                txtDNIControl.Focus();
            } else
            {
                try
                {
                    MiConexion3.Open();
                    int DNI = Convert.ToInt32(txtDNI.Text);
                    int DNIControl = Convert.ToInt32(txtDNIControl.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string direccion = txtDireccion.Text;
                    string carrera = txtCarrera.Text;
                    int semestre = int.Parse(txtSemestre.Text);
                    // string cadena para actualizar los datos con parameters.AddWithValue mas seguro contra SQLInjection
                    string cadena = "UPDATE Alumnos SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Carrera = @Carrera, Semestre = @Semestre WHERE DNI = @DNIControl;";
                    SqlCommand comando = new SqlCommand(cadena, MiConexion3);
                    comando.Parameters.AddWithValue("@DNI", DNI);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@Carrera", carrera);
                    comando.Parameters.AddWithValue("@Semestre", semestre);
                    comando.Parameters.AddWithValue("@DNIControl", DNIControl);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se actualizaron correctamente");
                    MiConexion3.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la operación", "Error");
                }
                finally
                {
                    MiConexion3.Close();
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
