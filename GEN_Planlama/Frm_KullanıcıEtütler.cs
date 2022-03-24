using Microsoft.Office.Interop.Excel;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace GEN_Planlama
{
    public partial class Frm_KullanıcıEtütler : Form
    {
        public Frm_KullanıcıEtütler()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();

        void Listele()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From [Envanter Listesi$] where Durum = 'A' order by Tarih asc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void Listele2()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih From [Envanter Listesi$] where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' and OPKODU LIKE '%" + txtOpAd.Text + "%' order by OPKODU asc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
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
