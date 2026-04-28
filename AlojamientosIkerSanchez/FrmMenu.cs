using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AlojamientosIkerSanchez
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void consultasBásicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultasBasicas consultas = new FrmConsultasBasicas();
            consultas.FormClosed += (s, args) => this.Show();
            consultas.Show();
            this.Hide();
        }

        private void gestiónReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReserva reserva = new FrmReserva();
            reserva.FormClosed += (s, args) => this.Show();
            reserva.Show();
            this.Hide();
        }

        private void detallesDeReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleReserva detalleReserva = new FrmDetalleReserva();
            detalleReserva.FormClosed += (s, args) => this.Show();
            detalleReserva.Show();
            this.Hide();
        }

        private void gestiónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPago pago = new FrmPago();
            pago.FormClosed += (s, args) => this.Show();
            pago.Show();
            this.Hide();
        }

        private void detallesDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallePago detallePago = new FrmDetallePago();
            detallePago.FormClosed += (s, args) => this.Show();
            detallePago.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
