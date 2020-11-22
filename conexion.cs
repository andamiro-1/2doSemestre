using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2doSemestre
{
    public partial class conexion : MetroFramework.Forms.MetroForm
    {
        public conexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void botonConectar_Click(object sender, EventArgs e)
        private void botonConectar_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text;
            string puerto = txtPuerto.Text;
            string usuario = txtUsuario.Text;
            string password = txtContraseña.Text;
            string datos = "";
            //datos en variables
            //concattenar para conectar
            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password+"; database=ventas;";

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SHOW DATABASES",conexionBD);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    datos += reader.GetString(0) + "\n";
                }
            }
            catch(MySqlException)
            {
                MessageBox.Show("Error al conectar a la base de datos");               
            }
            MessageBox.Show(datos);
        }
    }
}
