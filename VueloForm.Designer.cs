namespace Sistema_de_Boletos_Aéreos
{
    partial class VueloForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numAsientos = new System.Windows.Forms.NumericUpDown();
            this.numTarifaBase = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.cmbAvion = new System.Windows.Forms.ComboBox();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.cmbAerolinea = new System.Windows.Forms.ComboBox();
            this.txtNumeroVuelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvVuelos = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarifaBase)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numAsientos);
            this.groupBox1.Controls.Add(this.numTarifaBase);
            this.groupBox1.Controls.Add(this.dtpFechaLlegada);
            this.groupBox1.Controls.Add(this.dtpFechaSalida);
            this.groupBox1.Controls.Add(this.cmbAvion);
            this.groupBox1.Controls.Add(this.cmbRuta);
            this.groupBox1.Controls.Add(this.cmbAerolinea);
            this.groupBox1.Controls.Add(this.txtNumeroVuelo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Vuelo";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Programado",
            "En Vuelo",
            "Completado",
            "Cancelado",
            "Retrasado"});
            this.cmbEstado.Location = new System.Drawing.Point(180, 295);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(250, 21);
            this.cmbEstado.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Estado:";
            // 
            // numAsientos
            // 
            this.numAsientos.Location = new System.Drawing.Point(180, 260);
            this.numAsientos.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAsientos.Name = "numAsientos";
            this.numAsientos.Size = new System.Drawing.Size(250, 20);
            this.numAsientos.TabIndex = 14;
            // 
            // numTarifaBase
            // 
            this.numTarifaBase.DecimalPlaces = 2;
            this.numTarifaBase.Location = new System.Drawing.Point(180, 225);
            this.numTarifaBase.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTarifaBase.Name = "numTarifaBase";
            this.numTarifaBase.Size = new System.Drawing.Size(250, 20);
            this.numTarifaBase.TabIndex = 13;
            // 
            // dtpFechaLlegada
            // 
            this.dtpFechaLlegada.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLlegada.Location = new System.Drawing.Point(180, 190);
            this.dtpFechaLlegada.Name = "dtpFechaLlegada";
            this.dtpFechaLlegada.Size = new System.Drawing.Size(250, 20);
            this.dtpFechaLlegada.TabIndex = 12;
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaSalida.Location = new System.Drawing.Point(180, 155);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(250, 20);
            this.dtpFechaSalida.TabIndex = 11;
            // 
            // cmbAvion
            // 
            this.cmbAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvion.FormattingEnabled = true;
            this.cmbAvion.Location = new System.Drawing.Point(180, 120);
            this.cmbAvion.Name = "cmbAvion";
            this.cmbAvion.Size = new System.Drawing.Size(250, 21);
            this.cmbAvion.TabIndex = 10;
            // 
            // cmbRuta
            // 
            this.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Location = new System.Drawing.Point(180, 85);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(250, 21);
            this.cmbRuta.TabIndex = 9;
            // 
            // cmbAerolinea
            // 
            this.cmbAerolinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAerolinea.FormattingEnabled = true;
            this.cmbAerolinea.Location = new System.Drawing.Point(180, 50);
            this.cmbAerolinea.Name = "cmbAerolinea";
            this.cmbAerolinea.Size = new System.Drawing.Size(250, 21);
            this.cmbAerolinea.TabIndex = 8;
            // 
            // txtNumeroVuelo
            // 
            this.txtNumeroVuelo.Location = new System.Drawing.Point(180, 20);
            this.txtNumeroVuelo.Name = "txtNumeroVuelo";
            this.txtNumeroVuelo.Size = new System.Drawing.Size(250, 20);
            this.txtNumeroVuelo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Asientos Disponibles:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tarifa Base:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de Llegada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Avión:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ruta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aerolínea:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Location = new System.Drawing.Point(12, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(340, 30);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 35);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(230, 30);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar Vuelo";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(120, 30);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(10, 30);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvVuelos
            // 
            this.dgvVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelos.Location = new System.Drawing.Point(478, 60);
            this.dgvVuelos.Name = "dgvVuelos";
            this.dgvVuelos.Size = new System.Drawing.Size(710, 426);
            this.dgvVuelos.TabIndex = 2;
            this.dgvVuelos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVuelos_CellDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(450, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 26);
            this.label9.TabIndex = 3;
            this.label9.Text = "GESTIÓN DE VUELOS";
            // 
            // VueloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 500);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvVuelos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VueloForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Vuelos - Sistema de Boletos Aéreos";
            this.Load += new System.EventHandler(this.VueloForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarifaBase)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroVuelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAerolinea;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.ComboBox cmbAvion;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.DateTimePicker dtpFechaLlegada;
        private System.Windows.Forms.NumericUpDown numTarifaBase;
        private System.Windows.Forms.NumericUpDown numAsientos;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvVuelos;
        private System.Windows.Forms.Label label9;
    }
}