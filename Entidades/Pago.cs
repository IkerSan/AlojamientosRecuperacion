using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public float Importe { get; set; }
        public DateTime? FechaPago { get; set; }
        public string MetodoPago { get; set; }

        public Pago(int id, int idReserva, float importe, DateTime? fechaPago, string metodoPago)
        {
            Id = id;
            IdReserva = idReserva;
            Importe = importe;
            FechaPago = fechaPago;
            MetodoPago = metodoPago;
        }
    }
}
