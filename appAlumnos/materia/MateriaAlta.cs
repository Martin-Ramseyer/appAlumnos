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

namespace appAlumnos.materia
{
    public partial class MateriaAlta : Form
    {
        SqlConnection MiConexion2;
        public MateriaAlta(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion2 = MiConexion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMateria.Text== "" || txtCarrera.Text == "")
            {
                MessageBox.Show("Complete todos los campos.", "Error");
            }
            else
            {
                try
                {
                    MiConexion2.Open();
                    string nombre = txtMateria.Text;
                    string carrera = txtCarrera.Text;
                    string cadena = "INSERT INTO Materias (Nombre, Carrera) VALUES (@Nombre, @Carrera);";
                    SqlCommand comando = new SqlCommand(cadena, MiConexion2);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Carrera", carrera);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se guardaron correctamente");
                    MiConexion2.Close();

                }catch (SqlException)
                {
                    MessageBox.Show("Error al guardar los datos");
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
