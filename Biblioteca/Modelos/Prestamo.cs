using System;

namespace Biblioteca.Modelos
{
    /// <summary>
    /// Representa un préstamo de un libro a un usuario. Hereda de EntidadBase.
    /// </summary>
    public class Prestamo : EntidadBase
    {
        private int _usuarioId;
        private int _libroId;
        private DateTime _fechaPrestamo;
        private DateTime _fechaDevolucionPrevista;
        private DateTime? _fechaDevolucionReal;
        private EstadoPrestamo _estado;

        public Prestamo() : base()
        {
            _fechaPrestamo = DateTime.Today;
            _fechaDevolucionPrevista = DateTime.Today.AddDays(7);
            _estado = EstadoPrestamo.Prestado;
        }

        public Prestamo(int id, int usuarioId, int libroId, DateTime fechaPrestamo,
            DateTime fechaDevolucionPrevista, DateTime? fechaDevolucionReal, EstadoPrestamo estado) : base(id)
        {
            _usuarioId = usuarioId;
            _libroId = libroId;
            _fechaPrestamo = fechaPrestamo;
            _fechaDevolucionPrevista = fechaDevolucionPrevista;
            _fechaDevolucionReal = fechaDevolucionReal;
            _estado = estado;
        }

        public int UsuarioId
        {
            get => _usuarioId;
            set => _usuarioId = value;
        }

        public int LibroId
        {
            get => _libroId;
            set => _libroId = value;
        }

        public DateTime FechaPrestamo
        {
            get => _fechaPrestamo;
            set => _fechaPrestamo = value;
        }

        public DateTime FechaDevolucionPrevista
        {
            get => _fechaDevolucionPrevista;
            set => _fechaDevolucionPrevista = value;
        }

        public DateTime? FechaDevolucionReal
        {
            get => _fechaDevolucionReal;
            set => _fechaDevolucionReal = value;
        }

        public EstadoPrestamo Estado
        {
            get => _estado;
            set => _estado = value;
        }

        public override string DescripcionParaLista =>
            $"Préstamo #{Id} - Libro:{LibroId} Usuario:{UsuarioId} - {Estado}";
    }
}
