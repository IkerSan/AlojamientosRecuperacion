using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Establecimiento
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int IdCategoria { get; set; }

        public Establecimiento(int id, string nombreComercial, string direccion, string telefono, string email, int idCategoria)
        {
            Id = id;
            NombreComercial = nombreComercial;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            IdCategoria = idCategoria;
        }
    }
}
