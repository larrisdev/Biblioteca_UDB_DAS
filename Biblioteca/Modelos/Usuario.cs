using System;

namespace Biblioteca.Modelos
{
    /// <summary>
    /// Representa un usuario de la biblioteca. Hereda de EntidadBase.
    /// </summary>
    public class Usuario : EntidadBase
    {
        private string _nombre;
        private string _correoElectronico;

        public Usuario() : base() { }

        public Usuario(int id, string nombre, string correoElectronico) : base(id)
        {
            _nombre = nombre ?? string.Empty;
            _correoElectronico = correoElectronico ?? string.Empty;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value ?? string.Empty;
        }

        public string CorreoElectronico
        {
            get => _correoElectronico;
            set => _correoElectronico = value ?? string.Empty;
        }

        public override string DescripcionParaLista => $"{Nombre} ({CorreoElectronico})";
    }
}
