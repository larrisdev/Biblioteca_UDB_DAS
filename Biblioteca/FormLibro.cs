using System;
using System.Windows.Forms;
using Biblioteca.Modelos;

namespace Biblioteca
{
    public partial class FormLibro : Form
    {
        public Libro Libro { get; private set; }
        private readonly bool _esEdicion;

        public FormLibro(Libro libroExistente)
        {
            InitializeComponent();
            _esEdicion = libroExistente != null;
            if (_esEdicion)
            {
                Libro = new Libro(libroExistente.Id, libroExistente.Titulo, libroExistente.Autor, libroExistente.Anio, libroExistente.Disponible);
                txtTitulo.Text = Libro.Titulo;
                txtAutor.Text = Libro.Autor;
                numAnio.Value = Math.Max(1, Math.Min(Libro.Anio, 9999));
            }
            else
            {
                Libro = null;
                numAnio.Value = DateTime.Today.Year;
            }
            Text = _esEdicion ? "Editar libro" : "Añadir libro";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var titulo = txtTitulo.Text.Trim();
            var autor = txtAutor.Text.Trim();
            var anio = (int)numAnio.Value;
            if (string.IsNullOrEmpty(titulo)) { MessageBox.Show("El título es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(autor)) { MessageBox.Show("El autor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (_esEdicion && Libro != null)
            {
                Libro.Titulo = titulo;
                Libro.Autor = autor;
                Libro.Anio = anio;
            }
            else
                Libro = new Libro(0, titulo, autor, anio, true);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
