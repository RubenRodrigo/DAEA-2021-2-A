﻿using System.Data.SqlClient;
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
    public partial class frmConDB : Form
    {
        // SqlConnection nos permite manejar el acceso al servidor
        SqlConnection conn;
        public frmConDB()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";

            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + user + ";Password=" + pwd + ";";
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado satisfactoriamente");                
                btnEstado.Enabled = true;
                btnDesconectar.Enabled = true;
                btnPersona.Enabled = true;
                btnCurso.Enabled = true;
                btnLog.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar el servidor: \n" + ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    MessageBox.Show("Estado del servidor: " + conn.State +
                        "\nVersión del servidor: " + conn.ServerVersion +
                        "\nBase de datos: " + conn.Database);
                else
                    MessageBox.Show("Estado del servidor" + conn.State);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del servidor: \n" +
                    ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("Conexion cerrada satisfactoriamente");
                    btnEstado.Enabled = false;
                    btnDesconectar.Enabled = false;
                    btnPersona.Enabled = false;
                    btnCurso.Enabled = false;
                    btnLog.Enabled = false;
                }
                else
                    MessageBox.Show("La conexión ya esta cerrada");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerrar la conexión: \n" +
                    ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Login login = new Login(conn);
            login.Show();
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso(conn);
            curso.Show();
        }

        private void frmConDB_Load(object sender, EventArgs e)
        {
            btnEstado.Enabled = false;
            btnDesconectar.Enabled = false;
            btnPersona.Enabled = false;
            btnCurso.Enabled = false;
            btnLog.Enabled = false;
        }
    }
}
