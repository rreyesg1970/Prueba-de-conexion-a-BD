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

namespace Prueba_de_conexion_a_BD
{
    public partial class Form1 : Form
    {
        private SqlConnection Conexion = new SqlConnection("Server=.;DataBase = System;Integrated Security = true");
        private SqlCommand cmd; 
        private DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarProductos();
            CerrarConexion();
        }

        public void MostrarProductos()
        {
            DataTable dt = MostrarTodosProductos();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Costo"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["PrecioVenta1"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["PrecioVenta2"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["PrecioVenta3"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["PrecioVenta4"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["PrecioVenta5"].DefaultCellStyle.Format = "N2";
        }

        public DataTable MostrarTodosProductos()
        {
            cmd = new SqlCommand("SP_MostrarTodosProductos", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarConexion();
        }
    }
}
