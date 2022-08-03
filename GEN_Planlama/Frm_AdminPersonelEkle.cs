using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_AdminPersonelEkle : Form
    {
        public Frm_AdminPersonelEkle()
        {
            InitializeComponent();
        }

        SqliteBaglantisi bgl = new SqliteBaglantisi();

        void Sayı()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("Select COUNT(*) From Personel_Listesi", c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lblSayı.Text = rdr[0].ToString();
                            int sayi1 = Convert.ToInt32(lblSayı.Text);
                            txtID.Text = Convert.ToString(sayi1 + 1);
                        }
                    }
                }
            }

            //SQLiteCommand cmd = new SQLiteCommand("Select COUNT(*) From Personel_Listesi", bgl.baglanti());
            //SQLiteDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    lblSayı.Text = dr[0].ToString();
            //    int sayi1 = Convert.ToInt32(lblSayı.Text);
            //    txtID.Text = Convert.ToString(sayi1 + 1);
            //}
            //bgl.baglanti().Close();
        }

        void Temizle()
        {
            txtID.Text = "";
            txtKullanıcıAd.Text = "";
            ctxtDurum.Text = "";
        }

        void Listele()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteDataAdapter cmd = new SQLiteDataAdapter("Select * From Personel_Listesi", c))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    cmd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //System.Data.DataTable dt = new System.Data.DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select * From Personel_Listesi", bgl.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //bgl.baglanti().Close();
        }

        private void Frm_AdminPersonelEkle_Load(object sender, EventArgs e)
        {
            Sayı();
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtKullanıcıAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                ctxtDurum.SelectedItem = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("insert into Personel_Listesi(ID, PERSONEL_ADI, DURUM) values(@p1, @p2, @p3)", c))
                {
                    cmd.Parameters.AddWithValue("@p1", txtID.Text);
                    cmd.Parameters.AddWithValue("@p2", txtKullanıcıAd.Text);
                    cmd.Parameters.AddWithValue("@p3", ctxtDurum.Text);
                    cmd.ExecuteNonQuery();
                    Temizle();
                    Listele();
                    Sayı();
                }
            }

            //try
            //{
            //    SQLiteCommand cmd = new SQLiteCommand("insert into Personel_Listesi (ID, PERSONEL_ADI, DURUM) values (@p1, @p2, @p3)", bgl.baglanti());
            //    cmd.Parameters.AddWithValue("@p1", txtID.Text);
            //    cmd.Parameters.AddWithValue("@p2", txtKullanıcıAd.Text);
            //    cmd.Parameters.AddWithValue("@p3", ctxtDurum.Text);
            //    cmd.ExecuteNonQuery();
            //    bgl.baglanti().Close();
            //    Temizle();
            //    Listele();
            //    Sayı();
            //}
            //catch (Exception hata)
            //{
            //    MessageBox.Show(hata.ToString());
            //}
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("Update Personel_Listesi set PERSONEL_ADI = @p1, DURUM = @p2 where ID = @p3", c))
                {
                    cmd.Parameters.AddWithValue("@p1", txtKullanıcıAd.Text);
                    cmd.Parameters.AddWithValue("@p2", ctxtDurum.Text);
                    cmd.Parameters.AddWithValue("@p3", txtID.Text);
                    cmd.ExecuteNonQuery();
                    Listele();
                    Temizle();
                }
            }

            //try
            //{
            //    SQLiteCommand cmd = new SQLiteCommand("Update Personel_Listesi set PERSONEL_ADI = @p1, DURUM = @p2 where ID = @p3", bgl.baglanti());
            //    cmd.Parameters.AddWithValue("@p1", txtKullanıcıAd.Text);
            //    cmd.Parameters.AddWithValue("@p2", ctxtDurum.Text);
            //    cmd.Parameters.AddWithValue("@p3", txtID.Text);
            //    cmd.ExecuteNonQuery();
            //    bgl.baglanti().Close();
            //    Listele();
            //    Temizle();
            //}
            //catch (Exception hata)
            //{
            //    MessageBox.Show(hata.ToString());
            //}
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
            Frm_AdminEnvanter _AdminEnvanter = new Frm_AdminEnvanter();
            this.Hide();
            _AdminEnvanter.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
    }
}
