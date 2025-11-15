namespace Sistema_de_Boletos_Aéreos
{
    partial class DashboardForm
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelOperaciones = new System.Windows.Forms.Panel();
            this.lblOperaciones = new System.Windows.Forms.Label();
            this.btnTripulacion = new System.Windows.Forms.Button();
            this.btnVuelos = new System.Windows.Forms.Button();
            this.btnReservaciones = new System.Windows.Forms.Button();
            this.panelCatalogos = new System.Windows.Forms.Panel();
            this.lblCatalogos = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnTripulantes = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnAviones = new System.Windows.Forms.Button();
            this.btnAerolineas = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelOperaciones.SuspendLayout();
            this.panelCatalogos.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(400, 75);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(364, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Sistema integral de gestión y reservación de vuelos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(280, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(627, 51);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "✈️ SISTEMA DE BOLETOS AÉREOS";
            // 
            // panelOperaciones
            // 
            this.panelOperaciones.BackColor = System.Drawing.Color.Transparent;
            this.panelOperaciones.Controls.Add(this.lblOperaciones);
            this.panelOperaciones.Controls.Add(this.btnTripulacion);
            this.panelOperaciones.Controls.Add(this.btnVuelos);
            this.panelOperaciones.Controls.Add(this.btnReservaciones);
            this.panelOperaciones.Location = new System.Drawing.Point(40, 150);
            this.panelOperaciones.Name = "panelOperaciones";
            this.panelOperaciones.Size = new System.Drawing.Size(1120, 230);
            this.panelOperaciones.TabIndex = 1;
            // 
            // lblOperaciones
            // 
            this.lblOperaciones.AutoSize = true;
            this.lblOperaciones.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblOperaciones.Location = new System.Drawing.Point(15, 15);
            this.lblOperaciones.Name = "lblOperaciones";
            this.lblOperaciones.Size = new System.Drawing.Size(343, 30);
            this.lblOperaciones.TabIndex = 3;
            this.lblOperaciones.Text = "⚙️ OPERACIONES PRINCIPALES";
            // 
            // btnTripulacion
            // 
            this.btnTripulacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTripulacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripulacion.FlatAppearance.BorderSize = 0;
            this.btnTripulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripulacion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTripulacion.ForeColor = System.Drawing.Color.White;
            this.btnTripulacion.Location = new System.Drawing.Point(760, 70);
            this.btnTripulacion.Name = "btnTripulacion";
            this.btnTripulacion.Size = new System.Drawing.Size(340, 130);
            this.btnTripulacion.TabIndex = 2;
            this.btnTripulacion.Text = "👥\r\nAsignación de\r\nTripulación a Vuelos";
            this.btnTripulacion.UseVisualStyleBackColor = false;
            this.btnTripulacion.Click += new System.EventHandler(this.btnTripulacion_Click);
            this.btnTripulacion.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnTripulacion.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnVuelos
            // 
            this.btnVuelos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnVuelos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVuelos.FlatAppearance.BorderSize = 0;
            this.btnVuelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuelos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVuelos.ForeColor = System.Drawing.Color.White;
            this.btnVuelos.Location = new System.Drawing.Point(390, 70);
            this.btnVuelos.Name = "btnVuelos";
            this.btnVuelos.Size = new System.Drawing.Size(340, 130);
            this.btnVuelos.TabIndex = 1;
            this.btnVuelos.Text = "✈️\r\nGESTIÓN DE\r\nVUELOS";
            this.btnVuelos.UseVisualStyleBackColor = false;
            this.btnVuelos.Click += new System.EventHandler(this.btnVuelos_Click);
            this.btnVuelos.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnVuelos.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnReservaciones
            // 
            this.btnReservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnReservaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservaciones.FlatAppearance.BorderSize = 0;
            this.btnReservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservaciones.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservaciones.ForeColor = System.Drawing.Color.White;
            this.btnReservaciones.Location = new System.Drawing.Point(20, 70);
            this.btnReservaciones.Name = "btnReservaciones";
            this.btnReservaciones.Size = new System.Drawing.Size(340, 130);
            this.btnReservaciones.TabIndex = 0;
            this.btnReservaciones.Text = "🎫\r\nGESTIÓN DE\r\nRESERVACIONES";
            this.btnReservaciones.UseVisualStyleBackColor = false;
            this.btnReservaciones.Click += new System.EventHandler(this.btnReservaciones_Click);
            this.btnReservaciones.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnReservaciones.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // panelCatalogos
            // 
            this.panelCatalogos.BackColor = System.Drawing.Color.Transparent;
            this.panelCatalogos.Controls.Add(this.lblCatalogos);
            this.panelCatalogos.Controls.Add(this.btnUsuarios);
            this.panelCatalogos.Controls.Add(this.btnTripulantes);
            this.panelCatalogos.Controls.Add(this.btnRutas);
            this.panelCatalogos.Controls.Add(this.btnAviones);
            this.panelCatalogos.Controls.Add(this.btnAerolineas);
            this.panelCatalogos.Location = new System.Drawing.Point(40, 400);
            this.panelCatalogos.Name = "panelCatalogos";
            this.panelCatalogos.Size = new System.Drawing.Size(1120, 230);
            this.panelCatalogos.TabIndex = 2;
            // 
            // lblCatalogos
            // 
            this.lblCatalogos.AutoSize = true;
            this.lblCatalogos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalogos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCatalogos.Location = new System.Drawing.Point(15, 15);
            this.lblCatalogos.Name = "lblCatalogos";
            this.lblCatalogos.Size = new System.Drawing.Size(273, 30);
            this.lblCatalogos.TabIndex = 5;
            this.lblCatalogos.Text = "📊 CATÁLOGOS BÁSICOS";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(910, 65);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(190, 140);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "👤\r\n\r\nGestión de\r\nUsuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnUsuarios.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnUsuarios.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnTripulantes
            // 
            this.btnTripulantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnTripulantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripulantes.FlatAppearance.BorderSize = 0;
            this.btnTripulantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripulantes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTripulantes.ForeColor = System.Drawing.Color.White;
            this.btnTripulantes.Location = new System.Drawing.Point(690, 65);
            this.btnTripulantes.Name = "btnTripulantes";
            this.btnTripulantes.Size = new System.Drawing.Size(190, 140);
            this.btnTripulantes.TabIndex = 3;
            this.btnTripulantes.Text = "👨‍✈️\r\n\r\nGestión de\r\nTripulantes";
            this.btnTripulantes.UseVisualStyleBackColor = false;
            this.btnTripulantes.Click += new System.EventHandler(this.btnTripulantes_Click);
            this.btnTripulantes.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnTripulantes.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnRutas
            // 
            this.btnRutas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnRutas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRutas.FlatAppearance.BorderSize = 0;
            this.btnRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutas.ForeColor = System.Drawing.Color.White;
            this.btnRutas.Location = new System.Drawing.Point(470, 65);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(190, 140);
            this.btnRutas.TabIndex = 2;
            this.btnRutas.Text = "🛣️\r\n\r\nGestión de\r\nRutas";
            this.btnRutas.UseVisualStyleBackColor = false;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            this.btnRutas.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnRutas.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnAviones
            // 
            this.btnAviones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAviones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAviones.FlatAppearance.BorderSize = 0;
            this.btnAviones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAviones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAviones.ForeColor = System.Drawing.Color.White;
            this.btnAviones.Location = new System.Drawing.Point(250, 65);
            this.btnAviones.Name = "btnAviones";
            this.btnAviones.Size = new System.Drawing.Size(190, 140);
            this.btnAviones.TabIndex = 1;
            this.btnAviones.Text = "✈️\r\n\r\nGestión de\r\nAviones";
            this.btnAviones.UseVisualStyleBackColor = false;
            this.btnAviones.Click += new System.EventHandler(this.btnAviones_Click);
            this.btnAviones.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnAviones.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnAerolineas
            // 
            this.btnAerolineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAerolineas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAerolineas.FlatAppearance.BorderSize = 0;
            this.btnAerolineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAerolineas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAerolineas.ForeColor = System.Drawing.Color.White;
            this.btnAerolineas.Location = new System.Drawing.Point(30, 65);
            this.btnAerolineas.Name = "btnAerolineas";
            this.btnAerolineas.Size = new System.Drawing.Size(190, 140);
            this.btnAerolineas.TabIndex = 0;
            this.btnAerolineas.Text = "🏢\r\n\r\nGestión de\r\nAerolíneas";
            this.btnAerolineas.UseVisualStyleBackColor = false;
            this.btnAerolineas.Click += new System.EventHandler(this.btnAerolineas_Click);
            this.btnAerolineas.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnAerolineas.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelFooter.Controls.Add(this.btnSalir);
            this.panelFooter.Controls.Add(this.lblVersion);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 650);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1200, 70);
            this.panelFooter.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(1040, 15);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 40);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "🚪 Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(30, 25);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(221, 15);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Sistema de Boletos Aéreos | UES en Línea";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelCatalogos);
            this.Controls.Add(this.panelOperaciones);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Boletos Aéreos - Dashboard Principal";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelOperaciones.ResumeLayout(false);
            this.panelOperaciones.PerformLayout();
            this.panelCatalogos.ResumeLayout(false);
            this.panelCatalogos.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelOperaciones;
        private System.Windows.Forms.Label lblOperaciones;
        private System.Windows.Forms.Button btnReservaciones;
        private System.Windows.Forms.Button btnVuelos;
        private System.Windows.Forms.Button btnTripulacion;
        private System.Windows.Forms.Panel panelCatalogos;
        private System.Windows.Forms.Label lblCatalogos;
        private System.Windows.Forms.Button btnAerolineas;
        private System.Windows.Forms.Button btnAviones;
        private System.Windows.Forms.Button btnRutas;
        private System.Windows.Forms.Button btnTripulantes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnSalir;
    }
}