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
        int? idPagoSeleccionado = null;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Pago> pagos = gestion.ObtenerPagos();
            dgvPagos.DataSource = pagos.Where(r => r.Id.ToString().Contains(textBox1.Text)).ToList();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que el clic no sea en el encabezado
            if (e.RowIndex >= 0)
            {
                // Obtener el valor de una celda específica (por nombre de columna o índice)
                var valor = dgvPagos.Rows[e.RowIndex].Cells["Id"].Value;

                idPagoSeleccionado = Convert.ToInt32(valor);
            }
        }

        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un pago para eliminar (la fila completa)");
                return;
            }
            else
            {
                if (gestion.EliminarPago(idPagoSeleccionado.Value))
                {
                    MessageBox.Show("Pago eliminado correctamente.");
                    dgvPagos.DataSource = gestion.ObtenerPagos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el pago.");
                }
            }
        }
    }
}
