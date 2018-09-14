using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class Empresa
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Servicio> servicios = new List<Servicio>();
        private List<Evento> eventos = new List<Evento>();
        private static Empresa instancia;

        public static Empresa Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Empresa();
                }
                return instancia;
            }
        }

        public List<Servicio> Servicios
        {
            get { return servicios; }
        }


        // Constructor
        public Empresa()
        {
            PrecargarDatos();
        }

        // Precargar Datos
        private void PrecargarDatos()
        {
            AltaServicio("Cabalgata", "Un recorrido a caballo por un maravilloso paisaje.", 200);
            AltaServicio("Comida", "Exelentes platos de comida muy rica.", 400);
            AltaServicio("Parrilla", "Variedad de exquisitas carnes a la parrilla.", 550);
            AltaServicio("Cotillon", "Chucherias para una fiesta bien divertida.", 120);

            AltaAdministrador("admin@eventos17.com", "Admin!99");

            AltaOrganizador("org@eventos17.com", "Org!9999", "Carlos", "099542788", "Calle 123");
            AltaOrganizador("lucas@mail.com", "Lucas!111", "Lucas", "0996556545", "Avenida 456");

            AltaEventoComun(new DateTime(2018, 10, 01), "tarde", "Cumpleaños de mi tío.", "Eduardo Gonzalez", "Parrilla", 9, 9, "evento01.jpg", 3);
            AgregarServicioEvento("Cabalgata", 7, new DateTime(2018, 10, 01));
            AgregarEventoOrganizador(new DateTime(2018, 10, 01), "org@eventos17.com");

            AltaEventoPremium(new DateTime(2018, 03, 12), "noche", "Aniversario del club.", "Alberto P.", "Comida", 75, 100, "evento02.jpg");
            AgregarServicioEvento("Parrilla", 25, new DateTime(2018, 03, 12));
            AgregarEventoOrganizador(new DateTime(2018, 03, 12), "org@eventos17.com");

            AltaEventoComun(new DateTime(2018, 05, 30), "mañana", "Reunión de amigos.", "Eduardo Gonzalez", "Cabalgata", 7, 9, "evento05.jpg", 4);
            AgregarEventoOrganizador(new DateTime(2018, 05, 30), "org@eventos17.com");

            AltaEventoComun(new DateTime(2018, 07, 27), "tarde", "Reunión de negocios.", "Fernando P.", "Comida", 7, 7, "evento03.jpeg", 4);
            AgregarEventoOrganizador(new DateTime(2018, 07, 27), "lucas@mail.com");

            AltaEventoPremium(new DateTime(2019, 04, 08), "noche", "Cumpleaños de Roberto.", "Alberto P.", "Parrilla", 75, 100, "evento04.jpg");
            AgregarServicioEvento("Cabalgata", 33, new DateTime(2019, 04, 08));
            AgregarServicioEvento("Cotillon", 99, new DateTime(2019, 04, 08));
            AgregarEventoOrganizador(new DateTime(2019, 04, 08), "lucas@mail.com");
        }



        // Buscar Servicio
        public Servicio BuscarServicio(string nombre)
        {
            // Busca un servicio según su nombre y lo devuelve, si no existe devuelve null
            Servicio servicio = null;
            int i = 0;
            while (i < servicios.Count && servicio == null)
            {
                if (servicios[i].Nombre == nombre)
                {
                    servicio = servicios[i];
                }
                i++;
            }
            return servicio;
        }

        // Alta Servicio
        public bool AltaServicio(string nombre, string descripcion, decimal precioPorPersona)
        {
            bool alta = false;
            Servicio servicio = BuscarServicio(nombre);
            int cantServicios = servicios.Count;
            if (servicio == null)
            {
                servicios.Add(new Servicio(nombre, descripcion, precioPorPersona));
            }
            if (cantServicios < servicios.Count)
            {
                alta = true;
            }
            return alta;
        }
        
        // Listar Servicios
        public string ListarServicios()
        {
            // Lista todos los servicios existentes
            string lista = "";
            foreach (Servicio servicio in servicios)
            {
                lista += servicio.ToString() + "\n";
            }
            return lista;
        }




        // Buscar Usuario
        public Usuario BuscarUsuario(string mail)
        {
            // Busca un usuario según su mail y lo devuelve, null si no está registrado
            Usuario usuario = null;
            int i = 0;
            while (i<usuarios.Count && usuario == null)
            {
                if (usuarios[i].Mail == mail)
                {
                    usuario = usuarios[i];
                }
                i++;
            }
            return usuario;
        }

        // Validar Usuario y su contrasenia, y devuelve su rol
        public string ValidarUsuario(string mail, string contrasenia)
        {
            string rol = "";
            Usuario usuario = BuscarUsuario(mail);
            if (usuario != null && usuario.Contrasenia == contrasenia)
            {
                rol = usuario.MiRol();
            }
            return rol;
        }
        

        // Alta Administrador
        public bool AltaAdministrador(string mail, string contrasenia)
        {
            bool alta = false;
            Usuario usuario = BuscarUsuario(mail);
            int cantUsuarios = usuarios.Count;
            bool datosValidados = ValidarMail(mail) && ValidarContrasenia(contrasenia);
            if (usuario == null && datosValidados)
            {
                usuarios.Add(new Usuario(mail, contrasenia));
            }
            if (cantUsuarios < usuarios.Count)
            {
                alta = true;
            }
            return alta;
        }

        // Alta Organizador
        public bool AltaOrganizador(string mail, string contrasenia, string nombre, string telefono, string direccion)
        {
            bool alta = false;
            Usuario usuario = BuscarUsuario(mail);
            int cantUsuarios = usuarios.Count;
            bool datosValidados = ValidarMail(mail) && ValidarContrasenia(contrasenia) && ValidarNombre(nombre);
            if (usuario == null && datosValidados)
            {
                usuarios.Add(new Organizador(mail, contrasenia, nombre, telefono, direccion));
            }
            if (cantUsuarios < usuarios.Count)
            {
                alta = true;
            }
            return alta;
        }

        // Validar si Usuario es Organizador
        public bool UsuarioEsOrganizador(string mail)
        {
            // Devuelve true si el usuario es de la clase Organizador
            bool validado = false;
            Usuario usuario = BuscarUsuario(mail);
            if (usuario != null && usuario.MiRol() == "Organizador")
            {
                validado = true;
            }
            return validado;
        }

        // Datos de Organizador
        public string DatosDeOrganizador(string mail)
        {
            // Devuelve los datos del Organizador
            string datos = "";
            Usuario usuario = BuscarUsuario(mail);
            Organizador organizador = null;
            if (usuario != null && UsuarioEsOrganizador(mail))
            {
                organizador = (Organizador)usuario;
                datos = organizador.MisDatos();
            }
            return datos;
        }

        // Agregar Evento a Organizador
        public bool AgregarEventoOrganizador(DateTime fechaEvento, string mailOrganizador)
        {
            // Agrega un Evento a la lista de Eventos de un Organizador y devuelve true, si el usuario es organizador y si el evento existe
            bool agregado = false;
            Evento evento = BuscarEvento(fechaEvento);
            Usuario usuario = BuscarUsuario(mailOrganizador);
            Organizador organizador = null;
            if (usuario != null && UsuarioEsOrganizador(mailOrganizador))
            {
                organizador = (Organizador)usuario;
            }
            if (evento != null && organizador != null)
            {
                agregado = organizador.AgregarEvento(evento);
            }
            return agregado;
        }

        // Listar Usuarios Todos
        public string ListarUsuariosTodos()
        {
            // Devuelve una lista de todos los usuario con sus datos y su rol
            string lista = "";
            foreach ( Usuario usuario in usuarios)
            {
                lista += "ROL: " + usuario.MiRol() + " " + usuario.ToString() + "\n";
            }
            return lista;
        }

        // Listar Organizadores
        public List<Organizador> ListarOrganizadores()
        {
            List<Organizador> lista = new List<Organizador>();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.MiRol() == "Organizador")
                {
                    Organizador organizador = (Organizador)usuario;
                    lista.Add(organizador);
                }
            }

            return lista;
        }

        // Listar Administradores
        public List<Usuario> ListarAdministradores()
        {
            List<Usuario> lista = new List<Usuario>();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.MiRol() == "Administrador")
                {
                    lista.Add(usuario);
                }
            }

            return lista;
        }



        // Buscar Evento
        public Evento BuscarEvento(DateTime fecha)
        {
            // Busca si un evento existe y lo devuelve, de lo contrario devuelve null
            Evento evento = null;
            int i = 0;
            while (i < eventos.Count && evento == null)
            {
                if (eventos[i].Fecha.Year == fecha.Year &&
                    eventos[i].Fecha.Month == fecha.Month &&
                    eventos[i].Fecha.Day == fecha.Day)
                {
                    evento = eventos[i];
                }
                i++;
            }
            return evento;
        }

        // Alta Evento Comun
        public bool AltaEventoComun(DateTime fecha, string turnoString, string descripcion, string nombreCliente, string nombreServicio, int cantPersonasServicio, int asistentes, string foto, int duracion)
        {
            bool alta = false;
            bool datosValidados = ValidarEventoComun(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto, duracion);
            Turno turno = BuscarTurno(turnoString);
            Servicio servicio = BuscarServicio(nombreServicio);
            Evento evento = BuscarEvento(fecha);
            int cantEventos = eventos.Count;
            if (evento == null && datosValidados && turno != 0)
            {
                eventos.Add(new EventoComun(fecha, turno, descripcion, nombreCliente, servicio, cantPersonasServicio, asistentes, foto, duracion));
            }
            if (cantEventos < eventos.Count)
            {
                alta = true;
            }
            return alta;
        }

        // Alta Evento Premium
        public bool AltaEventoPremium(DateTime fecha, string turnoString, string descripcion, string nombreCliente, string nombreServicio, int cantPersonasServicio, int asistentes, string foto)
        {
            bool alta = false;
            bool datosValidados = ValidarEventoPremium(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto);
            Turno turno = BuscarTurno(turnoString);
            Servicio servicio = BuscarServicio(nombreServicio);
            Evento evento = BuscarEvento(fecha);
            int cantEventos = eventos.Count;
            if (evento == null && datosValidados && turno != 0)
            {
                eventos.Add(new EventoPremium(fecha, turno, descripcion, nombreCliente, servicio, cantPersonasServicio, asistentes, foto));
            }
            if (cantEventos < eventos.Count)
            {
                alta = true;
            }
            return alta;
        }

        // Agregar Servicio a Evento
        public bool AgregarServicioEvento(string nombreServicio, int cantPersonas, DateTime fechaEvento)
        {
            bool agregado = false;
            Servicio servicio = BuscarServicio(nombreServicio);
            Evento evento = BuscarEvento(fechaEvento);
            if (servicio != null &&
                evento != null &&
                cantPersonas <= evento.Asistentes)
            {
                agregado = evento.AgregarServicioContratado(servicio, cantPersonas);
            }
            return agregado;
        }

        // Ver Porcentaje de Aumento para Eventos Premium
        public int VerPorcentajeDeAumento()
        {
            // Muestra el ese dato
            return EventoPremium.PorcentajeDeAumento;
        }

        // Cambiar Porcentaje de Aumento para Eventos Premium
        public bool CambiarPorcentajeDeAumento(int nuevoValor)
        {
            // Cambia ese dato
            return EventoPremium.CambiarPorcentajeDeAumento(nuevoValor);
        }

        // Ver Monto Fijo de Limpieza para Eventos Comunes
        public decimal VerMontoFijoLimpieza()
        {
            // Muestra ese dato
            return EventoComun.MontoFijoLimpieza;
        }

        // Cambiar Monto Fijo de Limpieza para Eventos Comunes
        public bool CambiarMontoFijoLimpieza(decimal nuevoValor)
        {
            // Cambia ese dato
            return EventoComun.CambiarMontoFijoLimpieza(nuevoValor);
        }

        // Listar Eventos de Organizador STRING
        public string ListarEventosOrganizador(string mail, string contrasenia)
        {
            // Lista todos los Eventos del Organizador si sus datos son correctos, si no es Organizador o si no existe muestra un aviso
            string lista = "";
            Usuario usuario = BuscarUsuario(mail);
            if (usuario == null || usuario.Contrasenia != contrasenia)
            {
                lista = "El usuario ingresado o la contraseña no son correctos";
            }
            else
            {
                lista = usuario.ListarEventos();
            }
            return lista;
        }

        // Listar Eventos de Organizador LISTA DE EVENTOS
        public List<Evento> ListarEventosOrganizador(string mail)
        {
            // Lista todos los Eventos del Organizador si sus datos son correctos, si no es Organizador o si no existe muestra un aviso
            List<Evento> lista = null;
            Usuario usuario = BuscarUsuario(mail);
            Organizador organizador = null;
            if (usuario != null && UsuarioEsOrganizador(mail))
            {
                organizador = (Organizador)usuario;
                lista = organizador.Eventos;
            }
            return lista;
        }

        // Mostrar datos de Evento
        public string MostrarDatosDeEvento(DateTime fecha)
        {
            // Muestra los datos de un Evenot, si es que existe
            string datos = "";
            Evento evento = BuscarEvento(fecha);
            if (evento != null)
            {
                datos += evento.ToString() + "\n" + evento.DatosDeMisServicios();
            }
            return datos;
        }

        // Mostrar servicios de Evento
        public List<ServicioContratado>ServiciosDeEvento(DateTime fecha)
        {
            // Muestra los datos de un Evenot, si es que existe
            List<ServicioContratado> servicios = new List<ServicioContratado>();

            Evento evento = BuscarEvento(fecha);
            if (evento != null)
            {
                servicios=evento.ServiciosContratados();
            }
            return servicios;
        }

        // Listar Eventos entre dos fechas ordenados por organizador(asc)/fecha(desc)
        public List<Evento> EventosEntre(DateTime fecha1, DateTime fecha2)
        {
            List<Evento> lista = new List<Evento>();
            if (fecha1 > fecha2) // hago que fecha1 siempre sea la menor
            {
                DateTime fechaAux = fecha1;
                fecha1 = fecha2;
                fecha2 = fechaAux;
            }

            usuarios.Sort(); // Ordeno por mail a los usuarios
            Organizador organizador = null;

            foreach (Usuario usuario in usuarios)
            {
                if (UsuarioEsOrganizador(usuario.Mail))
                {
                    organizador = (Organizador)usuario;
                    lista.AddRange(organizador.MisEventosEntreFechasOrdenados(fecha1, fecha2));
                }
            }

            return lista;
        }

        // Total generado por eventos entre dos fechas
        public decimal EventosEntreTotalGenerado(DateTime fecha1, DateTime fecha2)
        {
            decimal total = 0;
            if (fecha1 > fecha2) // hago que fecha1 siempre sea la menor
            {
                DateTime fechaAux = fecha1;
                fecha1 = fecha2;
                fecha2 = fechaAux;
            }
            List<Evento> eventosEntre = EventosEntre(fecha1, fecha2);
            foreach (Evento evento in eventosEntre)
            {
                total += evento.CostoCalculado;
            }
            return total;
        }

        // Listar eventos sin un servicio determinado
        public List<Evento> EventosSinServicio(Servicio servicio)
        {
            List<Evento> lista = new List<Evento>();
            foreach (Evento evento in eventos)
            {
                if (!evento.TengoEsteServicio(servicio))
                {
                    lista.Add(evento);
                }
            }
            return lista;
        }

        // Ver si evento tiene un servicio
        public bool EventoTieneServicio(DateTime fechaEvento, string servicioNombre)
        {
            bool tiene = false;
            Evento evento = BuscarEvento(fechaEvento);
            Servicio servicio = BuscarServicio(servicioNombre);
            if (evento != null && servicio != null)
            {
                if (evento.TengoEsteServicio(servicio))
                {
                    tiene = true;
                }
            }
            return tiene;
        }


        // Ver Organizador de Evento
        public Organizador VerOrgDeEvento(Evento evento)
        {
            // TODO: preguntar si esto está bien
            Organizador org = null;
            Organizador orgCasteado = null;
            int i = 0;
            while (i < usuarios.Count && org == null)
            {
                if (usuarios[i].MiRol() == "Organizador")
                {
                    orgCasteado = (Organizador)usuarios[i];
                    if (orgCasteado.Eventos.Contains(evento))
                    {
                        org = orgCasteado;
                    }
                }
                i++;
            }
            return org;
        }

        // Calcular total generado por Organizador
        public decimal TotalGeneradoPorOrganizador(string mail)
        {
            decimal total = 0;
            Usuario usuario = BuscarUsuario(mail);
            Organizador organizador = null;
            if (usuario != null && UsuarioEsOrganizador(mail))
            {
                organizador = (Organizador)usuario;
                total = organizador.TotalGeneradoPorMisEventos();
            }
            return total;
        }





        // Validar Mail
        public bool ValidarMail(string mail)
        {
            return Usuario.ValidarMail(mail);
        }

        // Validar Contraseña
        public bool ValidarContrasenia(string contrasenia)
        {
            return Usuario.ValidarContrasenia(contrasenia);
        }
        
        // Validar Nombre (min 3 letras)
        public bool ValidarNombre(string nombre)
        {
            return Usuario.ValidarNombre(nombre);
        }

        // Buscar turno
        public Turno BuscarTurno(string turnoString)
        {
            // Busca un Turno y si existe devuelve ese enum
            Turno turno = 0;
            string[] turnos = Enum.GetNames(typeof(Turno));
            if (turnos.Contains(turnoString))
            {
                turno = (Turno)Enum.Parse(typeof(Turno), turnoString);
            }
            return turno;
        }
        
        // Validar Evento Generico
        public bool ValidarEventoGenerico(DateTime fecha, string turnoString, string descripcion, string nombreCliente, string nombreServicio, int cantPersonasServicio, int asistentes, string foto)
        {
            // Hace una validación básica de los datos ingresados para los eventos
            bool validado = false;
            Servicio servicio = BuscarServicio(nombreServicio);
            if (fecha > DateTime.Now &&
                turnoString != "" &&
                descripcion != "" &&
                nombreCliente != "" && 
                servicio != null &&
                cantPersonasServicio > 0 &&
                asistentes > 0 &&
                cantPersonasServicio <= asistentes)
            {
                validado = true;
            } 
            return validado;
        }

        //Validar Evento Comun
        public bool ValidarEventoComun(DateTime fecha, string turnoString, string descripcion, string nombreCliente, string nombreServicio, int cantPersonasServicio, int asistentes, string foto, int duracion)
        {
            // Hace las validaciones específicas de los Eventos Comunes
            bool validado = false;
            if (ValidarEventoGenerico(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto) &&
                duracion > 0 &&
                duracion <= 4 &&
                asistentes <= 10 )
            {
                validado = true;
            }
            return validado;
        }

        // Validar Evento Premium
        public bool ValidarEventoPremium(DateTime fecha, string turnoString, string descripcion, string nombreCliente, string nombreServicio, int cantPersonasServicio, int asistentes, string foto)
        {
            // Hace la validación específica de los Eventos Premium
            bool validado = false;
            if (ValidarEventoGenerico(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto) &&
                asistentes <= 100)
            {
                validado = true;
            }
            return validado;
        }



    }
}
