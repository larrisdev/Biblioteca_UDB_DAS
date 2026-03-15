using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.Datos;
using Biblioteca.Modelos;
using Biblioteca.Validadores;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        private readonly RepositorioBiblioteca _repositorio;

        public Form1()
        {
            InitializeComponent();
            _repositorio = new RepositorioBiblioteca();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarLibros();
            RefrescarUsuarios();
            RefrescarComboUsuarios();
            RefrescarPrestamos();
            ConfigurarGraficos();
            RefrescarGraficos();

            btnAnadirLibro.Click += BtnAnadirLibro_Click;
            btnEditarLibro.Click += BtnEditarLibro_Click;
            btnEliminarLibro.Click += BtnEliminarLibro_Click;
            btnAnadirUsuario.Click += BtnAnadirUsuario_Click;
            btnEditarUsuario.Click += BtnEditarUsuario_Click;
            btnEliminarUsuario.Click += BtnEliminarUsuario_Click;
            btnAnadirPrestamo.Click += BtnAnadirPrestamo_Click;
            btnEditarPrestamo.Click += BtnEditarPrestamo_Click;
            btnEliminarPrestamo.Click += BtnEliminarPrestamo_Click;
            btnDevolver.Click += BtnDevolver_Click;
            cmbUsuarioPrestamos.SelectedIndexChanged += CmbUsuarioPrestamos_SelectedIndexChanged;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabEstadisticas)
                RefrescarGraficos();
        }

        private void RefrescarLibros()
        {
            dgvLibros.Rows.Clear();
            dgvLibros.Columns.Clear();
            dgvLibros.Columns.Add("Id", "ID");
            dgvLibros.Columns.Add("Titulo", "Título");
            dgvLibros.Columns.Add("Autor", "Autor");
            dgvLibros.Columns.Add("Anio", "Año");
            dgvLibros.Columns.Add("Disponible", "Disponible");
            foreach (var l in _repositorio.ObtenerTodosLosLibros())
                dgvLibros.Rows.Add(l.Id, l.Titulo, l.Autor, l.Anio, l.Disponible ? "Sí" : "No");
        }

        private void RefrescarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add("Id", "ID");
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("Correo", "Correo electrónico");
            foreach (var u in _repositorio.ObtenerTodosLosUsuarios())
                dgvUsuarios.Rows.Add(u.Id, u.Nombre, u.CorreoElectronico);
        }

        private void RefrescarComboUsuarios()
        {
            var sel = cmbUsuarioPrestamos.SelectedValue as int?;
            cmbUsuarioPrestamos.Items.Clear();
            var usuarios = _repositorio.ObtenerTodosLosUsuarios();
            foreach (var u in usuarios)
                cmbUsuarioPrestamos.Items.Add(new ComboUsuarioItem { Id = u.Id, Nombre = u.Nombre });
            if (cmbUsuarioPrestamos.Items.Count > 0)
            {
                if (sel.HasValue && usuarios.Any(x => x.Id == sel.Value))
                    SeleccionarComboUsuario(sel.Value);
                else
                    cmbUsuarioPrestamos.SelectedIndex = 0;
            }
        }

        private void SeleccionarComboUsuario(int usuarioId)
        {
            for (int i = 0; i < cmbUsuarioPrestamos.Items.Count; i++)
            {
                if ((cmbUsuarioPrestamos.Items[i] as ComboUsuarioItem)?.Id == usuarioId)
                {
                    cmbUsuarioPrestamos.SelectedIndex = i;
                    return;
                }
            }
        }

        private void RefrescarPrestamos()
        {
            dgvPrestamos.Rows.Clear();
            dgvPrestamos.Columns.Clear();
            dgvPrestamos.Columns.Add("Id", "ID");
            dgvPrestamos.Columns.Add("Libro", "Libro");
            dgvPrestamos.Columns.Add("FechaPrestamo", "Fecha de préstamo");
            dgvPrestamos.Columns.Add("FechaDev", "Fecha de devolución");
            dgvPrestamos.Columns.Add("Estado", "Estado");

            var item = cmbUsuarioPrestamos.SelectedItem as ComboUsuarioItem;
            if (item == null) return;
            var prestamos = _repositorio.ObtenerPrestamosPorUsuario(item.Id);
            foreach (var p in prestamos)
            {
                var libro = _repositorio.ObtenerLibroPorId(p.LibroId);
                var libroTitulo = libro != null ? libro.Titulo : $"#{p.LibroId}";
                var estado = p.Estado == EstadoPrestamo.Prestado ? "Prestado" : "Devuelto";
                var fechaDev = p.FechaDevolucionReal?.ToString("yyyy-MM-dd") ?? p.FechaDevolucionPrevista.ToString("yyyy-MM-dd");
                dgvPrestamos.Rows.Add(p.Id, libroTitulo, p.FechaPrestamo.ToString("yyyy-MM-dd"), fechaDev, estado);
            }
        }

        private void CmbUsuarioPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarPrestamos();
        }

        private void BtnAnadirLibro_Click(object sender, EventArgs e)
        {
            using (var f = new FormLibro(null))
            {
                if (f.ShowDialog() != DialogResult.OK || f.Libro == null) return;
                var (valido, mensaje) = ValidadorDatos.ValidarLibro(f.Libro);
                if (!valido) { MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (_repositorio.AgregarLibro(f.Libro))
                {
                    RefrescarLibros();
                    RefrescarGraficos();
                    MessageBox.Show("Libro añadido correctamente.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditarLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un libro.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["Id"].Value);
            var libro = _repositorio.ObtenerLibroPorId(id);
            if (libro == null) return;
            using (var f = new FormLibro(libro))
            {
                if (f.ShowDialog() != DialogResult.OK || f.Libro == null) return;
                var (valido, mensaje) = ValidadorDatos.ValidarLibro(f.Libro);
                if (!valido) { MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (_repositorio.ActualizarLibro(f.Libro))
                {
                    RefrescarLibros();
                    RefrescarGraficos();
                    MessageBox.Show("Libro actualizado correctamente.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEliminarLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un libro.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("¿Eliminar este libro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (_repositorio.EliminarLibro(id))
            {
                RefrescarLibros();
                RefrescarGraficos();
                MessageBox.Show("Libro eliminado.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se puede eliminar: tiene préstamos activos o no existe.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool CorreoDuplicado(string correo, int? excluirUsuarioId)
        {
            var usuarios = _repositorio.ObtenerTodosLosUsuarios();
            return usuarios.Any(u => u.Id != excluirUsuarioId && string.Equals(u.CorreoElectronico.Trim(), correo.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private void BtnAnadirUsuario_Click(object sender, EventArgs e)
        {
            using (var f = new FormUsuario(null))
            {
                if (f.ShowDialog() != DialogResult.OK || f.Usuario == null) return;
                var (valido, mensaje) = ValidadorDatos.ValidarUsuario(f.Usuario, correo => CorreoDuplicado(correo, null));
                if (!valido) { MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (_repositorio.AgregarUsuario(f.Usuario))
                {
                    RefrescarUsuarios();
                    RefrescarComboUsuarios();
                    RefrescarGraficos();
                    MessageBox.Show("Usuario añadido correctamente.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un usuario.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
            var usuario = _repositorio.ObtenerUsuarioPorId(id);
            if (usuario == null) return;
            using (var f = new FormUsuario(usuario))
            {
                if (f.ShowDialog() != DialogResult.OK || f.Usuario == null) return;
                var (valido, mensaje) = ValidadorDatos.ValidarUsuario(f.Usuario, correo => CorreoDuplicado(correo, usuario.Id));
                if (!valido) { MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (_repositorio.ActualizarUsuario(f.Usuario))
                {
                    RefrescarUsuarios();
                    RefrescarComboUsuarios();
                    RefrescarPrestamos();
                    RefrescarGraficos();
                    MessageBox.Show("Usuario actualizado correctamente.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un usuario.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("¿Eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (_repositorio.EliminarUsuario(id))
            {
                RefrescarUsuarios();
                RefrescarComboUsuarios();
                RefrescarPrestamos();
                RefrescarGraficos();
                MessageBox.Show("Usuario eliminado.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se puede eliminar: tiene préstamos activos o no existe.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnAnadirPrestamo_Click(object sender, EventArgs e)
        {
            var item = cmbUsuarioPrestamos.SelectedItem as ComboUsuarioItem;
            if (item == null) { MessageBox.Show("Seleccione un usuario.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            using (var f = new FormPrestamo(_repositorio, item.Id, null))
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                RefrescarLibros();
                RefrescarPrestamos();
                RefrescarGraficos();
                MessageBox.Show("Préstamo registrado.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditarPrestamo_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un préstamo.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["Id"].Value);
            var prestamo = _repositorio.ObtenerPrestamoPorId(id);
            if (prestamo == null) return;
            var item = cmbUsuarioPrestamos.SelectedItem as ComboUsuarioItem;
            var usuarioId = item?.Id ?? prestamo.UsuarioId;
            using (var f = new FormPrestamo(_repositorio, usuarioId, prestamo))
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                RefrescarLibros();
                RefrescarPrestamos();
                RefrescarGraficos();
                MessageBox.Show("Préstamo actualizado.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminarPrestamo_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un préstamo.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("¿Eliminar este préstamo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (_repositorio.EliminarPrestamo(id))
            {
                RefrescarLibros();
                RefrescarPrestamos();
                RefrescarGraficos();
                MessageBox.Show("Préstamo eliminado.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0) { MessageBox.Show("Seleccione un préstamo.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["Id"].Value);
            var estado = dgvPrestamos.SelectedRows[0].Cells["Estado"].Value?.ToString();
            if (estado == "Devuelto") { MessageBox.Show("Este préstamo ya está devuelto.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (_repositorio.RegistrarDevolucion(id))
            {
                RefrescarLibros();
                RefrescarPrestamos();
                RefrescarGraficos();
                MessageBox.Show("Devolución registrada.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigurarGraficos()
        {
            ConfigurarChartBarras(chartLibrosPrestados, "Libros más prestados");
            ConfigurarChartBarras(chartUsuariosActivos, "Usuarios más activos");
        }

        private void ConfigurarChartBarras(System.Windows.Forms.DataVisualization.Charting.Chart chart, string titulo)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add("Area1");
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Datos");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series.Color = Color.FromArgb(46, 125, 50);
            chart.Series.Add(series);
            chart.Titles.Add(titulo);
            chart.Titles[0].Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void RefrescarGraficos()
        {
            var libros = _repositorio.LibrosMasPrestados(8);
            chartLibrosPrestados.Series["Datos"].Points.Clear();
            foreach (var kv in libros)
                chartLibrosPrestados.Series["Datos"].Points.AddXY(kv.Key, kv.Value);
            chartLibrosPrestados.ChartAreas[0].RecalculateAxesScale();

            var usuarios = _repositorio.UsuariosMasActivos(8);
            chartUsuariosActivos.Series["Datos"].Points.Clear();
            foreach (var kv in usuarios)
                chartUsuariosActivos.Series["Datos"].Points.AddXY(kv.Key, kv.Value);
            chartUsuariosActivos.ChartAreas[0].RecalculateAxesScale();
        }

        private sealed class ComboUsuarioItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString() => Nombre ?? "";
        }

        private void lblEstLibros_Click(object sender, EventArgs e)
        {

        }

        private void lblEstUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuarioPrestamos_Click(object sender, EventArgs e)
        {

        }
    }
}
