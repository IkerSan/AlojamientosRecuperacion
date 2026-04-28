namespace AlojamientosIkerSanchez
{
    partial class FrmConsultasBasicas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEstablecimientos = new System.Windows.Forms.Button();
            this.btnUnidadesAlojamiento = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(73, 374);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(128, 40);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Ver clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEstablecimientos
            // 
            this.btnEstablecimientos.Location = new System.Drawing.Point(234, 376);
            this.btnEstablecimientos.Name = "btnEstablecimientos";
            this.btnEstablecimientos.Size = new System.Drawing.Size(138, 50);
            this.btnEstablecimientos.TabIndex = 1;
            this.btnEstablecimientos.Text = "Ver establecimientos";
            this.btnEstablecimientos.UseVisualStyleBackColor = true;
            this.btnEstablecimientos.Click += new System.EventHandler(this.btnEstablecimientos_Click);
            // 
            // btnUnidadesAlojamiento
            // 
            this.btnUnidadesAlojamiento.Location = new System.Drawing.Point(411, 376);
            this.btnUnidadesAlojamiento.Name = "btnUnidadesAlojamiento";
            this.btnUnidadesAlojamiento.Size = new System.Drawing.Size(138, 50);
            this.btnUnidadesAlojamiento.TabIndex = 2;
            this.btnUnidadesAlojamiento.Text = "Ver unidades de alojamiento";
            this.btnUnidadesAlojamiento.UseVisualStyleBackColor = true;
            this.btnUnidadesAlojamiento.Click += new System.EventHandler(this.btnUnidadesAlojamiento_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(73, 33);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.RowHeadersWidth = 51;
            this.dgvConsultas.RowTemplate.Height = 24;
            this.dgvConsultas.Size = new System.Drawing.Size(643, 314);
            this.dgvConsultas.TabIndex = 3;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(578, 374);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(138, 40);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmConsultasBasicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.btnUnidadesAlojamiento);
            this.Controls.Add(this.btnEstablecimientos);
            this.Controls.Add(this.btnClientes);
            this.Name = "FrmConsultasBasicas";
            this.Text = "FrmConsultasBasicas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEstablecimientos;
        private System.Windows.Forms.Button btnUnidadesAlojamiento;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Button btnVolver;
    }
}