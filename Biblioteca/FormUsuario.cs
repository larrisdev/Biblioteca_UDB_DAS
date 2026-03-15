using System;
using System.Windows.Forms;
using Biblioteca.Modelos;

namespace Biblioteca
{
    public partial class FormUsuario : Form
    {
        public Usuario Usuario { get; private set; }
        private readonly bool _esEdicion;

        public FormUsuario(Usuario usuarioExistente)
        {
            InitializeComponent();
            _esEdicion = usuarioExistente != null;
            if (_esEdicion)
            {
                Usuario = new Usuario(usuarioExistente.Id, usuarioExistente.Nombre, usuarioExistente.CorreoElectronico);
                txtNombre.Text = Usuario.Nombre;
                txtCorreo.Text = Usuario.CorreoElectronico;
            }
            else
            {
                Usuario = null;
            }
            Text = _esEdicion ? "Editar usuario" : "Añadir usuario";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text.Trim();
            var correo = txtCorreo.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) { MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(correo)) { MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (_esEdicion && Usuario != null)
            {
                Usuario.Nombre = nombre;
                Usuario.CorreoElectronico = correo;
            }
            else
                Usuario = new Usuario(0, nombre, correo);
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
