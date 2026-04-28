using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Entidades;

namespace AlojamientosIkerSanchez
{
    public partial class FrmConsultasBasicas : Form
    {
        string errorServidor;
        GestionAlojamientos gestion;

        public FrmConsultasBasicas()
        {
            InitializeComponent();
            gestion = new GestionAlojamientos(out errorServidor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorServidor))
            {
                MessageBox.Show("Error al conectar con el servidor: " + errorServidor);
                return;
            }

            List<Clientela> clientes = gestion.ObtenerClientes();
            if (clientes == null)
            {
                MessageBox.Show("Error al obtener los clientes: " + errorServidor);
                return;
            }
            else
            {
                dgvConsultas.DataSource = clientes;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEstablecimientos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorServidor))
            {
                MessageBox.Show("Error al conectar con el servidor: " + errorServidor);
                return;
            }

            List<Establecimiento> establecimientos = gestion.ObtenerEstablecimientos();
            if (establecimientos == null)
            {
                MessageBox.Show("Error al obtener los clientes: " + errorServidor);
                return;
            }
            else
            {
                dgvConsultas.DataSource = establecimientos;
            }
        }

        private void btnUnidadesAlojamiento_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorServidor))
            {
                MessageBox.Show("Error al conectar con el servidor: " + errorServidor);
                return;
            }

            List<UnidadAlojamiento> unidadesAlojamiento = gestion.ObtenerUnidadesAlojamiento();
            if (unidadesAlojamiento == null)
            {
                MessageBox.Show("Error al obtener los clientes: " + errorServidor);
                return;
            }
            else
            {
                dgvConsultas.DataSource = unidadesAlojamiento;
            }
        }

        private void FrmConsultasBasicas_Load(object sender, EventArgs e)
        {

        }
    }
}
