using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_KullaniciGiris : Form
    {
        public Frm_KullaniciGiris()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        Frm_KullanıcıPanel _KullanıcıPanel = new Frm_KullanıcıPanel();
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
            try
            {
                OleDbCommand komut = new OleDbCommand("Select * From [Kullanıcı Listesi$] where KULLANICI_ADI = @p1 and KULLANICI_SIFRESI = @p2 and DURUM = 'A'", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                OleDbDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    _KullanıcıPanel.ad = txtKullaniciAdi.Text;
                    _KullanıcıPanel.Show();
                    this.Hide();
                }
                else
                {
                    _HataEkran.Show();
                }
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                panel1.BackColor = Color.Red;
                label4.ForeColor = Color.White;
                label4.Visible = true;
                label4.Text = "Lütfen Bilgilerinizi Kontrol Ediniz!";
                _HataEkran.ShowDialog();
            }
        }
    }
}
