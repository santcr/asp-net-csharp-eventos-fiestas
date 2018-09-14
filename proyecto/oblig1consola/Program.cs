using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oblig1clases;

namespace oblig1consola
{
    class Program
    {
        private static Empresa empresa = new Empresa();
        static void Main(string[] args)
        {
            int opcion = 0;
            while (opcion != 10)
            {
                MostrarOpciones();
                int.TryParse(Console.ReadLine(), out opcion);
                VerificarOpcion(opcion);
            }
            Console.ReadKey();
        }

        // Mostrar Opciones
        static void MostrarOpciones()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(" 1 - Registro de Administrador");
            Console.WriteLine(" 2 - Registro de Organizador");
            Console.WriteLine(" 3 - Registro de Evento");
            Console.WriteLine(" 4 - Agregar Servicios a Evento");
            Console.WriteLine(" 5 - Listar todos los Usuarios");
            Console.WriteLine(" 6 - Listar el catálogo de Servicios");
            Console.WriteLine(" 7 - Listar todos los Eventos de un Organizador");
            Console.WriteLine(" 8 - Cambiar Porcentaje de Aumento para Eventos Premium");
            Console.WriteLine(" 9 - Cambiar Monto Fijo de Limpieza para Eventos Comunes");
            Console.WriteLine(" 10 - Salir");
            Console.WriteLine("---------------------------------------------------------");
        }

