
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class clsDAO
    {
        public SqlConnection con;
        public clsDAO()
        {
            string str = "Server=DESKTOP-48DOANE\\SQLEXPRESS2017;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }
    }
}
