using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GEN_Planlama
{
    public partial class Frm_KullanıcıEtütler : Form
    {
        public Frm_KullanıcıEtütler()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();

        void Listele()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteDataAdapter cmd = new SQLiteDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From Envanter_Listesi where Durum = 'A' order by Tarih asc", c))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    cmd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //System.Data.DataTable dt = new System.Data.DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From Envanter_Listesi where Durum = 'A' order by Tarih asc", bgl.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //bgl.baglanti().Close();
        }

        void Listele2()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteDataAdapter cmd = new SQLiteDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From Envanter_Listesi where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' and OPKODU LIKE '%" + txtOpAd.Text + "%' order by OPKODU asc", c))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    cmd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //System.Data.DataTable dt = new System.Data.DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From Envanter_Listesi where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' and OPKODU LIKE '%" + txtOpAd.Text + "%' order by OPKODU asc", bgl.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //bgl.baglanti().Close();
        }

        private void Frm_KullanıcıEtütler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele2();
        }
    }
}
