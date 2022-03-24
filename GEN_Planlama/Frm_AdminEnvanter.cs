using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GEN_Planlama
{
    public partial class Frm_AdminEnvanter : Form
    {
        public Frm_AdminEnvanter()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        bool durum = false;

        void EtütZaman()
        {
            OleDbCommand komut = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'ceyhun'", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblCeyhun.Text = dr[0].ToString();
            }

            OleDbCommand komut1 = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'baran'", bgl.baglanti());
            OleDbDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblBaran.Text = dr1[0].ToString();
            }

            OleDbCommand komut2 = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'esra'", bgl.baglanti());
            OleDbDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEsra.Text = dr2[0].ToString();
            }

            OleDbCommand komut3 = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'nihal'", bgl.baglanti());
            OleDbDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblNihal.Text = dr3[0].ToString();
            }

            OleDbCommand komut4 = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'yusuf'", bgl.baglanti());
            OleDbDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblYusuf.Text = dr4[0].ToString();
            }

            OleDbCommand komut5 = new OleDbCommand("Select Sum(STZ_A5) From [Envanter Listesi$] where Durum = 'A' and KULLANICI_ADI = 'saadet'", bgl.baglanti());
            OleDbDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblSaadet.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();
        }

        void EtütSayısı()
        {
            OleDbCommand komut = new OleDbCommand("Select COUNT(*) From [Envanter Listesi$] where Durum = 'A' ", bgl.baglanti());
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblEtütSayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        void Listele()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From [Envanter Listesi$] where Durum = 'A' order by Tarih desc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void Listele2()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From [Envanter Listesi$] where Durum = 'P' order by Tarih desc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void Listele3()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From [Envanter Listesi$] where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' and OPKODU LIKE '%" + txtOpAd.Text + "%' order by Tarih desc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void Frm_Envanter_Load(object sender, EventArgs e)
        {
            try
            {
                EtütZaman();
                Listele();
                EtütSayısı();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (durum == false)
                {
                    Listele2();
                    durum = true;
                }
                else if (durum == true)
                {
                    Listele();
                    durum = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand komut = new OleDbCommand("Update [Envanter Listesi$] set Durum = @p1 where ID = @p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", ctxtDurum.Text);
                komut.Parameters.AddWithValue("@p2", txtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                Temizle();
                EtütSayısı();
                EtütZaman();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        void Temizle()
        {
            txtID.Text = "";
            ctxtDurum.SelectedItem = null;
            txtGmAd.Text = "";
            txtOpAd.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                ctxtDurum.SelectedItem = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                Listele3();
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
    }
}
