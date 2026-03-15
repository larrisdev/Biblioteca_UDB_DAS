namespace Biblioteca
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLibros = new System.Windows.Forms.TabPage();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.panelLibrosBtns = new System.Windows.Forms.Panel();
            this.btnAnadirLibro = new System.Windows.Forms.Button();
            this.btnEditarLibro = new System.Windows.Forms.Button();
            this.btnEliminarLibro = new System.Windows.Forms.Button();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panelUsuariosBtns = new System.Windows.Forms.Panel();
            this.btnAnadirUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.tabPrestamos = new System.Windows.Forms.TabPage();
            this.cmbUsuarioPrestamos = new System.Windows.Forms.ComboBox();
            this.lblUsuarioPrestamos = new System.Windows.Forms.Label();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.panelPrestamosBtns = new System.Windows.Forms.Panel();
            this.btnAnadirPrestamo = new System.Windows.Forms.Button();
            this.btnEditarPrestamo = new System.Windows.Forms.Button();
            this.btnEliminarPrestamo = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.tabEstadisticas = new System.Windows.Forms.TabPage();
            this.lblEstLibros = new System.Windows.Forms.Label();
            this.chartLibrosPrestados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblEstUsuarios = new System.Windows.Forms.Label();
            this.chartUsuariosActivos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tabLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.panelLibrosBtns.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelUsuariosBtns.SuspendLayout();
            this.tabPrestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.panelPrestamosBtns.SuspendLayout();
            this.tabEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLibrosPrestados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosActivos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(385, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "BIBLIOTECA UNIVERSITARIA PARA TODOS";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(14, 38);
            this.lblSubtitulo.MaximumSize = new System.Drawing.Size(750, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(413, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Bienvenido a la gestión de biblioteca, Bibloteca de la Universitaria para todos.";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLibros);
            this.tabControl.Controls.Add(this.tabUsuarios);
            this.tabControl.Controls.Add(this.tabPrestamos);
            this.tabControl.Controls.Add(this.tabEstadisticas);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl.Location = new System.Drawing.Point(12, 75);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 420);
            this.tabControl.TabIndex = 2;
            // 
            // tabLibros
            // 
            this.tabLibros.Controls.Add(this.dgvLibros);
            this.tabLibros.Controls.Add(this.panelLibrosBtns);
            this.tabLibros.Location = new System.Drawing.Point(4, 24);
            this.tabLibros.Name = "tabLibros";
            this.tabLibros.Padding = new System.Windows.Forms.Padding(3);
            this.tabLibros.Size = new System.Drawing.Size(852, 392);
            this.tabLibros.TabIndex = 0;
            this.tabLibros.Text = "Administrar Libros";
            this.tabLibros.UseVisualStyleBackColor = true;
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToDeleteRows = false;
            this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Location = new System.Drawing.Point(6, 27);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibros.Size = new System.Drawing.Size(840, 300);
            this.dgvLibros.TabIndex = 0;
            // 
            // panelLibrosBtns
            // 
            this.panelLibrosBtns.Controls.Add(this.btnAnadirLibro);
            this.panelLibrosBtns.Controls.Add(this.btnEditarLibro);
            this.panelLibrosBtns.Controls.Add(this.btnEliminarLibro);
            this.panelLibrosBtns.Location = new System.Drawing.Point(228, 333);
            this.panelLibrosBtns.Name = "panelLibrosBtns";
            this.panelLibrosBtns.Size = new System.Drawing.Size(400, 35);
            this.panelLibrosBtns.TabIndex = 1;
            // 
            // btnAnadirLibro
            // 
            this.btnAnadirLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAnadirLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirLibro.ForeColor = System.Drawing.Color.White;
            this.btnAnadirLibro.Location = new System.Drawing.Point(0, 0);
            this.btnAnadirLibro.Name = "btnAnadirLibro";
            this.btnAnadirLibro.Size = new System.Drawing.Size(100, 30);
            this.btnAnadirLibro.TabIndex = 0;
            this.btnAnadirLibro.Text = "+ Añadir";
            this.btnAnadirLibro.UseVisualStyleBackColor = false;
            // 
            // btnEditarLibro
            // 
            this.btnEditarLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEditarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarLibro.ForeColor = System.Drawing.Color.White;
            this.btnEditarLibro.Location = new System.Drawing.Point(120, 0);
            this.btnEditarLibro.Name = "btnEditarLibro";
            this.btnEditarLibro.Size = new System.Drawing.Size(100, 30);
            this.btnEditarLibro.TabIndex = 1;
            this.btnEditarLibro.Text = "Editar";
            this.btnEditarLibro.UseVisualStyleBackColor = false;
            // 
            // btnEliminarLibro
            // 
            this.btnEliminarLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEliminarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarLibro.ForeColor = System.Drawing.Color.White;
            this.btnEliminarLibro.Location = new System.Drawing.Point(242, 0);
            this.btnEliminarLibro.Name = "btnEliminarLibro";
            this.btnEliminarLibro.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarLibro.TabIndex = 2;
            this.btnEliminarLibro.Text = "Eliminar";
            this.btnEliminarLibro.UseVisualStyleBackColor = false;
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Controls.Add(this.panelUsuariosBtns);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 24);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(852, 392);
            this.tabUsuarios.TabIndex = 1;
            this.tabUsuarios.Text = "Administrar Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 6);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(840, 300);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // panelUsuariosBtns
            // 
            this.panelUsuariosBtns.Controls.Add(this.btnAnadirUsuario);
            this.panelUsuariosBtns.Controls.Add(this.btnEditarUsuario);
            this.panelUsuariosBtns.Controls.Add(this.btnEliminarUsuario);
            this.panelUsuariosBtns.Location = new System.Drawing.Point(246, 329);
            this.panelUsuariosBtns.Name = "panelUsuariosBtns";
            this.panelUsuariosBtns.Size = new System.Drawing.Size(400, 35);
            this.panelUsuariosBtns.TabIndex = 1;
            // 
            // btnAnadirUsuario
            // 
            this.btnAnadirUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAnadirUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAnadirUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnAnadirUsuario.Name = "btnAnadirUsuario";
            this.btnAnadirUsuario.Size = new System.Drawing.Size(100, 30);
            this.btnAnadirUsuario.TabIndex = 0;
            this.btnAnadirUsuario.Text = "+ Añadir";
            this.btnAnadirUsuario.UseVisualStyleBackColor = false;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEditarUsuario.Location = new System.Drawing.Point(110, 0);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(100, 30);
            this.btnEditarUsuario.TabIndex = 1;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(220, 0);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarUsuario.TabIndex = 2;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            // 
            // tabPrestamos
            // 
            this.tabPrestamos.Controls.Add(this.cmbUsuarioPrestamos);
            this.tabPrestamos.Controls.Add(this.lblUsuarioPrestamos);
            this.tabPrestamos.Controls.Add(this.dgvPrestamos);
            this.tabPrestamos.Controls.Add(this.panelPrestamosBtns);
            this.tabPrestamos.Location = new System.Drawing.Point(4, 24);
            this.tabPrestamos.Name = "tabPrestamos";
            this.tabPrestamos.Size = new System.Drawing.Size(852, 392);
            this.tabPrestamos.TabIndex = 2;
            this.tabPrestamos.Text = "Gestionar Préstamos";
            this.tabPrestamos.UseVisualStyleBackColor = true;
            // 
            // cmbUsuarioPrestamos
            // 
            this.cmbUsuarioPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarioPrestamos.FormattingEnabled = true;
            this.cmbUsuarioPrestamos.Location = new System.Drawing.Point(315, 8);
            this.cmbUsuarioPrestamos.Name = "cmbUsuarioPrestamos";
            this.cmbUsuarioPrestamos.Size = new System.Drawing.Size(397, 23);
            this.cmbUsuarioPrestamos.TabIndex = 0;
            // 
            // lblUsuarioPrestamos
            // 
            this.lblUsuarioPrestamos.AutoSize = true;
            this.lblUsuarioPrestamos.Location = new System.Drawing.Point(201, 11);
            this.lblUsuarioPrestamos.Name = "lblUsuarioPrestamos";
            this.lblUsuarioPrestamos.Size = new System.Drawing.Size(85, 15);
            this.lblUsuarioPrestamos.TabIndex = 1;
            this.lblUsuarioPrestamos.Text = "Nuevo Usuario";
            this.lblUsuarioPrestamos.Click += new System.EventHandler(this.lblUsuarioPrestamos_Click);
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(6, 40);
            this.dgvPrestamos.MultiSelect = false;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.Size = new System.Drawing.Size(840, 260);
            this.dgvPrestamos.TabIndex = 2;
            // 
            // panelPrestamosBtns
            // 
            this.panelPrestamosBtns.Controls.Add(this.btnAnadirPrestamo);
            this.panelPrestamosBtns.Controls.Add(this.btnEditarPrestamo);
            this.panelPrestamosBtns.Controls.Add(this.btnEliminarPrestamo);
            this.panelPrestamosBtns.Controls.Add(this.btnDevolver);
            this.panelPrestamosBtns.Location = new System.Drawing.Point(167, 339);
            this.panelPrestamosBtns.Name = "panelPrestamosBtns";
            this.panelPrestamosBtns.Size = new System.Drawing.Size(500, 35);
            this.panelPrestamosBtns.TabIndex = 3;
            // 
            // btnAnadirPrestamo
            // 
            this.btnAnadirPrestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAnadirPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirPrestamo.ForeColor = System.Drawing.Color.White;
            this.btnAnadirPrestamo.Location = new System.Drawing.Point(0, 0);
            this.btnAnadirPrestamo.Name = "btnAnadirPrestamo";
            this.btnAnadirPrestamo.Size = new System.Drawing.Size(100, 30);
            this.btnAnadirPrestamo.TabIndex = 0;
            this.btnAnadirPrestamo.Text = "+ Añadir";
            this.btnAnadirPrestamo.UseVisualStyleBackColor = false;
            // 
            // btnEditarPrestamo
            // 
            this.btnEditarPrestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEditarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarPrestamo.ForeColor = System.Drawing.Color.White;
            this.btnEditarPrestamo.Location = new System.Drawing.Point(114, 2);
            this.btnEditarPrestamo.Name = "btnEditarPrestamo";
            this.btnEditarPrestamo.Size = new System.Drawing.Size(100, 30);
            this.btnEditarPrestamo.TabIndex = 1;
            this.btnEditarPrestamo.Text = "Editar";
            this.btnEditarPrestamo.UseVisualStyleBackColor = false;
            // 
            // btnEliminarPrestamo
            // 
            this.btnEliminarPrestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEliminarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPrestamo.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPrestamo.Location = new System.Drawing.Point(237, 0);
            this.btnEliminarPrestamo.Name = "btnEliminarPrestamo";
            this.btnEliminarPrestamo.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarPrestamo.TabIndex = 2;
            this.btnEliminarPrestamo.Text = "Eliminar";
            this.btnEliminarPrestamo.UseVisualStyleBackColor = false;
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.ForeColor = System.Drawing.Color.White;
            this.btnDevolver.Location = new System.Drawing.Point(361, 0);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(100, 30);
            this.btnDevolver.TabIndex = 3;
            this.btnDevolver.Text = "Registrar devolución";
            this.btnDevolver.UseVisualStyleBackColor = false;
            // 
            // tabEstadisticas
            // 
            this.tabEstadisticas.Controls.Add(this.lblEstLibros);
            this.tabEstadisticas.Controls.Add(this.chartLibrosPrestados);
            this.tabEstadisticas.Controls.Add(this.lblEstUsuarios);
            this.tabEstadisticas.Controls.Add(this.chartUsuariosActivos);
            this.tabEstadisticas.Location = new System.Drawing.Point(4, 24);
            this.tabEstadisticas.Name = "tabEstadisticas";
            this.tabEstadisticas.Size = new System.Drawing.Size(852, 392);
            this.tabEstadisticas.TabIndex = 3;
            this.tabEstadisticas.Text = "Estadísticas";
            this.tabEstadisticas.UseVisualStyleBackColor = true;
            // 
            // lblEstLibros
            // 
            this.lblEstLibros.AutoSize = true;
            this.lblEstLibros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstLibros.Location = new System.Drawing.Point(75, 8);
            this.lblEstLibros.Name = "lblEstLibros";
            this.lblEstLibros.Size = new System.Drawing.Size(139, 17);
            this.lblEstLibros.TabIndex = 2;
            this.lblEstLibros.Text = "Libros más prestados";
            this.lblEstLibros.Click += new System.EventHandler(this.lblEstLibros_Click);
            // 
            // chartLibrosPrestados
            // 
            this.chartLibrosPrestados.Location = new System.Drawing.Point(6, 28);
            this.chartLibrosPrestados.Name = "chartLibrosPrestados";
            this.chartLibrosPrestados.Size = new System.Drawing.Size(385, 360);
            this.chartLibrosPrestados.TabIndex = 0;
            // 
            // lblEstUsuarios
            // 
            this.lblEstUsuarios.AutoSize = true;
            this.lblEstUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstUsuarios.Location = new System.Drawing.Point(563, 8);
            this.lblEstUsuarios.Name = "lblEstUsuarios";
            this.lblEstUsuarios.Size = new System.Drawing.Size(137, 17);
            this.lblEstUsuarios.TabIndex = 3;
            this.lblEstUsuarios.Text = "Usuarios más activos";
            this.lblEstUsuarios.Click += new System.EventHandler(this.lblEstUsuarios_Click);
            // 
            // chartUsuariosActivos
            // 
            this.chartUsuariosActivos.Location = new System.Drawing.Point(410, 28);
            this.chartUsuariosActivos.Name = "chartUsuariosActivos";
            this.chartUsuariosActivos.Size = new System.Drawing.Size(414, 360);
            this.chartUsuariosActivos.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Biblioteca";
            this.tabControl.ResumeLayout(false);
            this.tabLibros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.panelLibrosBtns.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelUsuariosBtns.ResumeLayout(false);
            this.tabPrestamos.ResumeLayout(false);
            this.tabPrestamos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.panelPrestamosBtns.ResumeLayout(false);
            this.tabEstadisticas.ResumeLayout(false);
            this.tabEstadisticas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLibrosPrestados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLibros;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Panel panelLibrosBtns;
        private System.Windows.Forms.Button btnAnadirLibro;
        private System.Windows.Forms.Button btnEditarLibro;
        private System.Windows.Forms.Button btnEliminarLibro;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel panelUsuariosBtns;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.TabPage tabPrestamos;
        private System.Windows.Forms.ComboBox cmbUsuarioPrestamos;
        private System.Windows.Forms.Label lblUsuarioPrestamos;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Panel panelPrestamosBtns;
        private System.Windows.Forms.Button btnAnadirPrestamo;
        private System.Windows.Forms.Button btnEditarPrestamo;
        private System.Windows.Forms.Button btnEliminarPrestamo;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.TabPage tabEstadisticas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLibrosPrestados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosActivos;
        private System.Windows.Forms.Label lblEstLibros;
        private System.Windows.Forms.Label lblEstUsuarios;
        private System.Windows.Forms.Button btnAnadirUsuario;
    }
}
