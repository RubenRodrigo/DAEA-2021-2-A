using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class clsDAOPerson:clsDAO
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();

            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            con.Close();

            return dt;
        }

        public DataTable GetByValue(String strValue)
        {
            DataTable dt = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "FindPersonByFirstName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@FirstName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = strValue;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            con.Close();
            return dt;
        }
    }
}
