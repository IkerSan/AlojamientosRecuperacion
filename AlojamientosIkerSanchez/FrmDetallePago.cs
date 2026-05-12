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
                // Comprobar que la reserva no tenga ya un pago (Máximo 1 pago por reserva)
                var pagosExistentes = gestion.ObtenerPagos().Where(p => p.IdReserva == Convert.ToInt32(txtIdReserva.Text)).ToList();
                if (pagosExistentes.Count > 0)
                {
                    MessageBox.Show("Esta reserva ya tiene un pago registrado. Solo se permite un máximo de 1 pago por reserva.");
                    return;
                }

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

                // Comprobar que si ha cambiado de reserva, la nueva reserva no tenga ya otro pago distinto a este
                var pagosExistentes = gestion.ObtenerPagos().Where(p => p.IdReserva == nuevaReservaId && p.Id != pagoActualId).ToList();
                if (pagosExistentes.Count > 0)
                {
                    MessageBox.Show("La reserva especificada ya tiene otro pago registrado. Solo se permite un máximo de 1 pago por reserva.");
                    return;
                }

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