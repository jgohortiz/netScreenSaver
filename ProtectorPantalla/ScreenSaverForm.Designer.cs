namespace ScreenSaver
{
    partial class ScreenSaverForm
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
            this.components = new System.ComponentModel.Container();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.cuadroTimer = new System.Windows.Forms.Timer(this.components);
            this.imgMensaje = new System.Windows.Forms.PictureBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.imgCuadro = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCuadro)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMensaje
            // 
            this.imgMensaje.BackColor = System.Drawing.Color.Transparent;
            this.imgMensaje.Enabled = false;
            this.imgMensaje.Location = new System.Drawing.Point(0, 0);
            this.imgMensaje.Name = "imgMensaje";
            this.imgMensaje.Size = new System.Drawing.Size(100, 50);
            this.imgMensaje.TabIndex = 1;
            this.imgMensaje.TabStop = false;
            this.imgMensaje.WaitOnLoad = true;
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.BackColor = System.Drawing.Color.Transparent;
            this.lblPropietario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPropietario.Location = new System.Drawing.Point(194, 9);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(304, 13);
            this.lblPropietario.TabIndex = 2;
            this.lblPropietario.Text = "© 2025 404q9l - FoxShell - netScreenSaver";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHora.Location = new System.Drawing.Point(48, 73);
            this.lblHora.Margin = new System.Windows.Forms.Padding(6);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(120, 31);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "00:00:00";
            this.lblHora.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFecha.Location = new System.Drawing.Point(179, 111);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(6);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(152, 31);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "0000-00-00";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFecha.Visible = false;
            // 
            // lblSalir
            // 
            this.lblSalir.AutoSize = true;
            this.lblSalir.BackColor = System.Drawing.Color.Transparent;
            this.lblSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSalir.Location = new System.Drawing.Point(-3, 227);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(239, 13);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "Para salir presione la tecla ESC o mueva el ratón.";
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.Enabled = false;
            this.imgLogo.Location = new System.Drawing.Point(0, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(100, 50);
            this.imgLogo.TabIndex = 1;
            this.imgLogo.TabStop = false;
            this.imgLogo.WaitOnLoad = true;
            // 
            // imgCuadro
            // 
            this.imgCuadro.Location = new System.Drawing.Point(387, 64);
            this.imgCuadro.Name = "imgCuadro";
            this.imgCuadro.Size = new System.Drawing.Size(50, 50);
            this.imgCuadro.TabIndex = 6;
            this.imgCuadro.TabStop = false;
            this.imgCuadro.BackColor = System.Drawing.Color.Black;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(508, 260);
            this.Controls.Add(this.imgCuadro);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lblSalir);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblPropietario);
            this.Controls.Add(this.imgMensaje);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmScreenSaver";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.imgMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCuadro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Timer cuadroTimer;
        private System.Windows.Forms.PictureBox imgMensaje;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.PictureBox imgCuadro;
    }
}

