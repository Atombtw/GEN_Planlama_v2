using System;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GEN_Planlama
{
    public partial class Frm_AdminMain : Form
    {
        SqliteBaglantisi bgl = new SqliteBaglantisi();

        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildFrom;

        public Frm_AdminMain()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisibleButton();

                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                ıconCurrentChildForm.IconChar = currentBtn.IconChar;
                ıconCurrentChildForm.IconColor = color;
            }
        }

        private void DisibleButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildFrom != null)
            {
                //Open only form
                currentChildFrom.Close();
            }
            currentChildFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void ıconButtonDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Frm_AdminEnvanter());
        }

        private void ıconButtonOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Frm_AdminKullaniciEkle());
        }

        private void ıconButtonProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Frm_AdminPersonelEkle()) ;
        }

        private void ıconButtonCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Frm_AdminSorumlu());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildFrom != null)
            {
                //Open only form
                currentChildFrom.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisibleButton();
            leftBorderBtn.Visible = false;
            ıconCurrentChildForm.IconChar = IconChar.Home;
            ıconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconExit_MouseHover(object sender, EventArgs e)
        {
            ıconExit.BackColor = Color.Red;
        }

        private void ıconExit_MouseLeave(object sender, EventArgs e)
        {
            ıconExit.BackColor = Color.Transparent;
        }

        private void ıconExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_KullaniciGiris _KullaniciGiris = new Frm_KullaniciGiris();
            _KullaniciGiris.Show();
        }

        private void ıconPictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void ıconPictureBox2_MouseHover(object sender, EventArgs e)
        {
            ıconPictureBox2.BackColor = Color.Red;
        }

        private void ıconPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            ıconPictureBox2.BackColor = Color.Transparent;
        }

        private void ıconPictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ıconPictureBox3_MouseHover(object sender, EventArgs e)
        {
            ıconPictureBox3.BackColor = Color.Red;
        }

        private void ıconPictureBox3_MouseLeave(object sender, EventArgs e)
        {
            ıconPictureBox3.BackColor = Color.Transparent;
        }
    }
}
