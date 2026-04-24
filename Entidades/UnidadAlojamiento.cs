using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UnidadAlojamiento
    {
        public int IdEstablecimiento { get; set; }
        public int NumeroUnidad { get; set; }
        public string NombreUnidad { get; set; }
        public int CapacidadMaxima { get; set; }
        public string Estado { get; set; }
        public float PrecioBaseNoche { get; set; }
        public string Descripcion { get; set; }

        public UnidadAlojamiento(int idEstablecimiento, int numeroUnidad, string nombreUnidad, int capacidadMaxima, string estado, float precioBaseNoche, string descripcion)
        {
            IdEstablecimiento = idEstablecimiento;
            NumeroUnidad = numeroUnidad;
            NombreUnidad = nombreUnidad;
            CapacidadMaxima = capacidadMaxima;
            Estado = estado;
            PrecioBaseNoche = precioBaseNoche;
            Descripcion = descripcion;
        }
    }
}
