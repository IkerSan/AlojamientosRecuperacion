namespace AlojamientosIkerSanchez
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasBásicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesDeReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasBásicasToolStripMenuItem,
            this.gestiónReservasToolStripMenuItem,
            this.detallesDeReservaToolStripMenuItem,
            this.gestiónDePagosToolStripMenuItem,
            this.detallesDePagoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // consultasBásicasToolStripMenuItem
            // 
            this.consultasBásicasToolStripMenuItem.Name = "consultasBásicasToolStripMenuItem";
            this.consultasBásicasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.consultasBásicasToolStripMenuItem.Text = "Consultas Básicas";
            this.consultasBásicasToolStripMenuItem.Click += new System.EventHandler(this.consultasBásicasToolStripMenuItem_Click);
            // 
            // gestiónReservasToolStripMenuItem
            // 
            this.gestiónReservasToolStripMenuItem.Name = "gestiónReservasToolStripMenuItem";
            this.gestiónReservasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestiónReservasToolStripMenuItem.Text = "Gestión de Reservas";
            this.gestiónReservasToolStripMenuItem.Click += new System.EventHandler(this.gestiónReservasToolStripMenuItem_Click);
            // 
            // detallesDeReservaToolStripMenuItem
            // 
            this.detallesDeReservaToolStripMenuItem.Name = "detallesDeReservaToolStripMenuItem";
            this.detallesDeReservaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.detallesDeReservaToolStripMenuItem.Text = "Detalles de Reserva";
            this.detallesDeReservaToolStripMenuItem.Click += new System.EventHandler(this.detallesDeReservaToolStripMenuItem_Click);
            // 
            // gestiónDePagosToolStripMenuItem
            // 
            this.gestiónDePagosToolStripMenuItem.Name = "gestiónDePagosToolStripMenuItem";
            this.gestiónDePagosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestiónDePagosToolStripMenuItem.Text = "Gestión de Pagos";
            this.gestiónDePagosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDePagosToolStripMenuItem_Click);
            // 
            // detallesDePagoToolStripMenuItem
            // 
            this.detallesDePagoToolStripMenuItem.Name = "detallesDePagoToolStripMenuItem";
            this.detallesDePagoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.detallesDePagoToolStripMenuItem.Text = "Detalles de Pago";
            this.detallesDePagoToolStripMenuItem.Click += new System.EventHandler(this.detallesDePagoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasBásicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detallesDeReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detallesDePagoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

