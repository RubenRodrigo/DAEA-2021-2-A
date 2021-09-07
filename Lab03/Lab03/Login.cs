using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                String user = txtUser.Text;
                String pwd = txtPass.Text;
                String sql = "SELECT * FROM tbl_usuario WHERE usuario_nombre = @USER AND usuario_password = @PASS";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@USER", SqlDbType.VarChar);
                cmd.Parameters["@USER"].Value = user;

                cmd.Parameters.Add("@PASS", SqlDbType.VarChar);
                cmd.Parameters["@PASS"].Value = pwd;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Inicio Sesión");
                }
                else
                {
                    MessageBox.Show("El usuario o contraseña no existen");
                }

                reader.Close();

            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
