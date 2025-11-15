namespace Sistema_de_Boletos_Aéreos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.groupBoxOperaciones = new System.Windows.Forms.GroupBox();
            this.btnTripulacionVuelo = new System.Windows.Forms.Button();
            this.btnVuelos = new System.Windows.Forms.Button();
            this.btnReservaciones = new System.Windows.Forms.Button();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.btnGestionarTripulacion = new System.Windows.Forms.Button();
            this.btnGestionarRutas = new System.Windows.Forms.Button();
            this.btnGestionarAviones = new System.Windows.Forms.Button();
            this.btnGestionarPasajero = new System.Windows.Forms.Button();
            this.btnGestionAerolineas = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnprobar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.groupBoxOperaciones.SuspendLayout();
            this.groupBoxDatos.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(900, 65);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "✈️ SISTEMA DE GESTIÓN DE BOLETOS AÉREOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelMenu.Controls.Add(this.groupBoxOperaciones);
            this.panelMenu.Controls.Add(this.groupBoxDatos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 65);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.panelMenu.Size = new System.Drawing.Size(900, 422);
            this.panelMenu.TabIndex = 1;
            // 
            // groupBoxOperaciones
            // 
            this.groupBoxOperaciones.Controls.Add(this.btnTripulacionVuelo);
            this.groupBoxOperaciones.Controls.Add(this.btnVuelos);
            this.groupBoxOperaciones.Controls.Add(this.btnReservaciones);
            this.groupBoxOperaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxOperaciones.Location = new System.Drawing.Point(465, 24);
            this.groupBoxOperaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOperaciones.Name = "groupBoxOperaciones";
            this.groupBoxOperaciones.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOperaciones.Size = new System.Drawing.Size(390, 341);
            this.groupBoxOperaciones.TabIndex = 1;
            this.groupBoxOperaciones.TabStop = false;
            this.groupBoxOperaciones.Text = "⚙️ OPERACIONES PRINCIPALES";
            // 
            // btnTripulacionVuelo
            // 
            this.btnTripulacionVuelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnTripulacionVuelo.FlatAppearance.BorderSize = 0;
            this.btnTripulacionVuelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripulacionVuelo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnTripulacionVuelo.ForeColor = System.Drawing.Color.White;
            this.btnTripulacionVuelo.Location = new System.Drawing.Point(30, 236);
            this.btnTripulacionVuelo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTripulacionVuelo.Name = "btnTripulacionVuelo";
            this.btnTripulacionVuelo.Size = new System.Drawing.Size(330, 65);
            this.btnTripulacionVuelo.TabIndex = 2;
            this.btnTripulacionVuelo.Text = "👥 Asignación de Tripulación a Vuelos";
            this.btnTripulacionVuelo.UseVisualStyleBackColor = false;
            // 
            // btnVuelos
            // 
            this.btnVuelos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnVuelos.FlatAppearance.BorderSize = 0;
            this.btnVuelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuelos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnVuelos.ForeColor = System.Drawing.Color.White;
            this.btnVuelos.Location = new System.Drawing.Point(30, 146);
            this.btnVuelos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVuelos.Name = "btnVuelos";
            this.btnVuelos.Size = new System.Drawing.Size(330, 65);
            this.btnVuelos.TabIndex = 1;
            this.btnVuelos.Text = "🛫 GESTIÓN DE VUELOS";
            this.btnVuelos.UseVisualStyleBackColor = false;
            this.btnVuelos.Click += new System.EventHandler(this.btnVuelos_Click);
            // 
            // btnReservaciones
            // 
            this.btnReservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnReservaciones.FlatAppearance.BorderSize = 0;
            this.btnReservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservaciones.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnReservaciones.ForeColor = System.Drawing.Color.White;
            this.btnReservaciones.Location = new System.Drawing.Point(30, 57);
            this.btnReservaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReservaciones.Name = "btnReservaciones";
            this.btnReservaciones.Size = new System.Drawing.Size(330, 65);
            this.btnReservaciones.TabIndex = 0;
            this.btnReservaciones.Text = "🎫 GESTIÓN DE RESERVACIONES";
            this.btnReservaciones.UseVisualStyleBackColor = false;
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.btnGestionarTripulacion);
            this.groupBoxDatos.Controls.Add(this.btnGestionarRutas);
            this.groupBoxDatos.Controls.Add(this.btnGestionarAviones);
            this.groupBoxDatos.Controls.Add(this.btnGestionarPasajero);
            this.groupBoxDatos.Controls.Add(this.btnGestionAerolineas);
            this.groupBoxDatos.Controls.Add(this.btnGestionUsuarios);
            this.groupBoxDatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxDatos.Location = new System.Drawing.Point(45, 24);
            this.groupBoxDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDatos.Size = new System.Drawing.Size(390, 341);
            this.groupBoxDatos.TabIndex = 0;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "📊 GESTIÓN DE DATOS MAESTROS";
            // 
            // btnGestionarTripulacion
            // 
            this.btnGestionarTripulacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnGestionarTripulacion.FlatAppearance.BorderSize = 0;
            this.btnGestionarTripulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarTripulacion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionarTripulacion.ForeColor = System.Drawing.Color.White;
            this.btnGestionarTripulacion.Location = new System.Drawing.Point(30, 305);
            this.btnGestionarTripulacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionarTripulacion.Name = "btnGestionarTripulacion";
            this.btnGestionarTripulacion.Size = new System.Drawing.Size(330, 41);
            this.btnGestionarTripulacion.TabIndex = 5;
            this.btnGestionarTripulacion.Text = "👨‍✈️ Gestión de Tripulación";
            this.btnGestionarTripulacion.UseVisualStyleBackColor = false;
            this.btnGestionarTripulacion.Click += new System.EventHandler(this.btnGestionarTripulacion_Click);
            // 
            // btnGestionarRutas
            // 
            this.btnGestionarRutas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnGestionarRutas.FlatAppearance.BorderSize = 0;
            this.btnGestionarRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarRutas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionarRutas.ForeColor = System.Drawing.Color.White;
            this.btnGestionarRutas.Location = new System.Drawing.Point(30, 252);
            this.btnGestionarRutas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionarRutas.Name = "btnGestionarRutas";
            this.btnGestionarRutas.Size = new System.Drawing.Size(330, 41);
            this.btnGestionarRutas.TabIndex = 4;
            this.btnGestionarRutas.Text = "🗺️ Gestión de Rutas";
            this.btnGestionarRutas.UseVisualStyleBackColor = false;
            this.btnGestionarRutas.Click += new System.EventHandler(this.btnGestionarRutas_Click);
            // 
            // btnGestionarAviones
            // 
            this.btnGestionarAviones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnGestionarAviones.FlatAppearance.BorderSize = 0;
            this.btnGestionarAviones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarAviones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionarAviones.ForeColor = System.Drawing.Color.White;
            this.btnGestionarAviones.Location = new System.Drawing.Point(30, 199);
            this.btnGestionarAviones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionarAviones.Name = "btnGestionarAviones";
            this.btnGestionarAviones.Size = new System.Drawing.Size(330, 41);
            this.btnGestionarAviones.TabIndex = 3;
            this.btnGestionarAviones.Text = "🛩️ Gestión de Aviones";
            this.btnGestionarAviones.UseVisualStyleBackColor = false;
            this.btnGestionarAviones.Click += new System.EventHandler(this.btnGestionarAviones_Click);
            // 
            // btnGestionarPasajero
            // 
            this.btnGestionarPasajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnGestionarPasajero.FlatAppearance.BorderSize = 0;
            this.btnGestionarPasajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarPasajero.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionarPasajero.ForeColor = System.Drawing.Color.White;
            this.btnGestionarPasajero.Location = new System.Drawing.Point(30, 146);
            this.btnGestionarPasajero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionarPasajero.Name = "btnGestionarPasajero";
            this.btnGestionarPasajero.Size = new System.Drawing.Size(330, 41);
            this.btnGestionarPasajero.TabIndex = 2;
            this.btnGestionarPasajero.Text = "🧳 Gestión de Pasajeros";
            this.btnGestionarPasajero.UseVisualStyleBackColor = false;
            this.btnGestionarPasajero.Click += new System.EventHandler(this.btnGestionarPasajero_Click);
            // 
            // btnGestionAerolineas
            // 
            this.btnGestionAerolineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGestionAerolineas.FlatAppearance.BorderSize = 0;
            this.btnGestionAerolineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionAerolineas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionAerolineas.ForeColor = System.Drawing.Color.White;
            this.btnGestionAerolineas.Location = new System.Drawing.Point(30, 93);
            this.btnGestionAerolineas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionAerolineas.Name = "btnGestionAerolineas";
            this.btnGestionAerolineas.Size = new System.Drawing.Size(330, 41);
            this.btnGestionAerolineas.TabIndex = 1;
            this.btnGestionAerolineas.Text = "✈️ Gestión de Aerolíneas";
            this.btnGestionAerolineas.UseVisualStyleBackColor = false;
            this.btnGestionAerolineas.Click += new System.EventHandler(this.btnGestionAerolineas_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGestionUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGestionUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(30, 41);
            this.btnGestionUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(330, 41);
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "👤 Gestión de Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = false;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Controls.Add(this.btnprobar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 487);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(900, 41);
            this.panelFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(15, 12);
            this.lblFooter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(375, 19);
            this.lblFooter.TabIndex = 1;
            this.lblFooter.Text = "© 2025 - Sistema de Boletos Aéreos | Universidad de El Salvador";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnprobar
            // 
            this.btnprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnprobar.FlatAppearance.BorderSize = 0;
            this.btnprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprobar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnprobar.ForeColor = System.Drawing.Color.White;
            this.btnprobar.Location = new System.Drawing.Point(788, 8);
            this.btnprobar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnprobar.Name = "btnprobar";
            this.btnprobar.Size = new System.Drawing.Size(98, 24);
            this.btnprobar.TabIndex = 0;
            this.btnprobar.Text = "🔌 Probar Conexión";
            this.btnprobar.UseVisualStyleBackColor = false;
            this.btnprobar.Click += new System.EventHandler(this.btnprobar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 528);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Boletos Aéreos - Menú Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.groupBoxOperaciones.ResumeLayout(false);
            this.groupBoxDatos.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.GroupBox groupBoxOperaciones;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnGestionAerolineas;
        private System.Windows.Forms.Button btnGestionarPasajero;
        private System.Windows.Forms.Button btnGestionarAviones;
        private System.Windows.Forms.Button btnGestionarRutas;
        private System.Windows.Forms.Button btnGestionarTripulacion;
        private System.Windows.Forms.Button btnReservaciones;
        private System.Windows.Forms.Button btnVuelos;
        private System.Windows.Forms.Button btnTripulacionVuelo;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnprobar;
        private System.Windows.Forms.Label lblFooter;
    }
}