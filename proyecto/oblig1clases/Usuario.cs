using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig1clases
{
    public class Usuario: IComparable<Usuario>
    {
        private string mail;
        private string contrasenia;

        public string Mail
        {
            get { return mail; }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
        }

        // Constructor
        public Usuario(string mail, string contrasenia)
        {
            this.mail = mail;
            this.contrasenia = contrasenia;
        }

        // Mi Rol
        public virtual string MiRol()
        {
            return "Administrador";
        }

        // Listar Eventos
        public virtual string ListarEventos()
        {
            return "--Soy Administrador, no tengo eventos--";
        }

        // To String
        public override string ToString()
        {
            return "MAIL: " + mail + " CONTRASEÑA: " + contrasenia;
        }

        // Validar Mail
        public static bool ValidarMail(string mail)
        {
            // Devuelve true si el mail cumple con los requerimientos especificados
            bool validado = false;
            if (mail != "")
            {
                bool tieneArroba = mail.Contains("@");
                bool arrobaNoAlPrincipio = mail[0] != '@';
                bool arrobaNoAlFinal = mail[mail.Length - 1] != '@';
                bool tienePunto = mail.Contains(".");
                bool puntoDespuesDeArroba = mail.IndexOf('.') > mail.IndexOf('@');
                bool dosCharDespuesDePunto = (mail.IndexOf('.') <= mail.Length - 3);
                if (tieneArroba && arrobaNoAlPrincipio && arrobaNoAlFinal && tienePunto && puntoDespuesDeArroba && dosCharDespuesDePunto)
                {
                    validado = true;
                }
            }
            return validado;
        }

        // Validar Constraseña
        public static bool ValidarContrasenia(string contrasenia)
        {
            // Devuelve true si la contraseña cumple con los requerimientos especificados
            bool validado = false;
            if (contrasenia != "")
            {
                bool largo = contrasenia.Length >= 8;
                bool caracterEspecial = false;
                if (contrasenia.Contains("!") ||
                    contrasenia.Contains(".") ||
                    contrasenia.Contains(",") ||
                    contrasenia.Contains(";"))
                {
                    caracterEspecial = true;
                }
                bool mayuscula = false;
                if (contrasenia.ToLower() != contrasenia)
                {
                    mayuscula = true;
                }

                if (largo && caracterEspecial && mayuscula)
                {
                    validado = true;
                }
            }
            return validado;
        }

        // Validar Nombre
        public static bool ValidarNombre(string nombre)
        {
            // Devuelve true si el nombre cumple con los requerimientos especificados
            bool validado = false;
            if (nombre != "")
            {
                bool largo = nombre.Length >= 3;
                bool todasLetras = true;
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (!Char.IsLetter(nombre[i]))
                    {
                        todasLetras = false;
                        break;
                    }
                }
                if (largo && todasLetras)
                {
                    validado = true;
                }
            }
            return validado;
        }

        // Ordenar por mail
        public int CompareTo(Usuario other)
        {
            return this.mail.CompareTo(other.Mail);
        }



    }
}
