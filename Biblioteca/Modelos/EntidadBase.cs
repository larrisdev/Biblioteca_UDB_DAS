using System;

namespace Biblioteca.Modelos
{
    /// <summary>
    /// Clase base abstracta que encapsula el identificador común de todas las entidades.
    /// Aplica herencia y encapsulamiento (Id protegido para asignación interna).
    /// </summary>
    public abstract class EntidadBase
    {
        private int _id;

        protected EntidadBase() { }

        protected EntidadBase(int id)
        {
            _id = id;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Descripción para mostrar en listas (polimorfismo).
        /// </summary>
        public virtual string DescripcionParaLista => $"ID: {Id}";
    }
}
