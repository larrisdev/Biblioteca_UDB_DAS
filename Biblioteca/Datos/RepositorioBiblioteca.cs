using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Modelos;

namespace Biblioteca.Datos
{
    /// <summary>
    /// Repositorio central que mantiene listas y diccionarios de libros, usuarios y préstamos.
    /// Ofrece operaciones CRUD reutilizables y consultas para estadísticas.
    /// </summary>
    public class RepositorioBiblioteca
    {
        // Estructuras de datos: listas principales
        private readonly List<Libro> _libros;
        private readonly List<Usuario> _usuarios;
        private readonly List<Prestamo> _prestamos;

        // Diccionarios para acceso rápido por ID
        private readonly Dictionary<int, Libro> _librosPorId;
        private readonly Dictionary<int, Usuario> _usuariosPorId;
        private readonly Dictionary<int, Prestamo> _prestamosPorId;

        // Contador para generar IDs únicos (encapsulamiento)
        private int _siguienteIdLibros;
        private int _siguienteIdUsuarios;
        private int _siguienteIdPrestamos;

        public RepositorioBiblioteca()
        {
            _libros = new List<Libro>();
            _usuarios = new List<Usuario>();
            _prestamos = new List<Prestamo>();
            _librosPorId = new Dictionary<int, Libro>();
            _usuariosPorId = new Dictionary<int, Usuario>();
            _prestamosPorId = new Dictionary<int, Prestamo>();
            CargarDatosEjemplo();
        }

        private void CargarDatosEjemplo()
        {
            AgregarLibro(new Libro(0, "El Gran Gatsby", "F. Scott Fitzgerald", 1925));
            AgregarLibro(new Libro(0, "Matar a un Ruiseñor", "Harper Lee", 1960));
            AgregarLibro(new Libro(0, "1984", "George Orwell", 1949));
            AgregarLibro(new Libro(0, "Orgullo y Prejuicio", "Jane Austen", 1813));

            AgregarUsuario(new Usuario(0, "Juan Pérez", "juan.perez@email.com"));
            AgregarUsuario(new Usuario(0, "María Gómez", "maria.gomez@email.com"));
            AgregarUsuario(new Usuario(0, "Ana Torres", "ana.torres@email.com"));

            var u1 = ObtenerUsuarioPorId(1);
            var u2 = ObtenerUsuarioPorId(2);
            var l1 = ObtenerLibroPorId(1);
            var l2 = ObtenerLibroPorId(3);
            var l3 = ObtenerLibroPorId(4);
            if (u1 != null && u2 != null && l1 != null && l2 != null && l3 != null)
            {
                RegistrarPrestamo(u1.Id, l1.Id, new DateTime(2024, 4, 15), new DateTime(2024, 4, 22));
                RegistrarPrestamo(u1.Id, l2.Id, new DateTime(2024, 4, 17), new DateTime(2024, 4, 24));
                RegistrarPrestamo(u2.Id, l1.Id, new DateTime(2024, 3, 1), new DateTime(2024, 3, 8));
                RegistrarPrestamo(u2.Id, l3.Id, new DateTime(2024, 3, 10), new DateTime(2024, 3, 17));
            }
        }

        // ---------- Libros ----------
        public IReadOnlyList<Libro> ObtenerTodosLosLibros() => _libros.ToList();

        public Libro ObtenerLibroPorId(int id) =>
            _librosPorId.TryGetValue(id, out var libro) ? libro : null;

        public bool AgregarLibro(Libro libro)
        {
            if (libro == null) return false;
            libro.Id = ++_siguienteIdLibros;
            _libros.Add(libro);
            _librosPorId[libro.Id] = libro;
            return true;
        }

        public bool ActualizarLibro(Libro libro)
        {
            if (libro == null || !_librosPorId.ContainsKey(libro.Id)) return false;
            _librosPorId[libro.Id] = libro;
            var idx = _libros.FindIndex(l => l.Id == libro.Id);
            if (idx >= 0) _libros[idx] = libro;
            return true;
        }

        public bool EliminarLibro(int id)
        {
            if (!_librosPorId.TryGetValue(id, out var libro)) return false;
            if (TienePrestamosActivos(id)) return false;
            _libros.RemoveAll(l => l.Id == id);
            _librosPorId.Remove(id);
            return true;
        }

        public bool TienePrestamosActivos(int libroId) =>
            _prestamos.Any(p => p.LibroId == libroId && p.Estado == EstadoPrestamo.Prestado);

        // ---------- Usuarios ----------
        public IReadOnlyList<Usuario> ObtenerTodosLosUsuarios() => _usuarios.ToList();

        public Usuario ObtenerUsuarioPorId(int id) =>
            _usuariosPorId.TryGetValue(id, out var u) ? u : null;

        public bool AgregarUsuario(Usuario usuario)
        {
            if (usuario == null) return false;
            usuario.Id = ++_siguienteIdUsuarios;
            _usuarios.Add(usuario);
            _usuariosPorId[usuario.Id] = usuario;
            return true;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            if (usuario == null || !_usuariosPorId.ContainsKey(usuario.Id)) return false;
            _usuariosPorId[usuario.Id] = usuario;
            var idx = _usuarios.FindIndex(u => u.Id == usuario.Id);
            if (idx >= 0) _usuarios[idx] = usuario;
            return true;
        }

