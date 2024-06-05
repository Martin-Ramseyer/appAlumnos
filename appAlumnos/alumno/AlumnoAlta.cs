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
    public partial class AlumnoAlta : Form
    {
        SqlConnection MiConexion1;
        public AlumnoAlta(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion1 = MiConexion;
        }

        private void AlumnoAlta_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" 
                || txtCarrera.Text == "" || txtDireccion.Text == "" || txtSemestre.Text == "")
            {
                MessageBox.Show("Complete todos los campos.", "Error");
                txtDNI.Focus();
            }
            else { 
                try
                {
                    MiConexion1.Open();
                    int DNI = Convert.ToInt32(txtDNI.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string direccion = txtDireccion.Text;
                    string carrera = txtCarrera.Text;
                    int semestre = int.Parse(txtSemestre.Text);
                    // string cadena para actualizar los datos con parameters.AddWithValue 
                    string cadena = "INSERT INTO Alumnos (DNI, Nombre, Apellido, Direccion, Carrera, Semestre) VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Carrera, @Semestre);";
                    SqlCommand comando = new SqlCommand(cadena, MiConexion1);
                    comando.Parameters.AddWithValue("@DNI", DNI);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@Carrera", carrera);
                    comando.Parameters.AddWithValue("@Semestre", semestre);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se guardaron correctamente");
                    MiConexion1.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la operación", "Error");
                }
                finally
                {
                    MiConexion1.Close();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Boton de salir del formulario
            this.Close();
        }
    }
}
