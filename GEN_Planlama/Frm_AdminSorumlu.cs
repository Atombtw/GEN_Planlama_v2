using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GEN_Planlama
{
    public partial class Frm_AdminSorumlu : Form
    {
        public Frm_AdminSorumlu()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();

        private void Frm_AdminSorumlu_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select KULLANICI_ADI,COUNT(*) as ADET From [Envanter Listesi$] Group by KULLANICI_ADI order by KULLANICI_ADI asc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
