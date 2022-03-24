using FontAwesome.Sharp;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GEN_Planlama
{
    public partial class Frm_KullaniciMain : Form
    {

        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildFrom;

        public Frm_KullaniciMain()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        OleDbBaglantisi bgl = new OleDbBaglantisi();
        string tarih = DateTime.Now.ToString("dd/MM/yyyy");
        public string ad;

        void Listele()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From [Envanter Listesi$] Where Durum = 'A' and KULLANICI_ADI = '" + ad + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

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

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisibleButton();

                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                ıconCurrentChildForm.IconChar = currentBtn.IconChar;
                ıconCurrentChildForm.IconColor = color;
            }
        }

        private void DisibleButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildFrom != null)
            {
                //Open only form
                currentChildFrom.Close();
            }
            currentChildFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop2.Controls.Add(childForm);
            panelDesktop2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildFrom != null)
            {
                //Open only form
                currentChildFrom.Close();
            }
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            label14.Visible = false;
            Reset();
        }

        private void Reset()
        {
            DisibleButton();
            leftBorderBtn.Visible = false;
            ıconCurrentChildForm.IconChar = IconChar.Home;
            ıconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconButtonDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            if (currentChildFrom != null)
            {
                currentChildFrom.Close();
            }
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            label14.Visible = true;
            lblTitleChildForm.Text = "Envanter";

            //ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new Frm_KullanıcıPanel());
        }

        private void ıconExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_KullaniciGiris _KullaniciGiris = new Frm_KullaniciGiris();
            _KullaniciGiris.Show();
        }

        private void ıconExit_MouseHover(object sender, EventArgs e)
        {
            ıconExit.BackColor = Color.Red;
        }

        private void ıconExit_MouseLeave(object sender, EventArgs e)
        {
            ıconExit.BackColor = Color.Transparent;
        }

        private void ıconPictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void ıconPictureBox2_MouseHover(object sender, EventArgs e)
        {
            ıconPictureBox2.BackColor = Color.Red;
        }

        private void ıconPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            ıconPictureBox2.BackColor = Color.Transparent;
        }

        private void ıconPictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ıconPictureBox3_MouseHover(object sender, EventArgs e)
        {
            ıconPictureBox3.BackColor = Color.Red;
        }

        private void ıconPictureBox3_MouseLeave(object sender, EventArgs e)
        {
            ıconPictureBox3.BackColor = Color.Transparent;
        }

        private void Frm_KullaniciMain_Load(object sender, EventArgs e)
        {
            try
            {
                Listele();
                EtütSayısı();

                #region text içerikleri
                ctxtDurum.SelectedIndex = 0;
                maskedTextBox1.Text = tarih;
                lblAd.Text = ad;
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
                #endregion

                #region comboboxlar
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


                OleDbDataAdapter da4 = new OleDbDataAdapter("Select PERSONEL_ADI from [Personel Listesi$] where DURUM = 'A' order by PERSONEL_ADI asc", bgl.baglanti());
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                ctxtAd.ValueMember = "PERSONEL_ADI";
                ctxtAd.DataSource = dt4;
                bgl.baglanti().Close();
                #endregion
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
                #region stz hesaplama
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
                #endregion

                OleDbCommand komut = new OleDbCommand("insert into [Envanter Listesi$] (ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI,	STZ_A5,	STZ_E10, STZ_E15, STZ_E20, Tarih, Durum, OPISIM) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@P13)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", ctxtFullFinish.Text);
                komut.Parameters.AddWithValue("@p3", ctxtOperasyon.Text);
                komut.Parameters.AddWithValue("@p4", ctxtTezgah.Text);
                komut.Parameters.AddWithValue("@p5", ctxtAd.Text);
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", standartzaman5);
                komut.Parameters.AddWithValue("@p8", standartzaman10);
                komut.Parameters.AddWithValue("@p9", standartzaman15);
                komut.Parameters.AddWithValue("@p10", standartzaman20);
                komut.Parameters.AddWithValue("@p11", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p12", ctxtDurum.Text);
                #region opisim
                if (ctxtOperasyon.Text == "OP010")
                {
                    komut.Parameters.AddWithValue("@p13", "BOY TAMAMLAMA");
                }
                else if (ctxtOperasyon.Text == "OP015")
                {
                    komut.Parameters.AddWithValue("@p13", "LAZER MARKALAMA");
                }
                else if (ctxtOperasyon.Text == "OP020")
                {
                    komut.Parameters.AddWithValue("@p13", "UÇ ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP030")
                {
                    komut.Parameters.AddWithValue("@p13", "NC HAZIRLIK");
                }
                else if (ctxtOperasyon.Text == "OP033")
                {
                    komut.Parameters.AddWithValue("@p13", "ORTA DALIS");
                }
                else if (ctxtOperasyon.Text == "OP040")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP040-MN")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL ANA YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP040-NC")
                {
                    komut.Parameters.AddWithValue("@p13", "NC ANA YATAK TORNALAMA(GCF02)");
                }
                else if (ctxtOperasyon.Text == "OP040-NC-1")
                {
                    komut.Parameters.AddWithValue("@p13", "NC ANA YATAK TORNALAMA-1");
                }
                else if (ctxtOperasyon.Text == "OP040-NC-2")
                {
                    komut.Parameters.AddWithValue("@p13", "NC ANA YATAK TORNALMA-2");
                }
                else if (ctxtOperasyon.Text == "OP040-SW")
                {
                    komut.Parameters.AddWithValue("@p13", "SWITCH ANA YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP044")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA FINISH TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP050")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP050-MN")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL KOL YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP050-NC")
                {
                    komut.Parameters.AddWithValue("@p13", "NC KOL YATAK  TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP050-NC-1")
                {
                    komut.Parameters.AddWithValue("@p13", "NC KOL TORNALAMA-1");
                }
                else if (ctxtOperasyon.Text == "OP050-NC-2")
                {
                    komut.Parameters.AddWithValue("@p13", "NC KOL TORNALAMA-2");
                }
                else if (ctxtOperasyon.Text == "OP050-SW")
                {
                    komut.Parameters.AddWithValue("@p13", "SWITCH KOL YATAK TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP054")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL FINISH TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP055")
                {
                    komut.Parameters.AddWithValue("@p13", "FIRINLAMA- 580 °C 1 SAAT");
                }
                else if (ctxtOperasyon.Text == "OP060")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK TEMIZ ALMA");
                }
                else if (ctxtOperasyon.Text == "OP070")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN TEMIZ ALMA");
                }
                else if (ctxtOperasyon.Text == "OP071")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+HAVSA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+KOL+TAPA+YAG DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+KOL+TAPA+YAG+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP73")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI+TAPA DELIGI+YAG DELIGI+HAVSA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI+YAG DELIGI+HAVSA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+KOL DELIGI+VOLAN VIDA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+VOLAN VIDA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG DELIGI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP074")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA + KOL DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP072")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073+OP0180")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA YERI+YAG DELIGI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP073")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIKLERI DELME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP0180")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIGI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP073+OP074+OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+KOL DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK UCU VIDA YERI ISLEME+YAG DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP074")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL DELIGI DELME+HAVSA");
                }
                else if (ctxtOperasyon.Text == "OP075")
                {
                    komut.Parameters.AddWithValue("@p13", "OKUYUCU DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP075+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "OKUYUCU DELIGI + VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP076")
                {
                    komut.Parameters.AddWithValue("@p13", "OKUYUCU YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP076+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "OKUYUCU YERI + KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP077")
                {
                    komut.Parameters.AddWithValue("@p13", "PIM DELIGI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP078")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIKLERINE HAVSA AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP079")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN FATURA SALGI ALMA");
                }
                else if (ctxtOperasyon.Text == "OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK UCU VIDA YERLERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP085+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK UCU VIDA YERLERI + KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP086")
                {
                    komut.Parameters.AddWithValue("@p13", "POMPA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP090+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "BALTA YERI + KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP091")
                {
                    komut.Parameters.AddWithValue("@p13", "BALTA YERI DELIK ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP095")
                {
                    komut.Parameters.AddWithValue("@p13", "AGIRLIK ALT YÜZEY ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP096")
                {
                    komut.Parameters.AddWithValue("@p13", "AGIRLIK DELME");
                }
                else if (ctxtOperasyon.Text == "OP097")
                {
                    komut.Parameters.AddWithValue("@p13", "OP010+OP020");
                }
                else if (ctxtOperasyon.Text == "OP010+OP020")
                {
                    komut.Parameters.AddWithValue("@p13", "BOY TAMAMLAMA + ÜÇ ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP100")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL SALMASTRA KANALI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP105")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL YATAK KABA TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP105+OP160")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL YATAK KABA + FINISH TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP110")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA YATAK KABA TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP110+OP150")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA YATAK KABA + VOLAN TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP110+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA YATAK KABA + FINISH TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP130")
                {
                    komut.Parameters.AddWithValue("@p13", "INDIKSIYONLA SERTLIK VERME");
                }
                else if (ctxtOperasyon.Text == "OP135")
                {
                    komut.Parameters.AddWithValue("@p13", "INDIKSIYONDAN SONRA NORMALLESTIRME");
                }
                else if (ctxtOperasyon.Text == "OP140")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP140+OP150")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK + VOLAN TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP140+OP150+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK+VOLAN+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP140+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP140+OP150+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK+VOLAN+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP140+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP141")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK 2. KADEME TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP150")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLANT TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP150+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP150+OP170-1")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL KABA VOLAN+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP150+OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN+ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP155")
                {
                    komut.Parameters.AddWithValue("@p13", "KEÇE YERI TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP160")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP160-1")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL KABA KOL TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP160-MN")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL  KOL YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP160-NC")
                {
                    komut.Parameters.AddWithValue("@p13", "NC KOL YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP170")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP170-1")
                {
                    komut.Parameters.AddWithValue("@p13", "MANUEL KABA ANA YATAK TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP171")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN YÜZEYI TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP172")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK ALIN TASLAMA");
                }
                else if (ctxtOperasyon.Text == "OP175")
                {
                    komut.Parameters.AddWithValue("@p13", "BALANSÖR DISLI YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP180+OP086")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK KAMA YERI AÇMA+POMPA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP180-CNC")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP181")
                {
                    komut.Parameters.AddWithValue("@p13", "AGIRLIK MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP182")
                {
                    komut.Parameters.AddWithValue("@p13", "BALTA TORNALAMA");
                }
                else if (ctxtOperasyon.Text == "OP185")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK ANAHTAR AGZI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP186")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK KONIK AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP190")
                {
                    komut.Parameters.AddWithValue("@p13", "BALANS ALMA");
                }
                else if (ctxtOperasyon.Text == "OP191")
                {
                    komut.Parameters.AddWithValue("@p13", "DEGIRMENCI BALANS");
                }
                else if (ctxtOperasyon.Text == "OP195")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL ROLLING");
                }
                else if (ctxtOperasyon.Text == "OP196")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA ROLLING");
                }
                else if (ctxtOperasyon.Text == "OP200")
                {
                    komut.Parameters.AddWithValue("@p13", "YÜZEY PÜRÜZ TEMIZLEME / HAVSA AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP210")
                {
                    komut.Parameters.AddWithValue("@p13", "EGIKLIK KONTROL");
                }
                else if (ctxtOperasyon.Text == "OP220")
                {
                    komut.Parameters.AddWithValue("@p13", "BALANS KONTROL");
                }
                else if (ctxtOperasyon.Text == "OP230")
                {
                    komut.Parameters.AddWithValue("@p13", "POLISAJ ILE ÖLÇÜ TAMLASTIRMA");
                }
                else if (ctxtOperasyon.Text == "OP235")
                {
                    komut.Parameters.AddWithValue("@p13", "NITRASYON");
                }
                else if (ctxtOperasyon.Text == "OP240")
                {
                    komut.Parameters.AddWithValue("@p13", "ÇATLAK KONTROL");
                }
                else if (ctxtOperasyon.Text == "OP245")
                {
                    komut.Parameters.AddWithValue("@p13", "KALITE EGIKLIK KONTROL");
                }
                else if (ctxtOperasyon.Text == "OP250")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAGA DIS AÇMA  (AZDIRMA)");
                }
                else if (ctxtOperasyon.Text == "OP260")
                {
                    komut.Parameters.AddWithValue("@p13", "YAGLAMA");
                }
                else if (ctxtOperasyon.Text == "OP270")
                {
                    komut.Parameters.AddWithValue("@p13", "SON KONTROL");
                }
                else if (ctxtOperasyon.Text == "OP273")
                {
                    komut.Parameters.AddWithValue("@p13", "PIM MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP274")
                {
                    komut.Parameters.AddWithValue("@p13", "KAMA MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP275")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP276")
                {
                    komut.Parameters.AddWithValue("@p13", "DISLI MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP277")
                {
                    komut.Parameters.AddWithValue("@p13", "KEÇE MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP278")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK APARATI MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP279")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN APARAT MONTAJI");
                }
                else if (ctxtOperasyon.Text == "OP280")
                {
                    komut.Parameters.AddWithValue("@p13", "AMBALAJLAMA");
                }
                else if (ctxtOperasyon.Text == "OP290")
                {
                    komut.Parameters.AddWithValue("@p13", "SEVKIYAT");
                }
                else if (ctxtOperasyon.Text == "OP300")
                {
                    komut.Parameters.AddWithValue("@p13", "ARA OPERASYON");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+KOL+TAPA+YAG+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+TAPA+KOL+KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+TAPA+KOL+VOLAN VIDA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP090+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+TAPA+KOL+BALTA YERI+KASNAK KAMA YERI");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI+YAG DELIGI+HAVSA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+VOLAN VIDA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP71+OP073+OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP073+OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+YAG+KASNAK VIDA DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP074")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA + KOL DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA+KOL+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+KASNAK UCU VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP071+OP085+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+KASNAK UCU VIDA YERI+BALTA YERI");
                }
                else if (ctxtOperasyon.Text == "OP071+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "ANA DELIGI DELME+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA DELIGI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA + YAG DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA YERI+YAG DELIGI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073+OP074")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA+YAG+KOL DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073+OP074+OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA+YAG+KOL+KASNAK UCU VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP073+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA + YAG + VOLAN DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP074+OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA+KOL DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP072+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "TAPA DELIGI DELME + VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIGI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP073+OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL+YAN+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP074+OP090+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG+TAPA DELIGI+BALTA YERI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP073+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIGI DELME+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP080+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIGI+VOLAN VIDA YERI+KAMA AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP073+OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "YAG DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP073+OP085")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK UCU VIDA YERI ISLEME+YAG DELIGI DELME");
                }
                else if (ctxtOperasyon.Text == "OP074+OP080")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL DELIGI+VOLAN VIDA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP074+OP090+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "KOL DELIGI+BALTA YERI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP080+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN NIDA YERI ISLEME + KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP080+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "VOLAN VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP085+OP180")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK UCU VIDA YERI+KASNAK KAMA YERI AÇMA");
                }
                else if (ctxtOperasyon.Text == "OP085+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP085+OP090")
                {
                    komut.Parameters.AddWithValue("@p13", "KASNAK VIDA YERI+BALTA YERI ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP090+OP091")
                {
                    komut.Parameters.AddWithValue("@p13", "BALTA YERI DELME + DELIK ISLEME");
                }
                else if (ctxtOperasyon.Text == "OP095+OP096")
                {
                    komut.Parameters.AddWithValue("@p13", "AGIRLIK DELME + AGIRLIK ISLEME");
                }
                else
                {
                    komut.Parameters.AddWithValue("@p13", "BOŞ");
                }
                #endregion //opisim
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                _BasarıEkran.Show();
                Temizle();
                EtütSayısı();
                Listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
        
        #region click event
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
        #endregion

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Frm_KullanıcıKayıtlar _KullanıcıKayıtlar = new Frm_KullanıcıKayıtlar())
            {
                _KullanıcıKayıtlar.lblAd.Text = ad;

                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                _KullanıcıKayıtlar.txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

                if (_KullanıcıKayıtlar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        OleDbCommand komut = new OleDbCommand("Update [Envanter Listesi$] set Durum = 'P' where ID = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", _KullanıcıKayıtlar.txtID.Text);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        Listele();
                        Temizle();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.ToString());
                    }
                }
            }
        }

        private void ıconButtonOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            label14.Visible = false;
            OpenChildForm(new Frm_KullanıcıEtütler());
        }

        private void ıconButtonProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            label14.Visible = false;
            OpenChildForm(new Frm_KullaniciExcelAktar());
        }
    }
}
