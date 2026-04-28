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
    }
}
