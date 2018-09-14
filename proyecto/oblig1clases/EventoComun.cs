using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
   public class EventoComun:Evento
    {
        private int duracion;
        private static decimal montoFijoLimpieza = 100;

        // Propiedades
        public static decimal MontoFijoLimpieza
        {
            get { return montoFijoLimpieza; }
        }

        // Constructor
        public EventoComun(DateTime fecha, Turno turno, string descripcion, string nombreCliente, Servicio servicio, int cantPersonasServicio, int asistentes, string foto, int duracion) :base (fecha, turno, descripcion, nombreCliente, servicio, cantPersonasServicio, asistentes, foto)
        {
            this.duracion = duracion;
        }

        // Cambiar Monto Fijo Limpieza
        public static bool CambiarMontoFijoLimpieza(decimal nuevoValor)
        {
            bool cambiado = false;
            decimal valorAnterior = EventoComun.montoFijoLimpieza;
            EventoComun.montoFijoLimpieza = nuevoValor;
            if (valorAnterior != EventoComun.montoFijoLimpieza)
            {
                cambiado = true;
            }
            return cambiado;
        }

        // Calcular Costo
        public override decimal CalcularCosto()
        {
            decimal costo = 0;
            costo += base.CalcularCostosServiciosContratados() + montoFijoLimpieza;
            return costo;
        }

        // Actualizar Costo
        public override void ActualizarCosto(decimal costoServicio)
        {
            costoCalculado += costoServicio;
        }

        // ToString
        public override string ToString()
        {
            return "COD: " + id + " Evento Común  " + " FECHA: " + fecha.ToShortDateString() + " CLIENTE: " + nombreCliente + " DESC: " + descripcion + " PERSONAS: " + asistentes + " COSTO TOTAL: (inc. limpieza) " + costoCalculado;
        }





    }
}