        // Verificar Opcion
        static void VerificarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    AltaAdministrador();
                    break;
                case 2:
                    AltaOrganizador();
                    break;
                case 3:
                    AltaEvento();
                    break;
                case 4:
                    AgregarServiciosEvento();
                    break;
                case 5:
                    ListarUsuariosTodos();
                    break;
                case 6:
                    ListarServicios();
                    break;
                case 7:
                    EventosDeOrganizador();
                    break;
                case 8:
                    CambiarPorcentajeDeAumento();
                    break;
                case 9:
                    CambiarMontoFijoLimpieza();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Presione cualquier tecla para salir.");
                    break;

            }
        }

        // Alta Administrador
        static void AltaAdministrador()
        {

            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();

            if (!empresa.ValidarMail(mail))
            {
                Console.WriteLine("El mail ingresado no es válido");
            }
            else if (!empresa.ValidarContrasenia(contrasenia))
            {
                Console.WriteLine("La contraseña ingresada no es válida");
            }
            else if (empresa.BuscarUsuario(mail) != null)
            {
                Console.WriteLine("Ese mail ya está registrado");
            }
            else
            {
                if (empresa.AltaAdministrador(mail, contrasenia))
                {
                    Console.WriteLine("Administrador registrado exitosamente");
                }
                else
                {
                    Console.WriteLine("No se pudo registrar, intentelo nuevamente");
                }
            }
        }

        // Alta Organizador
        static void AltaOrganizador()
        {
            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su telefono");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su direccion");
            string direccion = Console.ReadLine();

            if (!empresa.ValidarMail(mail))
            {
                Console.WriteLine("El mail ingresado no es válido");
            }
            else if (!empresa.ValidarContrasenia(contrasenia))
            {
                Console.WriteLine("La contraseña ingresada no es válida");
            }
            else if (empresa.BuscarUsuario(mail) != null)
            {
                Console.WriteLine("Ese mail ya está registrado");
            }
            else if (!empresa.ValidarNombre(nombre))
            {
                Console.WriteLine("El nombre ingresado no es válido");
            }
            else
            {
                if (empresa.AltaOrganizador(mail, contrasenia, nombre, telefono, direccion))
                {
                    Console.WriteLine("Organizador registrado exitosamente");
                }
                else
                {
                    Console.WriteLine("No se pudo registrar, intentelo nuevamente");
                }
            }
        }

        // Alta Evento
        static void AltaEvento()
        {
            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();
            if (!empresa.ValidarMail(mail))
            {
                Console.WriteLine("El mail ingresado no es válido");
            }
            else if (!empresa.ValidarContrasenia(contrasenia))
            {
                Console.WriteLine("La contraseña ingresada no es válida");
            }
            else if (!empresa.UsuarioEsOrganizador(mail))
            {
                Console.WriteLine("---Ud no es un Organizador---");
            }
            else {
                Console.WriteLine("---Sus Datos---");
                Console.WriteLine(empresa.DatosDeOrganizador(mail));
                Console.WriteLine("---------------");
                Console.WriteLine("Ingrese fecha con el formato AAAA-MM-DD");
                DateTime fecha = DateTime.Now;
                string fechaString = Console.ReadLine();
                DateTime.TryParse(fechaString, out fecha);
                if (empresa.BuscarEvento(fecha) != null)
                {
                    Console.WriteLine("Ya existe un evento ese día");
                }
                else
                {
                    Console.WriteLine("Ingrese turno del evento");
                    string[] turnos = Enum.GetNames(typeof(Turno));
                    foreach (string tur in turnos)
                    {
                        Console.WriteLine(tur);
                    }
                    string turnoString = Console.ReadLine();
                    Console.WriteLine("Ingrese descripcion");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese nombre del cliente");
                    string nombreCliente = Console.ReadLine();
                    Console.WriteLine("Escriba el nombre de un servicio");
                    Console.WriteLine(empresa.ListarServicios());
                    string nombreServicio = Console.ReadLine();
                    Console.WriteLine("Ingrese cantidad de personas para ese servicio");
                    int cantPersonasServicio;
                    int.TryParse(Console.ReadLine(), out cantPersonasServicio);
                    Console.WriteLine("Ingrese cantidad de asistentes al evento");
                    int asistentes;
                    int.TryParse(Console.ReadLine(), out asistentes);
                    string foto = "";
                    Console.WriteLine("Tipo de evento 1-Comun 2-Premium");
                    string tipoEvento = Console.ReadLine();
                    if (tipoEvento == "1")
                    {
                        Console.WriteLine("Ingrese duración");
                        int duracion;
                        int.TryParse(Console.ReadLine(), out duracion);

                        if (empresa.AltaEventoComun(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto, duracion) &&
                            empresa.AgregarEventoOrganizador(fecha, mail))
                        {
                            Console.WriteLine("El evento se creó exitosamente");
                            Console.WriteLine(empresa.MostrarDatosDeEvento(fecha));
                        }
                        else
                        {
                            Console.WriteLine("El evento no pudo crearse, intente nuevamente");
                        }
                    }
                    else if (tipoEvento == "2")
                    {
                        if (empresa.AltaEventoPremium(fecha, turnoString, descripcion, nombreCliente, nombreServicio, cantPersonasServicio, asistentes, foto) &&
                            empresa.AgregarEventoOrganizador(fecha, mail))
                        {
                            Console.WriteLine("El evento se creó exitosamente");
                            Console.WriteLine(empresa.MostrarDatosDeEvento(fecha));
                        }
                        else
                        {
                            Console.WriteLine("El evento no pudo crearse, intente nuevamente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Algo salió mal");
                    }
                    


                }
            }
        }

        // Agregar Servicios a Evento
        static void AgregarServiciosEvento()
        {
            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();
            if (!empresa.ValidarMail(mail))
            {
                Console.WriteLine("El mail ingresado no es válido");
            }
            else if (!empresa.ValidarContrasenia(contrasenia))
            {
                Console.WriteLine("La contraseña ingresada no es válida");
            }
            else if (!empresa.UsuarioEsOrganizador(mail))
            {
                Console.WriteLine("---Ud no es un Organizador---");
            }
            else {
                Console.WriteLine("---Mis Datos---");
                Console.WriteLine(empresa.DatosDeOrganizador(mail));
                Console.WriteLine("---------------");
                Console.WriteLine(empresa.ListarEventosOrganizador(mail, contrasenia));
                Console.WriteLine("Ingrese fecha del evento con el formato AAAA-MM-DD");
                DateTime fecha = DateTime.Now;
                string fechaString = Console.ReadLine();
                DateTime.TryParse(fechaString, out fecha);
                if (empresa.BuscarEvento(fecha) == null)
                {
                    Console.WriteLine("No existe un evento ese día");
                }
                else
                {
                    string masServicios = "1";
                    while (masServicios == "1")
                    {
                        Console.WriteLine("Escriba el nombre de un servicio");
                        Console.WriteLine(empresa.ListarServicios());
                        string nombreServicio = Console.ReadLine();
                        Console.WriteLine("Ingrese cantidad de personas para ese servicio");
                        int cantPersonasServicio;
                        int.TryParse(Console.ReadLine(), out cantPersonasServicio);

                        if (empresa.AgregarServicioEvento(nombreServicio, cantPersonasServicio, fecha))
                        {
                            Console.WriteLine("El Servicio se agregó correctamente");
                        }
                        else
                        {
                            Console.WriteLine("El Servicio no pudo agregarse");
                        }
                        Console.WriteLine(empresa.MostrarDatosDeEvento(fecha));
                        Console.WriteLine("Desea agregar otro servicio? 1-Si 2-No");
                        masServicios = Console.ReadLine();
                    }
                }
            }
        }

        // Listar Usuarios
        static void ListarUsuariosTodos()
        {
            Console.WriteLine("---Todos los usuarios---");
            Console.WriteLine(empresa.ListarUsuariosTodos());
        }

        // Listar Servicios
        static void ListarServicios()
        {
            Console.WriteLine("---Todos los servicios---");
            Console.WriteLine(empresa.ListarServicios());
        }

        // Eventos de Organizador
        static void EventosDeOrganizador()
        {
            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();
            Console.WriteLine(empresa.ListarEventosOrganizador(mail, contrasenia));
        }

        // Cambiar Porcentaje de Aumento para Eventos Premium
        static void CambiarPorcentajeDeAumento()
        {
            Console.WriteLine("El Porcentaje de Aumento para Eventos Premium es " + empresa.VerPorcentajeDeAumento());
            Console.WriteLine("Desea cambiarlo? 1-Si 2-No");
            string siNo = Console.ReadLine();
            if (siNo == "1")
            {
                Console.WriteLine("Ingrese el nuevo valor de Porcentaje de Aumento para Eventos Premium");
                int nuevoValor;
                int.TryParse(Console.ReadLine(), out nuevoValor);
                if (nuevoValor > 0 &&
                    empresa.CambiarPorcentajeDeAumento(nuevoValor))
                {
                    Console.WriteLine("Valor cambiado correctamente");
                }
                else
                {
                    Console.WriteLine("El valor no pudo cambiarse");
                }
            }
        }

        // Cambiar Monto Fijo de Limpieza para Eventos Comunes
        static void CambiarMontoFijoLimpieza()
        {
            Console.WriteLine("El Monto Fijo de Limpieza para Eventos Comunes es " + empresa.VerMontoFijoLimpieza());
            Console.WriteLine("Desea cambiarlo? 1-Si 2-No");
            string siNo = Console.ReadLine();
            if (siNo == "1")
            {
                Console.WriteLine("Ingrese el nuevo valor de Monto Fijo de Limpieza para Eventos Comunes");
                int nuevoValor;
                int.TryParse(Console.ReadLine(), out nuevoValor);
                if (nuevoValor > 0 &&
                    empresa.CambiarMontoFijoLimpieza(nuevoValor))
                {
                    Console.WriteLine("Valor cambiado correctamente");
                }
                else
                {
                    Console.WriteLine("El valor no pudo cambiarse");
                }
            }
        }









    }
}
