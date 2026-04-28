using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdEstablecimiento { get; set; }
        public int NumeroUnidad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroPersonas { get; set; }
        public string Estado { get; set; }
        public float? Fianza { get; set; }
        public float ImporteEstimado { get; set; }


        public Reserva(int id, int idCliente, int idEstablecimiento, int numeroUnidad, DateTime fechaCreacion, DateTime fechaEntrada, DateTime fechaSalida, int numeroPersonas, string estado, float? fianza, float importeEstimado)
        {
            Id = id;
            IdCliente = idCliente;
            IdEstablecimiento = idEstablecimiento;
            NumeroUnidad = numeroUnidad;
            FechaCreacion = fechaCreacion;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            NumeroPersonas = numeroPersonas;
            Estado = estado;
            Fianza = fianza;
            ImporteEstimado = importeEstimado;
        }
    }
}
