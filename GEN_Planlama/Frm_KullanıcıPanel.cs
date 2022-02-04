//Developer magnet Atombtw imza : atom
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GEN_Planlama
{
    public partial class Frm_KullanıcıPanel : Form
    {
        public Frm_KullanıcıPanel()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        Frm_KullanıcıKayıtlar _KullanıcıKayıtlar = new Frm_KullanıcıKayıtlar();
        public string ad;
        string tarih = DateTime.Now.ToString("dd/MM/yyyy");

        void EtütSayısı()
        {
            OleDbCommand komut = new OleDbCommand("Select COUNT(*) From [Envanter Listesi$]", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblEtütSayısı.Text = dr[0].ToString();
                int sayi1 = Convert.ToInt32(lblEtütSayısı.Text);
                textBox1.Text = Convert.ToString(sayi1 + 1);
            }
            bgl.baglanti().Close();
        }
        void Temizle()
        {
            ctxtAd.SelectedIndex = 0;
            ctxtDurum.SelectedIndex = 0;
            ctxtFullFinish.SelectedIndex = 0;
            ctxtOperasyon.SelectedIndex = 0;
            ctxtTezgah.SelectedIndex = 0;
            txt11.Text = "0";
            txt12.Text = "0";
            txt13.Text = "0";
            txt14.Text = "0";
            txt15.Text = "0";
            txt16.Text = "0";
            txt17.Text = "0";
            txt18.Text = "0";

            txt21.Text = "0";
            txt22.Text = "0";
            txt23.Text = "0";
            txt24.Text = "0";
            txt25.Text = "0";
            txt26.Text = "0";
            txt27.Text = "0";
            txt28.Text = "0";

            txt31.Text = "0";
            txt32.Text = "0";
            txt33.Text = "0";
            txt34.Text = "0";
            txt35.Text = "0";
            txt36.Text = "0";
            txt37.Text = "0";
            txt38.Text = "0";
        }

        private void Frm_KullanıcıPanel_Load(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox1.Text = tarih;

                EtütSayısı();
                
                lblAd.Text = ad;
                ctxtDurum.SelectedIndex = 0;

                txt11.Text = "0";
                txt12.Text = "0";
                txt13.Text = "0";
                txt14.Text = "0";
                txt15.Text = "0";
                txt16.Text = "0";
                txt17.Text = "0";
                txt18.Text = "0";

                txt21.Text = "0";
                txt22.Text = "0";
                txt23.Text = "0";
                txt24.Text = "0";
                txt25.Text = "0";
                txt26.Text = "0";
                txt27.Text = "0";
                txt28.Text = "0";

                txt31.Text = "0";
                txt32.Text = "0";
                txt33.Text = "0";
                txt34.Text = "0";
                txt35.Text = "0";
                txt36.Text = "0";
                txt37.Text = "0";
                txt38.Text = "0";

                OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from [Stok Listesi$] order by STOK_KODU asc", bgl.baglanti());
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                ctxtFullFinish.ValueMember = "STOK_KODU";
                ctxtFullFinish.DataSource = dt1;

                OleDbDataAdapter da2 = new OleDbDataAdapter("Select * from [Operasyon Listesi$] order by OPKODU asc", bgl.baglanti());
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ctxtOperasyon.ValueMember = "OPKODU";
                ctxtOperasyon.DataSource = dt2;


                OleDbDataAdapter da3 = new OleDbDataAdapter("Select * from [Makina Listesi$] order by DEMIR_KODU asc", bgl.baglanti());
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ctxtTezgah.ValueMember = "DEMIR_KODU";
                ctxtTezgah.DataSource = dt3;


                OleDbDataAdapter da4 = new OleDbDataAdapter("Select * from [Personel Listesi$] order by PERSONEL_ADI asc", bgl.baglanti());
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                ctxtAd.ValueMember = "PERSONEL_ADI";
                ctxtAd.DataSource = dt4;
                bgl.baglanti().Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

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
            try
            {
                Frm_KullaniciGiris _KullaniciGiris = new Frm_KullaniciGiris();
                _KullaniciGiris.Show();
                this.Hide();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Frm_BasarıEkran _BasarıEkran = new Frm_BasarıEkran();
            try
            {

                    double toplamdakika = Convert.ToInt32(txt11.Text) + Convert.ToInt32(txt21.Text) + Convert.ToInt32(txt31.Text) + Convert.ToInt32(txt13.Text) + Convert.ToInt32(txt23.Text) + Convert.ToInt32(txt33.Text) + Convert.ToInt32(txt15.Text) + Convert.ToInt32(txt25.Text) + Convert.ToInt32(txt35.Text) + Convert.ToInt32(txt17.Text) + Convert.ToInt32(txt27.Text) + Convert.ToInt32(txt37.Text);
                    double toplamsaniye = Convert.ToInt32(txt12.Text) + Convert.ToInt32(txt22.Text) + Convert.ToInt32(txt32.Text) + Convert.ToInt32(txt14.Text) + Convert.ToInt32(txt24.Text) + Convert.ToInt32(txt34.Text) + Convert.ToInt32(txt16.Text) + Convert.ToInt32(txt26.Text) + Convert.ToInt32(txt36.Text) + Convert.ToInt32(txt18.Text) + Convert.ToInt32(txt28.Text) + Convert.ToInt32(txt38.Text);
                    double geneltoplam = toplamdakika * 60 + toplamsaniye;
                    double ortalama = geneltoplam / 3;
                    
                    //%5
                    double tolerans5 = ortalama * 5 / 100;
                    double saniyestandart5 = ortalama + tolerans5;
                    int standartzamandakika5 = Convert.ToInt32(saniyestandart5) / 60;
                    int standartsaniye5 = Convert.ToInt32(saniyestandart5) % 60;
                    string standartzaman5 = standartzamandakika5 + "," + standartsaniye5;

                    //%10
                    double tolerans10 = ortalama * 10 / 100;
                    double saniyestandart10 = ortalama - tolerans10;
                    int standartzamandakika10 = Convert.ToInt32(saniyestandart10) / 60;
                    int standartsaniye10 = Convert.ToInt32(saniyestandart10) % 60;
                    string standartzaman10 = standartzamandakika10 + "," + standartsaniye10;

                    //%15
                    double tolerans15 = ortalama * 15 / 100;
                    double saniyestandart15 = ortalama - tolerans15;
                    int standartzamandakika15 = Convert.ToInt32(saniyestandart15) / 60;
                    int standartsaniye15 = Convert.ToInt32(saniyestandart15) % 60;
                    string standartzaman15 = standartzamandakika15 + "," + standartsaniye15;

                    //%20
                    double tolerans20 = ortalama * 20 / 100;
                    double saniyestandart20 = ortalama - tolerans20;
                    int standartzamandakika20 = Convert.ToInt32(saniyestandart20) / 60;
                    int standartsaniye20 = Convert.ToInt32(saniyestandart20) % 60;
                    string standartzaman20 = standartzamandakika20 + "," + standartsaniye20;

                    OleDbCommand komut = new OleDbCommand("insert into [Envanter Listesi$] (ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI,	StandartZaman5,	StandartZaman10, StandartZaman15, StandartZaman20, Tarih, Durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", ctxtFullFinish.SelectedValue);
                    komut.Parameters.AddWithValue("@p3", ctxtOperasyon.SelectedValue);
                    komut.Parameters.AddWithValue("@p4", ctxtTezgah.SelectedValue);
                    komut.Parameters.AddWithValue("@p5", ctxtAd.SelectedValue);
                    komut.Parameters.AddWithValue("@p6", lblAd.Text);
                    komut.Parameters.AddWithValue("@p7", standartzaman5);
                    komut.Parameters.AddWithValue("@p8", standartzaman10);
                    komut.Parameters.AddWithValue("@p9", standartzaman15);
                    komut.Parameters.AddWithValue("@p10", standartzaman20);
                    komut.Parameters.AddWithValue("@p11", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@p12", ctxtDurum.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    _BasarıEkran.Show();
                    Temizle();
                EtütSayısı();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void txt11_Click(object sender, EventArgs e)
        {
            txt11.Text = "";
        }

        private void txt12_Click(object sender, EventArgs e)
        {
            txt12.Text = "";
        }

        private void txt13_Click(object sender, EventArgs e)
        {
            txt13.Text = "";
        }

        private void txt14_Click(object sender, EventArgs e)
        {
            txt14.Text = "";
        }

        private void txt15_Click(object sender, EventArgs e)
        {
            txt15.Text = "";
        }

        private void txt16_Click(object sender, EventArgs e)
        {
            txt16.Text = "";
        }

        private void txt21_Click(object sender, EventArgs e)
        {
            txt21.Text = "";
        }

        private void txt22_Click(object sender, EventArgs e)
        {
            txt22.Text = "";
        }

        private void txt23_Click(object sender, EventArgs e)
        {
            txt23.Text = "";
        }

        private void txt24_Click(object sender, EventArgs e)
        {
            txt24.Text = "";
        }

        private void txt25_Click(object sender, EventArgs e)
        {
            txt25.Text = "";
        }

        private void txt26_Click(object sender, EventArgs e)
        {
            txt26.Text = "";
        }

        private void txt31_Click(object sender, EventArgs e)
        {
            txt31.Text = "";
        }

        private void txt32_Click(object sender, EventArgs e)
        {
            txt32.Text = "";
        }

        private void txt33_Click(object sender, EventArgs e)
        {
            txt33.Text = "";
        }

        private void txt34_Click(object sender, EventArgs e)
        {
            txt34.Text = "";
        }

        private void txt35_Click(object sender, EventArgs e)
        {
            txt35.Text = "";
        }

        private void txt36_Click(object sender, EventArgs e)
        {
            txt36.Text = "";
        }

        private void txt17_Click(object sender, EventArgs e)
        {
            txt17.Text = "";
        }

        private void txt18_Click(object sender, EventArgs e)
        {
            txt18.Text = "";
        }

        private void txt27_Click(object sender, EventArgs e)
        {
            txt27.Text = "";
        }

        private void txt28_Click(object sender, EventArgs e)
        {
            txt28.Text = "";
        }

        private void txt37_Click(object sender, EventArgs e)
        {
            txt37.Text = "";
        }

        private void txt38_Click(object sender, EventArgs e)
        {
            txt38.Text = "";
        }

        private void btnKayıtlar_Click(object sender, EventArgs e)
        {
            _KullanıcıKayıtlar.ad = lblAd.Text;
            _KullanıcıKayıtlar.Show();
        }
    }
}