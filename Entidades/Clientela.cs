using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientela
    {
        public int Id { get; set; }
        public string DniNie { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Clientela(int id, string dniNie, string nombre, string telefono, string email)
        {
            Id = id;
            DniNie = dniNie;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }
    }
}
