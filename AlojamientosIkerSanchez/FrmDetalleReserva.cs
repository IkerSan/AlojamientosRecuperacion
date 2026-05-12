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
    public partial class FrmDetalleReserva : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;
        public FrmDetalleReserva(int? idReserva)
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
            if (idReserva.HasValue)
            {
                lblId.Text = idReserva.Value.ToString();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void FrmDetalleReserva_Load(object sender, EventArgs e)
        {
            txtInquilinos.KeyPress += Numerico_KeyPress;
            txtFianza.KeyPress += Numerico_KeyPress;

            cboCliente.DataSource = gestion.ObtenerClientes();
            cboCliente.DisplayMember = "Nombre";

            cboEstablecimiento.DataSource = gestion.ObtenerEstablecimientos();
            cboEstablecimiento.DisplayMember = "NombreComercial";

            Establecimiento establecimientoSeleccionado = (Establecimiento)cboEstablecimiento.SelectedItem;
            if (establecimientoSeleccionado != null)
            {
                cboNumUnidad.DataSource = gestion.ObtenerUnidadesAlojamiento().Where(u => u.IdEstablecimiento == establecimientoSeleccionado.Id).ToList();
                cboNumUnidad.DisplayMember = "NombreUnidad";
            }

            cboEstado.DataSource = new List<string> { "PENDIENTE", "CONFIRMADA", "CANCELADA", "FINALIZADA" };
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validar campos
            if (cboCliente.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente");
                return;
            }
            if (cboEstablecimiento.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un establecimiento");
                return;
            }
            if (cboNumUnidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un número de unidad");
                return;
            }
            if (dtpEntrada.Value == null || dtpEntrada.Value < DateTime.Today)
            {
                MessageBox.Show("Por favor, seleccione una fecha de entrada válida");
                return;
            }
            if (dtpSalida.Value == null || dtpSalida.Value < DateTime.Today)
            {
                MessageBox.Show("Por favor, seleccione una fecha de salida válida");
                return;
            }
            int inquilinos;
            if (string.IsNullOrWhiteSpace(txtInquilinos.Text) || !int.TryParse(txtInquilinos.Text, out inquilinos) || inquilinos <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido de inquilinos");
                return;
            }
            if (cboEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado");
                return;
            }
            float? fianza = null;
            if (!string.IsNullOrWhiteSpace(txtFianza.Text))
            {
                float fianzaTemp;
                if (!float.TryParse(txtFianza.Text, out fianzaTemp) || fianzaTemp < 0)
                {
                    MessageBox.Show("Por favor, ingrese un importe de fianza válido (no negativo). Deje el campo vacío si no requiere fianza.");
                    return;
                }
                fianza = fianzaTemp;
            }

            // Calcular importe total
            int nochesTotales = (dtpSalida.Value.Date - dtpEntrada.Value.Date).Days;
            if (nochesTotales <= 0) nochesTotales = 1; // Mínimo 1 noche
            UnidadAlojamiento unidadSeleccionada = (UnidadAlojamiento)cboNumUnidad.SelectedItem;
            float importeTotal = (nochesTotales * (float)unidadSeleccionada.PrecioBaseNoche) + (fianza ?? 0);
            lblImporte.Text = importeTotal.ToString();

            int idReservaActual = 0;
            string mensaje;

            if (lblId.Text == "" || lblId == null)
            {
                // Si no hay ID, crear nueva reserva
                gestion.AgregarReserva(
                    ((Clientela)cboCliente.SelectedItem).Id,
                    ((Establecimiento)cboEstablecimiento.SelectedItem).Id,
                    ((UnidadAlojamiento)cboNumUnidad.SelectedItem).NumeroUnidad,
                    DateTime.Today,
                    dtpEntrada.Value,
                    dtpSalida.Value,
                    inquilinos,
                    cboEstado.SelectedItem.ToString(),
                    fianza,
                    importeTotal
                );
                
                // Obtenemos el ID de la reserva recién creada para usarlo si queremos crear un pago
                var reservas = gestion.ObtenerReservas();
                if (reservas != null && reservas.Count > 0)
                {
                    idReservaActual = reservas.Max(r => r.Id);
                }
                
                mensaje = "Reserva creada con éxito. Importe total: " + importeTotal.ToString() + "\n\n¿Quieres crear un nuevo pago a partir de esta reserva?";
            }
            else
            {
                // Editar reserva existente si hay ID           
                gestion.EditarReserva(
                int.Parse(lblId.Text),
                ((Clientela)cboCliente.SelectedItem).Id,
                ((Establecimiento)cboEstablecimiento.SelectedItem).Id,
                ((UnidadAlojamiento)cboNumUnidad.SelectedItem).NumeroUnidad,
                DateTime.Today,
                dtpEntrada.Value,
                dtpSalida.Value,
                inquilinos,
                cboEstado.SelectedItem.ToString(),
                fianza,
                importeTotal
            );
                // Si estamos editando, ya sabemos cuál es el ID de la reserva actual
                idReservaActual = int.Parse(lblId.Text);
                mensaje = "Reserva actualizada con éxito. Importe total: " + importeTotal.ToString() + "\n\n¿Quieres crear un nuevo pago a partir de esta reserva?";
            }

            // Mostramos el mensaje con opciones de Sí/No
            DialogResult result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Ocultamos la reserva para que el menú principal no salte por encima al cerrarse
                this.Hide(); 
                // Abrimos el formulario de detalles de pago, pasándole el ID de la reserva
                FrmDetallePago frmDetallePago = new FrmDetallePago(null, idReservaActual);
                frmDetallePago.FormClosed += (s, args) => this.Close(); // Cerramos definitivamente al salir del pago
                frmDetallePago.ShowDialog();
            }
            else
            {
                this.Close(); // Cerramos y volvemos a la ventana anterior
            }
        }
    }
}
