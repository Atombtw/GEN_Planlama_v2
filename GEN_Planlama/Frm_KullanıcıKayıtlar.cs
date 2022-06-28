using System;
using System.Drawing;
using System.Windows.Forms;

namespace GEN_Planlama
{
    public partial class Frm_KullanıcıKayıtlar : Form
    {
        public Frm_KullanıcıKayıtlar()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        void Temizle()
        {
            txtID.Text = "";
        }

        private void Frm_KullanıcıKayıtlar_Load(object sender, EventArgs e)
        {

        }
    }
}
