using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string user = "admin";
            string pass = "hola mundo";

            string userTxt = txtUsuario.Text;
            string passTxt = txtPassword.Text;
            Console.WriteLine(userTxt);
            Console.WriteLine(passTxt);
            if (userTxt.Equals(user) && passTxt.Equals(pass))
            {
                Console.WriteLine("Coinciden");
                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
