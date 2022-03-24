using System;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace GEN_Planlama
{
    public partial class Frm_KullaniciExcelAktar : Form
    {
        public Frm_KullaniciExcelAktar()
        {
            InitializeComponent();
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();

        void Listele2()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select OPKODU as OP, OPISIM as Açıklama ,DEMIR_KODU as ROTA, STZ_A5 as STD_SÜRE From [Envanter Listesi$] where Durum = 'A' and STOK_KODU LIKE '%" + txtGmAd.Text + "%' order by OPKODU asc", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void Frm_ExcelAktar_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from [Stok Listesi$] order by STOK_KODU asc", bgl.baglanti());
            System.Data.DataTable dt1 = new System.Data.DataTable();
            da1.Fill(dt1);
            txtGmAd.ValueMember = "STOK_KODU";
            txtGmAd.DataSource = dt1;
            bgl.baglanti().Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                Listele2();
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
                string ad = txtGmAd.Text;

                int sutun = 1;
                int satir = 2;
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Workbooks.Add();
                ExcelApp.Visible = true;
                ExcelApp.Worksheets[1].Activate();
                Microsoft.Office.Interop.Excel.Range range;

                #region baslık
                ExcelApp.get_Range("a1", "d1").Merge(false);
                range = ExcelApp.get_Range("a1", "d1");
                range.EntireRow.Font.Bold = true;
                ExcelApp.Cells[1, 1].Font.Size = 12;
                ExcelApp.Cells[1, 1].ColumnWidth = 20;
                ExcelApp.Cells[1, 1].Font.Bold = true;
                ExcelApp.Cells[1, 1].Font.Color = System.Drawing.Color.Blue;
                ExcelApp.Cells[1, 1].Font.Name = "Arial Black";
                ExcelApp.get_Range("a1", "d1").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ExcelApp.Cells[1, 1] = ad + " OPERASYON TANIM KARTI";
                #endregion

                #region başlıklar
                ExcelApp.get_Range("a2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ExcelApp.get_Range("b2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ExcelApp.get_Range("c2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ExcelApp.get_Range("d2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ExcelApp.Cells[satir, sutun + j].Value = dataGridView1.Columns[j].HeaderText;
                    ExcelApp.Cells[satir, sutun + j].Font.Color = System.Drawing.Color.Blue;
                    ExcelApp.Cells[satir, sutun + j].Font.Size = 12;
                    ExcelApp.Cells[satir, sutun + j].ColumnWidth = 20;
                    ExcelApp.Cells[satir, sutun + j].Font.Bold = true;
                    ExcelApp.Cells[satir, sutun + j].Font.Name = "Arial Black";
                }
                satir++;
                #endregion

                #region başlık içerikleri
                int z = 0;
                int s = 3;
                Range alan2 = (Range)ExcelApp.Cells[1, 1];
                for (int i = 2; i < dataGridView1.Rows.Count + 1; i++)
                {
                    alan2.Cells[s, 1] = dataGridView1[0, z].Value;
                    alan2.Cells[s, 2] = dataGridView1[1, z].Value;
                    alan2.Cells[s, 3] = dataGridView1[2, z].Value;
                    alan2.Cells[s, 4] = dataGridView1[3, z].Value;
                    z++;
                    s++;
                }
                #endregion

                #region çerçeve
                range = ExcelApp.get_Range("a1", "a" + (z + 2) + "");
                Microsoft.Office.Interop.Excel.Borders cerceve = range.Borders;
                cerceve.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                cerceve.Weight = 2d;

                range = ExcelApp.get_Range("b1", "b" + (z + 2) + "");
                Microsoft.Office.Interop.Excel.Borders cerceve1 = range.Borders;
                cerceve1.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                cerceve1.Weight = 2d;

                range = ExcelApp.get_Range("c1", "c" + (z + 2) + "");
                Microsoft.Office.Interop.Excel.Borders cerceve2 = range.Borders;
                cerceve2.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                cerceve2.Weight = 2d;

                range = ExcelApp.get_Range("d1", "d" + (z + 2) + "");
                Microsoft.Office.Interop.Excel.Borders cerceve3 = range.Borders;
                cerceve3.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                cerceve3.Weight = 2d;
                #endregion
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
    }
}
