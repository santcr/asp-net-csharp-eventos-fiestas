using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class Organizador : Usuario
    {
        private string nombre;
        private string telefono;
        private string direccion;
        private DateTime fechaRegistro;
        private List<Evento> eventos = new List<Evento>();

        public List<Evento> Eventos
        {
            get { return this.eventos; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Telefono
        {
            get { return telefono; }
        }
        public string Direccion
        {
            get { return direccion; }
        }
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
        }


        // Constructor
        public Organizador(string mail, string contrasenia, string nombre, string telefono, string direccion) :base(mail, contrasenia)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            fechaRegistro = DateTime.Today;
        }

        // Mi Rol
        public override string MiRol()
        {
            return "Organizador";
        }

        // Agregar Evento
        public bool AgregarEvento(Evento evento)
        {
            bool agregado = false;
            int cantEventos = eventos.Count;
            if (evento != null)
            {
                eventos.Add(evento);
            }
            if (cantEventos < eventos.Count)
            {
                agregado = true;
            }
            return agregado;
        }

        // Listar Eventos STRING
        public override string ListarEventos()
        {
            string lista = "---Mis eventos---" + "\n";
            decimal total = 0;
            foreach (Evento evento in eventos)
            {
                lista += evento.ToString() + "\n";
                total += evento.CostoCalculado;
            }
            lista += "TOTAL GENERADO: " + total;
            if (eventos.Count == 0)
            {
                lista = "---No tengo ningún evento---";
            }
            return lista;
        }

        // Total Generado por mis Eventos
        public decimal TotalGeneradoPorMisEventos()
        {
            decimal total = 0;
            foreach (Evento evento in eventos)
            {
                total += evento.CostoCalculado;
            }
            return total;
        }



        // Mis Datos
        public string MisDatos()
        {
            return "NOMBRE: " + nombre + " TEL: " + telefono + " DIR: " + direccion + " REGISTRADO: " + fechaRegistro.ToShortDateString();
        }

        // To String
        public override string ToString()
        {
            return base.ToString() + " " + MisDatos();
        }


        public List<Evento> MisEventosEntreFechasOrdenados(DateTime fecha1, DateTime fecha2)
        {
            List<Evento> lista = new List<Evento>();
            foreach (Evento evento in eventos)
            {
                if (evento.Fecha >= fecha1 &&
                    evento.Fecha <= fecha2)
                {
                    lista.Add(evento);
                }
            }
            lista.Sort();
            return lista;
        }


    }
}
