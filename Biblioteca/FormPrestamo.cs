using System;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.Datos;
using Biblioteca.Modelos;
using Biblioteca.Validadores;

namespace Biblioteca
{
    public partial class FormPrestamo : Form
    {
        private readonly RepositorioBiblioteca _repo;
        private readonly int _usuarioId;
        private readonly Prestamo _prestamoExistente;

        public FormPrestamo(RepositorioBiblioteca repo, int usuarioId, Prestamo prestamoExistente)
        {
            InitializeComponent();
            _repo = repo;
            _usuarioId = usuarioId;
            _prestamoExistente = prestamoExistente;

            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;

            var usuarios = _repo.ObtenerTodosLosUsuarios();
            foreach (var u in usuarios)
                cmbUsuario.Items.Add(new ItemCombo { Id = u.Id, Texto = u.Nombre });
            var selU = usuarios.FirstOrDefault(x => x.Id == usuarioId);
            if (selU != null)
            {
                for (int i = 0; i < cmbUsuario.Items.Count; i++)
                {
                    if ((cmbUsuario.Items[i] as ItemCombo)?.Id == usuarioId)
                    {
                        cmbUsuario.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (cmbUsuario.Items.Count > 0)
                cmbUsuario.SelectedIndex = 0;

            RefrescarLibrosDisponibles();

            if (_prestamoExistente != null)
            {
                dtpPrestamo.Value = _prestamoExistente.FechaPrestamo;
                dtpDevolucion.Value = _prestamoExistente.FechaDevolucionPrevista;
                SeleccionarLibro(_prestamoExistente.LibroId);
                Text = "Editar préstamo";
            }
            else
            {
                dtpPrestamo.Value = DateTime.Today;
                dtpDevolucion.Value = DateTime.Today.AddDays(7);
                Text = "Nuevo préstamo";
            }
        }

        private void RefrescarLibrosDisponibles()
        {
            cmbLibro.Items.Clear();
            var libros = _repo.ObtenerTodosLosLibros().Where(l => l.Disponible || (_prestamoExistente != null && l.Id == _prestamoExistente.LibroId)).ToList();
            foreach (var l in libros)
                cmbLibro.Items.Add(new ItemCombo { Id = l.Id, Texto = $"{l.Titulo} - {l.Autor}" });
            if (cmbLibro.Items.Count > 0 && cmbLibro.SelectedIndex < 0)
                cmbLibro.SelectedIndex = 0;
        }

        private void SeleccionarLibro(int libroId)
        {
            for (int i = 0; i < cmbLibro.Items.Count; i++)
            {
                if ((cmbLibro.Items[i] as ItemCombo)?.Id == libroId)
                {
                    cmbLibro.SelectedIndex = i;
                    return;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var itemUsuario = cmbUsuario.SelectedItem as ItemCombo;
            var itemLibro = cmbLibro.SelectedItem as ItemCombo;
            if (itemUsuario == null) { MessageBox.Show("Seleccione un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (itemLibro == null) { MessageBox.Show("Seleccione un libro disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var fechaPrestamo = dtpPrestamo.Value.Date;
            var fechaDev = dtpDevolucion.Value.Date;
            var (valido, mensaje) = ValidadorDatos.ValidarPrestamo(fechaPrestamo, fechaDev);
            if (!valido) { MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (_prestamoExistente != null)
            {
                _prestamoExistente.UsuarioId = itemUsuario.Id;
                _prestamoExistente.LibroId = itemLibro.Id;
                _prestamoExistente.FechaPrestamo = fechaPrestamo;
                _prestamoExistente.FechaDevolucionPrevista = fechaDev;
                if (_prestamoExistente.Estado == EstadoPrestamo.Prestado)
                {
                    var libroAntiguo = _repo.ObtenerLibroPorId(_prestamoExistente.LibroId);
                    if (libroAntiguo != null && libroAntiguo.Id != itemLibro.Id)
                        libroAntiguo.Disponible = true;
                    var libroNuevo = _repo.ObtenerLibroPorId(itemLibro.Id);
                    if (libroNuevo != null)
                        libroNuevo.Disponible = false;
                }
                _repo.ActualizarPrestamo(_prestamoExistente);
            }
            else
            {
                if (!_repo.RegistrarPrestamo(itemUsuario.Id, itemLibro.Id, fechaPrestamo, fechaDev))
                {
                    MessageBox.Show("No se pudo registrar el préstamo. Compruebe que el libro esté disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class ItemCombo
        {
            public int Id { get; set; }
            public string Texto { get; set; }
            public override string ToString() => Texto ?? "";
        }
    }
}
