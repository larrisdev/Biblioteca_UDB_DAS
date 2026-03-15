using System;

namespace Biblioteca.Modelos
{
    /// <summary>
    /// Representa un libro en la biblioteca. Hereda de EntidadBase.
    /// </summary>
    public class Libro : EntidadBase
    {
        private string _titulo;
        private string _autor;
        private int _anio;
        private bool _disponible;

        public Libro() : base() { _disponible = true; }

        public Libro(int id, string titulo, string autor, int anio, bool disponible = true) : base(id)
        {
            _titulo = titulo ?? string.Empty;
            _autor = autor ?? string.Empty;
            _anio = anio;
            _disponible = disponible;
        }

        public string Titulo
        {
            get => _titulo;
            set => _titulo = value ?? string.Empty;
        }

        public string Autor
        {
            get => _autor;
            set => _autor = value ?? string.Empty;
        }

        public int Anio
        {
            get => _anio;
            set => _anio = value;
        }

        public bool Disponible
        {
            get => _disponible;
            set => _disponible = value;
        }

        public override string DescripcionParaLista => $"{Titulo} - {Autor} ({Anio})";
    }
}
