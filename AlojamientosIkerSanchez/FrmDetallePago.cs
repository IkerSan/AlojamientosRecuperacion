using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AlojamientosIkerSanchez
{
    public partial class FrmDetallePago : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;
        public FrmDetallePago(int? idPago)
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
            if (idPago.HasValue)
            {
                lblId.Text = idPago.Value.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDetallePago_Load(object sender, EventArgs e)
        {
            cboMetodopago.DataSource = new List<string> {"Efectivo", "Tarjeta", "Transferencia"};
        }

        private void btnEditarPago_Click(object sender, EventArgs e)
        {
            if(txtIdReserva.Text == "" || txtIdReserva.Text == null || int.Parse(txtIdReserva.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un ID de reserva válido.");
                return;
            }
            if (dtpFechaPago.Value == null || dtpFechaPago.Value < DateTime.Today)
            {
                MessageBox.Show("Por favor, seleccione una fecha de pago válida.");
                return;
            }
            if (cboMetodopago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.");
                return;
            }
            if (txtImporte.Text == "" || txtImporte.Text == null || float.Parse(txtImporte.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un importe válido.");
                return;
            }
         
            gestion.EditarPago(
                id: Convert.ToInt32(lblId.Text),
                idReserva: Convert.ToInt32(txtIdReserva.Text),
                importe: float.Parse(txtImporte.Text),
                fechaPago: dtpFechaPago.Value,
                metodoPago: cboMetodopago.SelectedItem.ToString()
            );
            MessageBox.Show("Pago editado correctamente.");
        }
    }
}
