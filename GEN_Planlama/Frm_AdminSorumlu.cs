using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GEN_Planlama
{
    public partial class Frm_AdminSorumlu : Form
    {
        public Frm_AdminSorumlu()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();

        private void Frm_AdminSorumlu_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteDataAdapter cmd = new SQLiteDataAdapter("Select KULLANICI_ADI,COUNT(*) as ADET From Envanter_Listesi where Durum = 'A' Group by KULLANICI_ADI order by KULLANICI_ADI asc", c))
                {
                    DataTable dt = new DataTable();
                    cmd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //DataTable dt = new DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select KULLANICI_ADI,COUNT(*) as ADET From Envanter_Listesi where Durum = 'A' Group by KULLANICI_ADI order by KULLANICI_ADI asc", bgl.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //bgl.baglanti().Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
