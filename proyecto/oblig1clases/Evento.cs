using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public abstract class Evento: IComparable<Evento>
    {
        // Atributos
        protected DateTime fecha;
        protected Turno turno;
        protected string descripcion;
        protected string nombreCliente;
        protected List<ServicioContratado> serviciosContratados = new List<ServicioContratado>();
        protected int asistentes;
        protected string foto;
        protected int id;
        protected static int idUlt = 1;
        protected decimal costoCalculado;

        // Propiedades
        public int ID
        {
            get { return id; }
        }
        public string Descripcion
        {
            get { return descripcion; }
        }
        public string NombreCliente
        {
            get { return nombreCliente; }
        }
        public string Foto
        {
            get {
                
                return "/img/" + this.foto; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
        }
        public int Asistentes
        {
            get { return asistentes; }
        }
        public decimal CostoCalculado
        {
            get { return costoCalculado; }
        }
        public string DatosVarios
        {
            get { return this.id + " - " + this.descripcion + " - " + this.fecha.ToShortDateString() + " - asistentes: " + this.asistentes ; }
        }

        // Constructor
        public Evento(DateTime fecha, Turno turno, string descripcion, string nombreCliente, Servicio servicio, int cantPersonasServicio, int asistentes, string foto)
        {
            this.fecha = fecha;
            this.turno = turno;
            this.descripcion = descripcion;
            this.nombreCliente = nombreCliente;
            this.asistentes = asistentes;
            this.foto = foto;
            serviciosContratados.Add(new ServicioContratado(servicio, cantPersonasServicio));
            this.id = Evento.idUlt;
            Evento.idUlt++;
            this.costoCalculado = CalcularCosto();
        }

        // Agregar Servicio Contratado
        public bool AgregarServicioContratado(Servicio servicio, int cantPersonas)
        {
            bool agregado = false;
            int cantServicios = serviciosContratados.Count;
            ServicioContratado servicioNuevo = new ServicioContratado(servicio, cantPersonas);
            serviciosContratados.Add(servicioNuevo);
            if (cantServicios < serviciosContratados.Count)
            {
                ActualizarCosto(servicioNuevo.CalcularCosto());
                agregado = true;
            }
            return agregado;
        }

        // Calcular Costos de Servicios Contratados
        public decimal CalcularCostosServiciosContratados()
        {
            decimal costo = 0;
            foreach (ServicioContratado servicioContratado in serviciosContratados)
            {
                costo += servicioContratado.CalcularCosto();
            }
            return costo;
        }

        // Calcular Costo
        public abstract decimal CalcularCosto();

        // Actualizar Costo
        public abstract void ActualizarCosto(decimal costoServicio);

        // Datos de mis servicios
        public string DatosDeMisServicios()
        {
            string datos = "";
            foreach (ServicioContratado serv in serviciosContratados)
            {
                datos += serv.ToString()+ "\n";
            }
            return datos;
        }

        // Tengo Este Servicio
        public bool TengoEsteServicio(Servicio servicio)
        {
            bool loTengo = false;
            int i = 0;
            while (i < serviciosContratados.Count && loTengo == false)
            {
                if (servicio != null)
                {
                    if (serviciosContratados[i].TengoEsteServicio(servicio))
                    {
                        loTengo = true;

                    }
                    i++;
                }
            }
            return loTengo;
        }

        // Ordenar por fecha desc
        public int CompareTo(Evento other)
        {
            return this.fecha.CompareTo(other.Fecha) * -1;
        }

        internal List<ServicioContratado> ServiciosContratados()
        {
            return this.serviciosContratados;
        }
    }
}
