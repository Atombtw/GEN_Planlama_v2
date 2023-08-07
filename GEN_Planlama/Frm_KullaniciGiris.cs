using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_KullaniciGiris : Form
    {
        public Frm_KullaniciGiris()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();
        Frm_KullaniciMain _KullaniciMain = new Frm_KullaniciMain();
        Frm_HataEkran _HataEkran = new Frm_HataEkran();

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_AdminGiris _AdminGiris = new Frm_AdminGiris();
            _AdminGiris.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string uretim = "URETIM"; 
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("Select * From Kullanıcı_Listesi where KULLANICI_ADI = @p1 and KULLANICI_SIFRESI = @p2 and KULLANICI_DURUM = 'PLANLAMA' and DURUM = 'A'", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    _KullaniciMain.ad = txtKullaniciAdi.Text;
                    _KullaniciMain.Show();
                    this.Hide();
                }
                else if (uretim == "URETIM")
                {
                    SQLiteCommand cmd1 = new SQLiteCommand("Select * From Kullanıcı_Listesi where KULLANICI_ADI = @p1 and KULLANICI_SIFRESI = @p2 and KULLANICI_DURUM = 'URETIM' and DURUM = 'A'", bgl.baglanti());
                    cmd1.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                    cmd1.Parameters.AddWithValue("@p2", txtSifre.Text);
                    SQLiteDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        _KullaniciMain.Show();
                        this.Hide();
                    }
                }
                else
                {
                    _HataEkran.ShowDialog();
                    panel1.BackColor = Color.Red;
                    label4.ForeColor = Color.White;
                    label4.Visible = true;
                    label4.Text = "Lütfen Bilgilerinizi Kontrol Ediniz!";
                }
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                panel1.BackColor = Color.Red;
                label4.ForeColor = Color.White;
                label4.Visible = true;
                label4.Text = "Lütfen Bilgilerinizi Kontrol Ediniz!";
            }
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
