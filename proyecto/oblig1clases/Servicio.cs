using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class Servicio
    {
        private string nombre;
        private string descripcion;
        private decimal precioPorPersona;

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
        }
        public decimal PrecioPorPersona
        {
            get { return precioPorPersona; }
        }
        public string PrecioPorPersonaString
        {
            get { return precioPorPersona.ToString() + " por persona" ; }
        }

        // Constructor
        public Servicio(string nombre, string descripcion, decimal precioPorPersona)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precioPorPersona = precioPorPersona;
        }

        // ToString
        public override string ToString()
        {
            return nombre + " - $" + precioPorPersona + " por persona" + " - " + descripcion;
        }




    }
}
