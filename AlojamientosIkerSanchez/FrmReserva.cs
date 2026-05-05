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
using CapaDatos;

namespace AlojamientosIkerSanchez
{
    public partial class FrmReserva : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;
        int? idReservaSeleccionada = null;
        public FrmReserva()
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorServidor))
            {
                MessageBox.Show("Error al conectar con el servidor: " + errorServidor);
                return;
            }

            List<Reserva> reservas = gestion.ObtenerReservas();
            if (reservas == null)
            {
                MessageBox.Show("Error al obtener los clientes: " + errorServidor);
                return;
            }
            else
            {
                dgvReservas.DataSource = reservas;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Reserva> reservas = gestion.ObtenerReservas();
            dgvReservas.DataSource = reservas.Where(r => r.Id.ToString().Contains(textBox1.Text)).ToList();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que el clic no sea en el encabezado
            if (e.RowIndex >= 0)
            {
                // Obtener el valor de una celda específica (por nombre de columna o índice)
                var valor = dgvReservas.Rows[e.RowIndex].Cells["Id"].Value;
               
                idReservaSeleccionada = Convert.ToInt32(valor); 
            }
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una reserva para eliminar (la fila completa)");
                return;
            }
            else
            {
                if (gestion.EliminarReserva(idReservaSeleccionada.Value))
                {
                    MessageBox.Show("Reserva eliminada correctamente.");
                    dgvReservas.DataSource = gestion.ObtenerReservas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la reserva.");
                }
            }
        }
    }
}
