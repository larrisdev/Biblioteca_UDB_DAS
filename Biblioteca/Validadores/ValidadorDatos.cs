using System;
using System.Text.RegularExpressions;
using Biblioteca.Modelos;

namespace Biblioteca.Validadores
{
    /// <summary>
    /// Funciones reutilizables de validación para libros, usuarios y préstamos.
    /// </summary>
    public static class ValidadorDatos
    {
        private static readonly Regex RegexEmail = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool EsTextoNoVacio(string valor, int maxLongitud = 500)
        {
            if (string.IsNullOrWhiteSpace(valor)) return false;
            return valor.Trim().Length <= maxLongitud;
        }

        public static bool EsAnioValido(int anio)
        {
            return anio >= 1 && anio <= DateTime.Today.Year + 1;
        }

        public static (bool valido, string mensaje) ValidarLibro(Libro libro)
        {
            if (libro == null)
                return (false, "El libro no puede ser nulo.");
            if (!EsTextoNoVacio(libro.Titulo, 200))
                return (false, "El título es obligatorio y no puede superar 200 caracteres.");
            if (!EsTextoNoVacio(libro.Autor, 200))
                return (false, "El autor es obligatorio y no puede superar 200 caracteres.");
            if (!EsAnioValido(libro.Anio))
                return (false, $"El año debe estar entre 1 y {DateTime.Today.Year + 1}.");
            return (true, null);
        }

        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 320) return false;
            return RegexEmail.IsMatch(email.Trim());
        }

        public static (bool valido, string mensaje) ValidarUsuario(Usuario usuario, Func<string, bool> correoDuplicado = null)
        {
            if (usuario == null)
                return (false, "El usuario no puede ser nulo.");
            if (!EsTextoNoVacio(usuario.Nombre, 150))
                return (false, "El nombre es obligatorio y no puede superar 150 caracteres.");
            if (!EsEmailValido(usuario.CorreoElectronico))
                return (false, "El correo electrónico es obligatorio y debe tener formato válido.");
            if (correoDuplicado != null && correoDuplicado(usuario.CorreoElectronico.Trim()))
                return (false, "Ya existe un usuario con ese correo electrónico.");
            return (true, null);
        }

        public static (bool valido, string mensaje) ValidarPrestamo(DateTime fechaPrestamo, DateTime fechaDevolucionPrevista)
        {
            if (fechaPrestamo.Date > DateTime.Today)
                return (false, "La fecha de préstamo no puede ser futura.");
            if (fechaDevolucionPrevista < fechaPrestamo)
                return (false, "La fecha de devolución prevista debe ser posterior a la fecha de préstamo.");
            return (true, null);
        }
    }
}
