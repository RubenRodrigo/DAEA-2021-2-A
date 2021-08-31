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
    public partial class PrincipalMDI : Form
    {
        public PrincipalMDI()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuManUsuarios_Click(object sender, EventArgs e)
        {
            manUsuario frm = new manUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManProductos_Click(object sender, EventArgs e)
        {
            manProducto frm = new manProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManCategorias_Click(object sender, EventArgs e)
        {
            manCategoria frm = new manCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManProveedores_Click(object sender, EventArgs e)
        {
            manProveedor frm = new manProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManClientes_Click(object sender, EventArgs e)
        {
            manCliente frm = new manCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProcRegistrarVenta_Click(object sender, EventArgs e)
        {
            regVentas frm = new regVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProcRegistrarCompra_Click(object sender, EventArgs e)
        {
            regCompras frm = new regCompras();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepVentas_Click(object sender, EventArgs e)
        {
            repVentas frm = new repVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepCompras_Click(object sender, EventArgs e)
        {
            repCompras frm = new repCompras();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepInventarioProductos_Click(object sender, EventArgs e)
        {
            repInventario frm = new repInventario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepProveedores_Click(object sender, EventArgs e)
        {
            repProveedores frm = new repProveedores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepUsuarios_Click(object sender, EventArgs e)
        {
            repUsuarios frm = new repUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuRepClientes_Click(object sender, EventArgs e)
        {
            repClientes frm = new repClientes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
