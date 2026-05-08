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

        private void FrmDetalleReserva_Load(object sender, EventArgs e)
        {
            cboCliente.DataSource = gestion.ObtenerClientes();
            cboCliente.DisplayMember = "Nombre";
            
            cboEstablecimiento.DataSource = gestion.ObtenerEstablecimientos();
            cboEstablecimiento.DisplayMember = "NombreComercial";
            
            Establecimiento establecimientoSeleccionado = (Establecimiento)cboEstablecimiento.SelectedItem;
            cboNumUnidad.DataSource = gestion.ObtenerUnidadesAlojamiento().Where(u => u.IdEstablecimiento == establecimientoSeleccionado.Id).ToList();
            cboNumUnidad.DisplayMember = "NombreUnidad";
            
            cboEstado.DataSource = new List<string> { "PENDIENTE", "CONFIRMADA", "CANCELADA", "FINALIZADA"};
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

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
            if (txtInquilinos.Text == null || txtInquilinos.Text == "" || int.Parse(txtInquilinos.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido de inquilinos");
                return;
            }
            if (cboEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado");
                return;
            }
            if (txtFianza.Text == null || txtFianza.Text == "" || float.Parse(txtFianza.Text) <= 0)
            {
                MessageBox.Show("Por favor, ingrese un importe válido de fianza");
                return;
            }

            int nochesTotales = (dtpSalida.Value - dtpEntrada.Value).Days;
            UnidadAlojamiento unidadSeleccionada = (UnidadAlojamiento)cboNumUnidad.SelectedItem;
            float importeTotal = (nochesTotales * (float)unidadSeleccionada.PrecioBaseNoche) + float.Parse(txtFianza.Text);

            lblImporte.Text = importeTotal.ToString();
            gestion.EditarReserva(
                int.Parse(lblId.Text),
                ((Clientela)cboCliente.SelectedItem).Id,
                ((Establecimiento)cboEstablecimiento.SelectedItem).Id,
                ((UnidadAlojamiento)cboNumUnidad.SelectedItem).NumeroUnidad,
                DateTime.Today, 
                dtpEntrada.Value,
                dtpSalida.Value,
                int.Parse(txtInquilinos.Text),
                cboEstado.SelectedItem.ToString(),
                float.Parse(txtFianza.Text), 
                importeTotal 
            );
            MessageBox.Show("Reserva actualizada con éxito. Importe total: " + importeTotal.ToString());
        }

 
    }
}
