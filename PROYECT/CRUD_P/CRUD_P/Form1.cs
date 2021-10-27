using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_P
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexión exitosa");

            dataGridView1.DataSource = llenar_grid();

        }


        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "SELECT * FROM USUARIO";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Conexion.Conectar();
            string insertar = "INSERT INTO USUARIO (COD, NOMBRES, APELLIDOS, DIRECCION, TELEFONO, FECHANACIMIENTO) VALUES (@COD, @NOMBRES, @APELLIDOS, @DIRECCION, @TELEFONO, @FECHANACIMIENTO)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@COD", txtcodigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRES", txtnombres.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS", txtapellidos.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
            cmd1.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
            cmd1.Parameters.AddWithValue("@FECHANACIMIENTO", txtdate.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron guardados con exito.");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar limpiar = new Limpiar();
            limpiar.Clear(groupBox1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttelefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtnombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtdate.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE USUARIO SET COD=@COD, NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS, DIRECCION=@DIRECCION, TELEFONO=@TELEFONO, FECHANACIMIENTO=@FECHANACIMIENTO WHERE COD=@COD";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@COD", txtcodigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRES", txtnombres.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", txtapellidos.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
            cmd2.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
            cmd2.Parameters.AddWithValue("@FECHANACIMIENTO", txtdate.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos han sido actualizados correctamente");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            String eliminar = "DELETE FROM USUARIO WHERE COD = @COD";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@COD", txtcodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados con éxito.");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            String buscar = "SELECT * FROM USUARIO WHERE COD =" + txtbuscar.Text;
            SqlDataAdapter adaptador = new SqlDataAdapter(buscar, Conexion.Conectar());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlCommand cmd4 = new SqlCommand(buscar, Conexion.Conectar());
            SqlDataReader lector;
            lector = cmd4.ExecuteReader();
          
        }

    }
}

