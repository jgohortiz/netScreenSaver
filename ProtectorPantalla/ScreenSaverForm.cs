using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        #region Win32 API functions

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion


        private Point mouseLocation;
        private bool previewMode = false;
        private Random rand = new Random();
        private int intBoxDx = -1;
        private int intBoxDy = -1;
        private int intLogoDx = -1;
        private int intLogoDy = -1;        
        private int intDireccion = 1;
        private int intColor = 0;
        private int intColorInit = 255;
        private int intTime = 0;
        private int intTimeStep = 510;
        private int intTimeStepMax = 630;
        private int intMovSpeed = 1;


        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);


            previewMode = true;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {            
            Cursor.Hide();            
            TopMost = true;

            this.imgMensaje.LoadAsync(@"c:\OEMInfo\netScreenSaverBanner.png");
            this.imgMensaje.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgMensaje.Location = new System.Drawing.Point((this.Width/2)-(this.imgMensaje.Width/2), (this.Height/2) - (this.imgMensaje.Height / 2));
            this.imgMensaje.Visible = false;

            this.imgLogo.LoadAsync(@"c:\OEMInfo\netScreenSaverLogo.png");
            this.imgLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgLogo.Location = new System.Drawing.Point((this.Width / 2) - (this.imgLogo.Width / 2), (this.Height / 2) - (this.imgLogo.Height / 2));
            this.imgLogo.Visible = true;

            this.lblPropietario.Location = new System.Drawing.Point(this.Width - this.lblPropietario.Width - 10, this.Height - this.lblPropietario.Height - 10);
            this.lblSalir.Location = new System.Drawing.Point(10, this.Height - this.lblSalir.Height - 10);

            this.imgCuadro.Location = new System.Drawing.Point(rand.Next(Math.Max(1, Bounds.Width - lblFecha.Width)), rand.Next(Math.Max(1, Bounds.Height - lblFecha.Height)));
            this.imgCuadro.Location = new System.Drawing.Point(rand.Next(Math.Max(1, Bounds.Width - lblHora.Width)), rand.Next(Math.Max(1, Bounds.Height - lblHora.Height)));
            this.imgCuadro.Visible = false;


            this.lblFecha.Location = new System.Drawing.Point(this.Width - this.lblFecha.Width - 10, this.lblPropietario.Top - this.lblFecha.Height - 10);
            this.lblHora.Location = new System.Drawing.Point(10, this.lblSalir.Top - this.lblHora.Height - 10);


            clockTimer.Interval = 1000;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            clockTimer.Tick += new EventHandler(clockTimer_Tick);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            clockTimer.Start();

            cuadroTimer.Interval = 1;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            cuadroTimer.Tick += new EventHandler(cuadro_Tick);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            cuadroTimer.Start();

        }

        private Color GetContrastingColor(Color backgroundColor)
        {
            // Usamos la fórmula estándar de luminancia
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;

            return luminance > 0.5 ? Color.Black : Color.White;
        }
        private int GenerarEnteroAleatorio(int minimo, int maximo)
        {
            Random rnd = new Random();
            return rnd.Next(minimo, maximo + 1); // maximo es inclusivo
        }        
        private void clockTimer_Tick(object sender, System.EventArgs e)
        {
            // Texto
            Color lvColorfondo = this.BackColor; // o el color de otro fondo

            this.lblHora.Text = DateTime.Now.ToString("HH:mm:ss");            
            this.lblFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Cambiando el color del texto
            Label[] loLabels = { lblHora, lblFecha, lblPropietario, lblSalir };
            foreach (Label lolbl in loLabels)
            {
                lolbl.ForeColor = GetContrastingColor(lvColorfondo);
                lolbl.Visible = true;
            }

            // Cambiar la dirección
            intColor += (intDireccion == 0) ? -1 : 1;

            if (intColor == 0 || intColor == intColorInit)
            {
                intDireccion = 1 - intDireccion;
            }

            // Cambiar el color
            intTime += 1;
            if (intTime >= intTimeStep)
            {
                if (intTime <= intTimeStepMax)
                {
                    intDireccion = 1;
                    intColor = 0;
                }
                else
                {
                    intTime = 0;
                }
            }

            this.BackColor = System.Drawing.Color.FromArgb(intColor, intColor, intColor);

        }


        private void cuadro_Tick(object sender, System.EventArgs e)
        {
            intMovSpeed = GenerarEnteroAleatorio(1, 3);
            
            // Mover el recueadro
            if (this.imgCuadro.Width + this.imgCuadro.Left + intBoxDx > this.Width) { intBoxDx = -1 * intMovSpeed; } else if (this.imgCuadro.Left + intBoxDx < 0) { intBoxDx = 1 * intMovSpeed; }
            if (this.imgCuadro.Height + this.imgCuadro.Top + intBoxDy > this.Height) { intBoxDy = -1 * intMovSpeed; } else if (this.imgCuadro.Top + intBoxDy < 0) { intBoxDy = 1 * intMovSpeed; }

            this.imgCuadro.Left += intBoxDx;
            this.imgCuadro.Top += intBoxDy;

            // mover el logo
            if (this.imgLogo.Width + this.imgLogo.Left + intLogoDx > this.Width) { intLogoDx = -1 * intMovSpeed; } else if (this.imgLogo.Left + intLogoDx < 0) { intLogoDx = 1 * intMovSpeed; }
            if (this.imgLogo.Height + this.imgLogo.Top + intLogoDy > this.Height) { intLogoDy = -1 * intMovSpeed; } else if (this.imgLogo.Top + intLogoDy < 0) { intLogoDy = 1 *intMovSpeed; }

            this.imgLogo.Left += intLogoDx;
            this.imgLogo.Top += intLogoDy;            
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }

                // Update current mouse location
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }
    }
}
