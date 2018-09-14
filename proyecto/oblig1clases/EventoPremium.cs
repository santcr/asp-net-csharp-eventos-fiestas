using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class EventoPremium:Evento
    {
        private static int porcentajeDeAumento = 15;

        // Propiedades
        public static int PorcentajeDeAumento
        {
            get { return porcentajeDeAumento; }
        }

        // Constructor
        public EventoPremium(DateTime fecha, Turno turno, string descripcion, string nombreCliente, Servicio servicio, int cantPersonasServicio, int asistentes, string foto) : base(fecha, turno, descripcion, nombreCliente, servicio, cantPersonasServicio, asistentes, foto)
        {

        }

        // Cambiar Porcentaje De Aumento
        public static bool CambiarPorcentajeDeAumento(int nuevoValor)
        {
            bool cambiado = false;
            int valorAnterior = EventoPremium.porcentajeDeAumento;
            EventoPremium.porcentajeDeAumento = nuevoValor;
            if (valorAnterior != EventoPremium.porcentajeDeAumento)
            {
                cambiado = true;
            }
            return cambiado;
        }

        // Calcular Costo
        public override decimal CalcularCosto()
        {
            decimal costo = 0;
            costo += base.CalcularCostosServiciosContratados() * porcentajeDeAumento;
            return costo;
        }

        // Actualizar Costo
        public override void ActualizarCosto(decimal costoServicio)
        {
            costoCalculado += costoServicio * porcentajeDeAumento;
        }

        // ToString
        public override string ToString()
        {
            return "COD: " + id + " Evento Premium" + " FECHA: " + fecha.ToShortDateString() + " CLIENTE: " + nombreCliente + " DESC: " + descripcion + " PERSONAS: " + asistentes + " COSTO TOTAL: " + costoCalculado;
        }




    }
}
