using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_AdminGiris : Form
    {
        public Frm_AdminGiris()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();
        Frm_AdminMain _AdminMain = new Frm_AdminMain();
        Frm_HataEkran _HataEkran = new Frm_HataEkran();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("Select * From Kullanıcı_Listesi Where KULLANICI_ADI = @p1 and KULLANICI_SIFRESI = @p2 and KULLANICI_ADMIN = 'T' and DURUM = 'A'", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    bgl.baglanti().Close();
                    _AdminMain.Show();
                    this.Hide();
                }
                else
                {
                    _HataEkran.ShowDialog();
                    panel1.BackColor = Color.Red;
                    label4.ForeColor = Color.White;
                    label4.Visible = true;
                    label4.Text = "Lütfen Bilgilerinizi Kontrol Ediniz!";
                    bgl.baglanti().Close();
                }
            }
            catch (Exception)
            {
                panel1.BackColor = Color.Red;
                label4.ForeColor = Color.White;
                label4.Visible = true;
                label4.Text = "Lütfen Bilgilerinizi Kontrol Ediniz!";
            }
        }

        private void btnCıkıs_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_KullaniciGiris _KullaniciGiris = new Frm_KullaniciGiris();
            _KullaniciGiris.Show();
            this.Hide();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gainsboro;
        }
    }
}
