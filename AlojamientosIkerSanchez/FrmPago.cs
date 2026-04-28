using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlojamientosIkerSanchez
{
    public partial class FrmPago : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;
        public FrmPago()
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorServidor))
            {
                MessageBox.Show("Error al conectar con el servidor: " + errorServidor);
                return;
            }

            List<Pago> pagos = gestion.ObtenerPagos();
            if (pagos == null)
            {
                MessageBox.Show("Error al obtener los clientes: " + errorServidor);
                return;
            }
            else
            {
                dgvPagos.DataSource = pagos;
            }
        }
    }
}
