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
using System.Diagnostics.Eventing.Reader;

namespace AlojamientosIkerSanchez
{
    public partial class FrmDetallePago : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;
        // Permite recibir un ID de reserva inicial de forma opcional para precargar el campo
        public FrmDetallePago(int? idPago, int? idReservaInicial = null)
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
            if (idPago.HasValue)
            {
                lblId.Text = idPago.Value.ToString();
            }
            if (idReservaInicial.HasValue)
            {
                // Asigna automáticamente el ID de la reserva si venimos de crear/editar una
                txtIdReserva.Text = idReservaInicial.Value.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDetallePago_Load(object sender, EventArgs e)
        {
            cboMetodopago.DataSource = new List<string> { "Efectivo", "Tarjeta", "Transferencia" };

            // Si es edición, rellenar los campos automáticamente
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                int idPago = int.Parse(lblId.Text);
                var pago = gestion.ObtenerPagos().FirstOrDefault(p => p.Id == idPago);
                if (pago != null)
                {
                    // Asignar ID de la reserva
                    txtIdReserva.Text = pago.IdReserva.ToString();
                    
                    // Asignar fecha del pago comprobando los límites
                    if (pago.FechaPago.HasValue && pago.FechaPago.Value >= dtpFechaPago.MinDate)
                    {
                        dtpFechaPago.Value = pago.FechaPago.Value;
                    }
                    
                    // Asignar método de pago
                    cboMetodopago.SelectedItem = pago.MetodoPago;
                    
                    // Asignar importe
                    txtImporte.Text = pago.Importe.ToString();
                }
            }
        }

        private void btnEditarPago_Click(object sender, EventArgs e)
        {
            if (txtIdReserva.Text == "" || txtIdReserva.Text == null || int.Parse(txtIdReserva.Text) <= 0)
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

            if (lblId.Text == "" || lblId.Text == null)
            {
                // Si no hay ID, crear nuevo pago
                gestion.AgregarPago(
                    idReserva: Convert.ToInt32(txtIdReserva.Text),
                    importe: float.Parse(txtImporte.Text),
                    fechaPago: dtpFechaPago.Value,
                    metodoPago: cboMetodopago.SelectedItem.ToString()
                );
                MessageBox.Show("Pago creado correctamente.");
                this.Close();
            }
            else
            {
                int pagoActualId = Convert.ToInt32(lblId.Text);
                int nuevaReservaId = Convert.ToInt32(txtIdReserva.Text);

                // Si hay ID, editar pago existente
                gestion.EditarPago(
                id: pagoActualId,
                idReserva: nuevaReservaId,
                importe: float.Parse(txtImporte.Text),
                fechaPago: dtpFechaPago.Value,
                metodoPago: cboMetodopago.SelectedItem.ToString()
                );
                MessageBox.Show("Pago editado correctamente.");
            }

            
        }
    }
}