        public bool EliminarUsuario(int id)
        {
            if (!_usuariosPorId.TryGetValue(id, out _)) return false;
            if (_prestamos.Any(p => p.UsuarioId == id && p.Estado == EstadoPrestamo.Prestado)) return false;
            _usuarios.RemoveAll(u => u.Id == id);
            _usuariosPorId.Remove(id);
            return true;
        }

        // ---------- Préstamos ----------
        public IReadOnlyList<Prestamo> ObtenerTodosLosPrestamos() => _prestamos.ToList();

        public IReadOnlyList<Prestamo> ObtenerPrestamosPorUsuario(int usuarioId) =>
            _prestamos.Where(p => p.UsuarioId == usuarioId).OrderByDescending(p => p.FechaPrestamo).ToList();

        public Prestamo ObtenerPrestamoPorId(int id) =>
            _prestamosPorId.TryGetValue(id, out var p) ? p : null;

        public bool RegistrarPrestamo(int usuarioId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucionPrevista)
        {
            var libro = ObtenerLibroPorId(libroId);
            if (libro == null || !libro.Disponible) return false;
            if (ObtenerUsuarioPorId(usuarioId) == null) return false;
            if (fechaDevolucionPrevista < fechaPrestamo) return false;

            var prestamo = new Prestamo(0, usuarioId, libroId, fechaPrestamo, fechaDevolucionPrevista, null, EstadoPrestamo.Prestado);
            prestamo.Id = ++_siguienteIdPrestamos;
            _prestamos.Add(prestamo);
            _prestamosPorId[prestamo.Id] = prestamo;
            libro.Disponible = false;
            return true;
        }

        public bool RegistrarDevolucion(int prestamoId, DateTime? fechaDevolucionReal = null)
        {
            if (!_prestamosPorId.TryGetValue(prestamoId, out var prestamo) || prestamo.Estado == EstadoPrestamo.Devuelto)
                return false;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucionReal = fechaDevolucionReal ?? DateTime.Today;
            var libro = ObtenerLibroPorId(prestamo.LibroId);
            if (libro != null) libro.Disponible = true;
            return true;
        }

        public bool ActualizarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null || !_prestamosPorId.ContainsKey(prestamo.Id)) return false;
            _prestamosPorId[prestamo.Id] = prestamo;
            var idx = _prestamos.FindIndex(p => p.Id == prestamo.Id);
            if (idx >= 0) _prestamos[idx] = prestamo;
            return true;
        }

        public bool EliminarPrestamo(int id)
        {
            if (!_prestamosPorId.TryGetValue(id, out var prestamo)) return false;
            if (prestamo.Estado == EstadoPrestamo.Prestado)
            {
                var libro = ObtenerLibroPorId(prestamo.LibroId);
                if (libro != null) libro.Disponible = true;
            }
            _prestamos.RemoveAll(p => p.Id == id);
            _prestamosPorId.Remove(id);
            return true;
        }

        // ---------- Estadísticas (para gráficos) ----------
        /// <summary>
        /// Devuelve diccionario: título del libro -> cantidad de préstamos (todos los tiempos).
        /// Ordenado por cantidad descendente, top N.
        /// </summary>
        public Dictionary<string, int> LibrosMasPrestados(int top = 10)
        {
            var conteo = new Dictionary<int, int>();
            foreach (var p in _prestamos)
            {
                if (!conteo.ContainsKey(p.LibroId)) conteo[p.LibroId] = 0;
                conteo[p.LibroId]++;
            }
            var resultado = new Dictionary<string, int>();
            foreach (var kv in conteo.OrderByDescending(x => x.Value).Take(top))
            {
                var libro = ObtenerLibroPorId(kv.Key);
                resultado[libro?.Titulo ?? $"Libro #{kv.Key}"] = kv.Value;
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve diccionario: nombre usuario -> cantidad de préstamos (actividad).
        /// Ordenado por cantidad descendente, top N.
        /// </summary>
        public Dictionary<string, int> UsuariosMasActivos(int top = 10)
        {
            var conteo = new Dictionary<int, int>();
            foreach (var p in _prestamos)
            {
                if (!conteo.ContainsKey(p.UsuarioId)) conteo[p.UsuarioId] = 0;
                conteo[p.UsuarioId]++;
            }
            var resultado = new Dictionary<string, int>();
            foreach (var kv in conteo.OrderByDescending(x => x.Value).Take(top))
            {
                var usuario = ObtenerUsuarioPorId(kv.Key);
                resultado[usuario?.Nombre ?? $"Usuario #{kv.Key}"] = kv.Value;
            }
            return resultado;
        }

        /// <summary>
        /// Matriz: filas = meses (0-11), columnas = año índice; valor = cantidad de préstamos.
        /// Útil para estadísticas por período. Formato [mes, añoRelativo] -> cantidad.
        /// </summary>
        public int[,] ObtenerMatrizPrestamosPorMesYAnio(int aniosAtras = 2)
        {
            var anioMin = DateTime.Today.Year - aniosAtras;
            var anios = aniosAtras + 1;
            var matriz = new int[12, anios];
            foreach (var p in _prestamos)
            {
                if (p.FechaPrestamo.Year < anioMin) continue;
                var col = p.FechaPrestamo.Year - anioMin;
                if (col < 0 || col >= anios) continue;
                matriz[p.FechaPrestamo.Month - 1, col]++;
            }
            return matriz;
        }
    }
}
