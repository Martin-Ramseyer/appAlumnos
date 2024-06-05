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
    public partial class MateriaBaja : Form
    {
        SqlConnection MiConexion2;
        public MateriaBaja(SqlConnection MiConexion)
        {
            InitializeComponent();
            MiConexion2 = MiConexion;
        }
    }
}
