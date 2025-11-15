
namespace Sistema_de_Boletos_Aéreos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnprobar = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnGestionAerolineas = new System.Windows.Forms.Button();
            this.btnGestionarPasajero = new System.Windows.Forms.Button();
            this.btnGestionarRutas = new System.Windows.Forms.Button();
            this.btnGestionarAviones = new System.Windows.Forms.Button();
            this.btnGestionarTripulacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnprobar
            // 
            this.btnprobar.Location = new System.Drawing.Point(365, 350);
            this.btnprobar.Name = "btnprobar";
            this.btnprobar.Size = new System.Drawing.Size(75, 23);
            this.btnprobar.TabIndex = 0;
            this.btnprobar.Text = "buttonprobar";
            this.btnprobar.UseVisualStyleBackColor = true;
            this.btnprobar.Click += new System.EventHandler(this.btnprobar_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Location = new System.Drawing.Point(69, 350);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(250, 23);
            this.btnGestionUsuarios.TabIndex = 1;
            this.btnGestionUsuarios.Text = "Gestion De Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionAerolineas
            // 
            this.btnGestionAerolineas.Location = new System.Drawing.Point(69, 303);
            this.btnGestionAerolineas.Name = "btnGestionAerolineas";
            this.btnGestionAerolineas.Size = new System.Drawing.Size(250, 23);
            this.btnGestionAerolineas.TabIndex = 2;
            this.btnGestionAerolineas.Text = "Gestion De Aerolineas";
            this.btnGestionAerolineas.UseVisualStyleBackColor = true;
            this.btnGestionAerolineas.Click += new System.EventHandler(this.btnGestionAerolineas_Click);
            // 
            // btnGestionarPasajero
            // 
            this.btnGestionarPasajero.Location = new System.Drawing.Point(69, 255);
            this.btnGestionarPasajero.Name = "btnGestionarPasajero";
            this.btnGestionarPasajero.Size = new System.Drawing.Size(250, 23);
            this.btnGestionarPasajero.TabIndex = 3;
            this.btnGestionarPasajero.Text = "Gestion De Pasajeros";
            this.btnGestionarPasajero.UseVisualStyleBackColor = true;
            this.btnGestionarPasajero.Click += new System.EventHandler(this.btnGestionarPasajero_Click);
            // 
            // btnGestionarRutas
            // 
            this.btnGestionarRutas.Location = new System.Drawing.Point(69, 211);
            this.btnGestionarRutas.Name = "btnGestionarRutas";
            this.btnGestionarRutas.Size = new System.Drawing.Size(250, 23);
            this.btnGestionarRutas.TabIndex = 4;
            this.btnGestionarRutas.Text = "Gestion De Rutas";
            this.btnGestionarRutas.UseVisualStyleBackColor = true;
            this.btnGestionarRutas.Click += new System.EventHandler(this.btnGestionarRutas_Click);
            // 
            // btnGestionarAviones
            // 
            this.btnGestionarAviones.Location = new System.Drawing.Point(69, 171);
            this.btnGestionarAviones.Name = "btnGestionarAviones";
            this.btnGestionarAviones.Size = new System.Drawing.Size(250, 23);
            this.btnGestionarAviones.TabIndex = 5;
            this.btnGestionarAviones.Text = "Gestion De Aviones";
            this.btnGestionarAviones.UseVisualStyleBackColor = true;
            this.btnGestionarAviones.Click += new System.EventHandler(this.btnGestionarAviones_Click);
            // 
            // btnGestionarTripulacion
            // 
            this.btnGestionarTripulacion.Location = new System.Drawing.Point(69, 111);
            this.btnGestionarTripulacion.Name = "btnGestionarTripulacion";
            this.btnGestionarTripulacion.Size = new System.Drawing.Size(250, 23);
            this.btnGestionarTripulacion.TabIndex = 6;
            this.btnGestionarTripulacion.Text = "Gestion De Tripulacion";
            this.btnGestionarTripulacion.UseVisualStyleBackColor = true;
            this.btnGestionarTripulacion.Click += new System.EventHandler(this.btnGestionarTripulacion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGestionarTripulacion);
            this.Controls.Add(this.btnGestionarAviones);
            this.Controls.Add(this.btnGestionarRutas);
            this.Controls.Add(this.btnGestionarPasajero);
            this.Controls.Add(this.btnGestionAerolineas);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnprobar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnprobar;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnGestionAerolineas;
        private System.Windows.Forms.Button btnGestionarPasajero;
        private System.Windows.Forms.Button btnGestionarRutas;
        private System.Windows.Forms.Button btnGestionarAviones;
        private System.Windows.Forms.Button btnGestionarTripulacion;
    }
}

