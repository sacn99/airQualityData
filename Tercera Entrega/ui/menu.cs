using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ui
{
    public partial class menu : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMesssage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
            {
                menuVertical.Width = 50;
            }
            else
            {
                menuVertical.Width = 250;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconRestore.Visible = true;
            iconMaximize.Visible = false;
        }

        private void iconRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconMaximize.Visible = true;
            iconRestore.Visible = false;
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMesssage(this.Handle, 0x112, 0xf012, 0);
        }

        private void openFormInPanel(object FormChildren)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fc = FormChildren as Form;
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fc);
            this.panelContenedor.Tag = fc;
            fc.Show();
        }

        private void buttonFormDataTable_Click(object sender, EventArgs e)
        {
            openFormInPanel(new FormSODATable());
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            openFormInPanel(new FormMaps());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFormInPanel(new FormReports());
        }
    }
}
