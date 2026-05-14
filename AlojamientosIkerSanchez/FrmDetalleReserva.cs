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
            cboCliente.ValueMember = "Id"; // Importante para poder seleccionar por ID

            cboEstablecimiento.DataSource = gestion.ObtenerEstablecimientos();
            cboEstablecimiento.DisplayMember = "NombreComercial";
            cboEstablecimiento.ValueMember = "Id"; // Importante para poder seleccionar por ID

            cboEstado.DataSource = new List<string> { "PENDIENTE", "CONFIRMADA", "CANCELADA", "FINALIZADA" };

            // Cargamos las unidades iniciales
            ActualizarUnidadesAlojamiento();

            // Si es edición, rellenar los campos automáticamente
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                int idReserva = int.Parse(lblId.Text);
                var reserva = gestion.ObtenerReservas().FirstOrDefault(r => r.Id == idReserva);
                if (reserva != null)
                {
                    // Seleccionar cliente y establecimiento
                    cboCliente.SelectedValue = reserva.IdCliente;
                    cboEstablecimiento.SelectedValue = reserva.IdEstablecimiento;

                    // Seleccionar unidad
                    cboNumUnidad.SelectedValue = reserva.NumeroUnidad;

                    // Fechas y resto de datos
                    if (reserva.FechaEntrada >= dtpEntrada.MinDate) dtpEntrada.Value = reserva.FechaEntrada;
                    if (reserva.FechaSalida >= dtpSalida.MinDate) dtpSalida.Value = reserva.FechaSalida;
                    
                    txtInquilinos.Text = reserva.NumeroPersonas.ToString();
                    txtFianza.Text = reserva.Fianza?.ToString() ?? "";
                    
                    cboEstado.SelectedItem = reserva.Estado;
                    lblImporte.Text = reserva.ImporteEstimado.ToString();
                }
            }
        }

        private void cboEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarUnidadesAlojamiento();
        }

        private void ActualizarUnidadesAlojamiento()
        {
            if (cboEstablecimiento.SelectedItem is Establecimiento establecimientoSeleccionado)
            {
                int numUnidadReserva = -1;
                // Si estamos editando, obtener el numero de unidad original para mostrarla aunque esté OCUPADA
                if (!string.IsNullOrEmpty(lblId.Text)) 
                {
                    int idReserva = int.Parse(lblId.Text);
                    var reserva = gestion.ObtenerReservas().FirstOrDefault(r => r.Id == idReserva);
                    if (reserva != null) numUnidadReserva = reserva.NumeroUnidad;
                }

                var unidades = gestion.ObtenerUnidadesAlojamiento()
                                      .Where(u => u.IdEstablecimiento == establecimientoSeleccionado.Id && 
                                                  (u.Estado == "DISPONIBLE" || u.NumeroUnidad == numUnidadReserva))
                                      .ToList();
                
                cboNumUnidad.DataSource = unidades;
                cboNumUnidad.DisplayMember = "NombreUnidad";
                cboNumUnidad.ValueMember = "NumeroUnidad"; // Para poder seleccionarla por código
            }
            else
            {
                cboNumUnidad.DataSource = null;
            }
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
            if (dtpSalida.Value <= dtpEntrada.Value)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada");
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
                
                // Actualizar estado de la unidad a OCUPADA
                gestion.ActualizarEstadoUnidad(((Establecimiento)cboEstablecimiento.SelectedItem).Id, ((UnidadAlojamiento)cboNumUnidad.SelectedItem).NumeroUnidad, "OCUPADA");
                
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
            
                // Actualizar estado de la unidad a OCUPADA
                gestion.ActualizarEstadoUnidad(((Establecimiento)cboEstablecimiento.SelectedItem).Id, ((UnidadAlojamiento)cboNumUnidad.SelectedItem).NumeroUnidad, "OCUPADA");
            
                //ID de la reserva actual
                idReservaActual = int.Parse(lblId.Text);
                mensaje = "Reserva actualizada con éxito. Importe total: " + importeTotal.ToString() + "\n\n¿Quieres crear un nuevo pago a partir de esta reserva?";
            }

            // Mostramos el mensaje con opciones de Sí/No
            DialogResult result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Ocultamos la reserva
                this.Hide(); 
                // Abrimos el formulario de detalles de pago, pasándole el ID de la reserva
                FrmDetallePago frmDetallePago = new FrmDetallePago(null, idReservaActual);
                frmDetallePago.FormClosed += (s, args) => this.Close(); // Cerramos definitivamente al salir del pago
                frmDetallePago.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }
    }
}
