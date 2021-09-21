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

namespace Lab05
{
    public partial class ManPerson : Form
    {
        SqlConnection con;
        public ManPerson()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void ManPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-48DOANE\\SQLEXPRESS2017;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el código: " + codigo);
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonId.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int resultado = cmd.ExecuteNonQuery();
            if(resultado > 0)
            {
                MessageBox.Show("Se ha modificado el registro correctamente");
            }
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonId.Text);

            try
            {
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {            
            if(dgvListado.SelectedRows.Count > 0)
            {
                txtPersonId.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                txtHireDate.Text = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dgvListado.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String value = cmbBuscar.Text;
            if (!string.IsNullOrEmpty(value))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con
                };
                switch (value)
                {
                    case "Codigo":
                        cmd.CommandText = "SELECT * FROM Person WHERE PersonID LIKE @LikeQuery";                        
                        cmd.Parameters.AddWithValue("@LikeQuery", "%" + txtPersonId.Text + "%");
                        break;
                    case "Nombre":
                        cmd.CommandText = "SELECT * FROM Person WHERE FirstName LIKE @LikeQuery";                        
                        cmd.Parameters.AddWithValue("@LikeQuery", "%" + txtFirstName.Text + "%");
                        break;
                    case "Apellido":
                        cmd.CommandText = "SELECT * FROM Person WHERE LastName LIKE @LikeQuery";                        
                        cmd.Parameters.AddWithValue("@LikeQuery", "%" + txtLastName.Text + "%");
                        break;
                    case "Contrato":
                        cmd.CommandText = "SELECT * FROM Person WHERE HireDate = @LikeQuery";                        
                        cmd.Parameters.AddWithValue("@LikeQuery", txtHireDate.Value);
                        break;
                    case "Inscripcion":
                        cmd.CommandText = "SELECT * FROM Person WHERE EnrollmentDate = @LikeQuery";
                        cmd.Parameters.AddWithValue("@LikeQuery", txtEnrollmentDate.Value);
                        break;                        
                }
                

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvListado.DataSource = dt;
                dgvListado.Refresh();
                con.Close();
            }

        }
    }
}
