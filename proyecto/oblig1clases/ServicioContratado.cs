using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class ServicioContratado
    {
        private int cantPersonas;
        private Servicio servicio;
        private decimal precioPorPersona;

        public string NombreServicio
        {
            get { return this.servicio.Nombre; }

        }

        public decimal CostoPorPersona
        {
            get { return this.precioPorPersona; }

        }

        public int CantPersonas
        {
            get { return this.cantPersonas; }

        }



        // Constructor
        public ServicioContratado(Servicio servicio, int cantPersonas)
        {
            this.servicio = servicio;
            this.cantPersonas = cantPersonas;
            this.precioPorPersona = servicio.PrecioPorPersona;
        }


        // Calcular Costo
        public decimal CalcularCosto()
        {
            return cantPersonas * precioPorPersona;
        }

        // ToString
        public override string ToString()
        {
            return "SERVICIO: " + servicio.Nombre + " PERSONAS: " + cantPersonas + " PRECIO POR PERSONA: " + precioPorPersona + " COSTO: " + CalcularCosto();
        }

        // Tengo Este Servicio
        public bool TengoEsteServicio(Servicio servicio)
        {
            bool loTengo = false;
            if (this.servicio == servicio)
            {
                loTengo = true;
            }
            return loTengo;
        }



    }
}
