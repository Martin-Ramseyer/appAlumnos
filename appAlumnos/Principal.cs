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
using appAlumnos.materia;

namespace appAlumnos
{
    public partial class Principal : Form
    {
        SqlConnection MiConexion = new SqlConnection("server=MARTIN\\SQLEXPRESS;database=DBUno;Integrated Security=true");
        public Principal()
        {
            InitializeComponent();
        }

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoAlta AA = new AlumnoAlta(MiConexion);
            AA.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoBaja AB = new AlumnoBaja(MiConexion);
            AB.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoMod AM = new AlumnoMod(MiConexion);
            AM.Show();
        }

        private void listadoDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosList AL = new AlumnosList(MiConexion);
            AL.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriaAlta MA = new MateriaAlta(MiConexion);
            MA.Show();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MateriaBaja MB = new MateriaBaja(MiConexion);
            MB.Show();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MateriaMod MM = new MateriaMod(MiConexion);
            MM.Show();
        }

        private void listadoDeMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriaList ML = new MateriaList(MiConexion);
            ML.Show();
        }
    }
}
