using FontAwesome.Sharp;
using System;
using System.Data;
using System.Data.SQLite;
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

        SqliteBaglantisi bgl = new SqliteBaglantisi();
        string tarih = DateTime.Now.ToString("dd/MM/yyyy");
        public string ad;

        void Listele()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteDataAdapter cmd = new SQLiteDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From Envanter_Listesi Where Durum = 'A' and KULLANICI_ADI = '" + ad + "'", c))
                {
                        DataTable dt = new DataTable();
                        cmd.Fill(dt);
                        dataGridView1.DataSource = dt;
                }
            }

            //DataTable dt = new DataTable();
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select ID, STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI, STZ_A5, STZ_E10, STZ_E15, STZ_E20, Tarih, Durum From Envanter_Listesi Where Durum = 'A' and KULLANICI_ADI = '" + ad + "'", bgl.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //bgl.baglanti().Close();
        }

        void EtütSayısı()
        {
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("Select COUNT(*) From Envanter_Listesi", c))
                {
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lblEtütSayısı.Text = dr[0].ToString();
                        int sayi1 = Convert.ToInt32(lblEtütSayısı.Text);
                        textBox1.Text = Convert.ToString(sayi1 + 1);
                    }
                }
            }

            //SQLiteCommand cmd = new SQLiteCommand("Select COUNT(*) From Envanter_Listesi", bgl.baglanti());
            //SQLiteDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    lblEtütSayısı.Text = dr[0].ToString();
            //    int sayi1 = Convert.ToInt32(lblEtütSayısı.Text);
            //    textBox1.Text = Convert.ToString(sayi1 + 1);
            //}
            //bgl.baglanti().Close();
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
                SQLiteDataAdapter da1 = new SQLiteDataAdapter("Select * from Stok_Listesi order by STOK_KODU asc", bgl.baglanti());
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                ctxtFullFinish.ValueMember = "STOK_KODU";
                ctxtFullFinish.DataSource = dt1;

                SQLiteDataAdapter da2 = new SQLiteDataAdapter("Select * from Operasyon_Listesi order by OPKODU asc", bgl.baglanti());
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ctxtOperasyon.ValueMember = "OPKODU";
                ctxtOperasyon.DataSource = dt2;


                SQLiteDataAdapter da3 = new SQLiteDataAdapter("Select * from Makina_Listesi order by DEMIR_KODU asc", bgl.baglanti());
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                ctxtTezgah.ValueMember = "DEMIR_KODU";
                ctxtTezgah.DataSource = dt3;


                SQLiteDataAdapter da4 = new SQLiteDataAdapter("Select PERSONEL_ADI from Personel_Listesi where DURUM = 'A' order by PERSONEL_ADI asc", bgl.baglanti());
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
            using (SQLiteConnection c = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version = 3;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("insert into Envanter_Listesi (STOK_KODU, OPKODU, DEMIR_KODU, PERSONEL_ADI, KULLANICI_ADI,	STZ_A5,	STZ_E10, STZ_E15, STZ_E20, Tarih, Durum, OPISIM) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@P12)", c))
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
                    cmd.Parameters.AddWithValue("@p1", ctxtFullFinish.Text);
                    cmd.Parameters.AddWithValue("@p2", ctxtOperasyon.Text);
                    cmd.Parameters.AddWithValue("@p3", ctxtTezgah.Text);
                    cmd.Parameters.AddWithValue("@p4", ctxtAd.Text);
                    cmd.Parameters.AddWithValue("@p5", lblAd.Text);
                    cmd.Parameters.AddWithValue("@p6", standartzaman5);
                    cmd.Parameters.AddWithValue("@p7", standartzaman10);
                    cmd.Parameters.AddWithValue("@p8", standartzaman15);
                    cmd.Parameters.AddWithValue("@p9", standartzaman20);
                    cmd.Parameters.AddWithValue("@p10", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p11", ctxtDurum.Text);
                    #region opisim
                    if (ctxtOperasyon.Text == "OP010")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BOY TAMAMLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP015")
                    {
                        cmd.Parameters.AddWithValue("@p12", "LAZER MARKALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP020")
                    {
                        cmd.Parameters.AddWithValue("@p12", "UÇ ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP030")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC HAZIRLIK");
                    }
                    else if (ctxtOperasyon.Text == "OP033")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ORTA DALIS");
                    }
                    else if (ctxtOperasyon.Text == "OP040")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP040-MN")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL ANA YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP040-NC")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC ANA YATAK TORNALAMA(GCF02)");
                    }
                    else if (ctxtOperasyon.Text == "OP040-NC-1")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC ANA YATAK TORNALAMA-1");
                    }
                    else if (ctxtOperasyon.Text == "OP040-NC-2")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC ANA YATAK TORNALMA-2");
                    }
                    else if (ctxtOperasyon.Text == "OP040-SW")
                    {
                        cmd.Parameters.AddWithValue("@p12", "SWITCH ANA YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP044")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA FINISH TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP050")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP050-MN")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL KOL YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP050-NC")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC KOL YATAK  TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP050-NC-1")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC KOL TORNALAMA-1");
                    }
                    else if (ctxtOperasyon.Text == "OP050-NC-2")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC KOL TORNALAMA-2");
                    }
                    else if (ctxtOperasyon.Text == "OP050-SW")
                    {
                        cmd.Parameters.AddWithValue("@p12", "SWITCH KOL YATAK TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP054")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL FINISH TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP055")
                    {
                        cmd.Parameters.AddWithValue("@p12", "FIRINLAMA- 580 °C 1 SAAT");
                    }
                    else if (ctxtOperasyon.Text == "OP060")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK TEMIZ ALMA");
                    }
                    else if (ctxtOperasyon.Text == "OP070")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN TEMIZ ALMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+HAVSA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+KOL+TAPA+YAG DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+KOL+TAPA+YAG+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP73")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI+TAPA DELIGI+YAG DELIGI+HAVSA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI+YAG DELIGI+HAVSA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+KOL DELIGI+VOLAN VIDA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+VOLAN VIDA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG DELIGI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP074")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA + KOL DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP072")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073+OP0180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA YERI+YAG DELIGI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP073")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIKLERI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP0180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIGI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP074+OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+KOL DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK UCU VIDA YERI ISLEME+YAG DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP074")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL DELIGI DELME+HAVSA");
                    }
                    else if (ctxtOperasyon.Text == "OP075")
                    {
                        cmd.Parameters.AddWithValue("@p12", "OKUYUCU DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP075+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "OKUYUCU DELIGI + VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP076")
                    {
                        cmd.Parameters.AddWithValue("@p12", "OKUYUCU YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP076+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "OKUYUCU YERI + KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP077")
                    {
                        cmd.Parameters.AddWithValue("@p12", "PIM DELIGI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP078")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIKLERINE HAVSA AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP079")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN FATURA SALGI ALMA");
                    }
                    else if (ctxtOperasyon.Text == "OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK UCU VIDA YERLERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP085+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK UCU VIDA YERLERI + KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP086")
                    {
                        cmd.Parameters.AddWithValue("@p12", "POMPA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP090+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALTA YERI + KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP091")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALTA YERI DELIK ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP095")
                    {
                        cmd.Parameters.AddWithValue("@p12", "AGIRLIK ALT YÜZEY ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP096")
                    {
                        cmd.Parameters.AddWithValue("@p12", "AGIRLIK DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP097")
                    {
                        cmd.Parameters.AddWithValue("@p12", "OP010+OP020");
                    }
                    else if (ctxtOperasyon.Text == "OP010+OP020")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BOY TAMAMLAMA + ÜÇ ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP100")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL SALMASTRA KANALI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP105")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL YATAK KABA TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP105+OP160")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL YATAK KABA + FINISH TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP110")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA YATAK KABA TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP110+OP150")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA YATAK KABA + VOLAN TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP110+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA YATAK KABA + FINISH TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP130")
                    {
                        cmd.Parameters.AddWithValue("@p12", "INDIKSIYONLA SERTLIK VERME");
                    }
                    else if (ctxtOperasyon.Text == "OP135")
                    {
                        cmd.Parameters.AddWithValue("@p12", "INDIKSIYONDAN SONRA NORMALLESTIRME");
                    }
                    else if (ctxtOperasyon.Text == "OP140")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP140+OP150")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK + VOLAN TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP140+OP150+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK+VOLAN+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP140+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP140+OP150+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK+VOLAN+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP140+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP141")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK 2. KADEME TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP150")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLANT TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP150+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP150+OP170-1")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL KABA VOLAN+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP150+OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN+ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP155")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KEÇE YERI TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP160")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP160-1")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL KABA KOL TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP160-MN")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL  KOL YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP160-NC")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NC KOL YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP170")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP170-1")
                    {
                        cmd.Parameters.AddWithValue("@p12", "MANUEL KABA ANA YATAK TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP171")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN YÜZEYI TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP172")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK ALIN TASLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP175")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALANSÖR DISLI YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP180+OP086")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK KAMA YERI AÇMA+POMPA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP180-CNC")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP181")
                    {
                        cmd.Parameters.AddWithValue("@p12", "AGIRLIK MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP182")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALTA TORNALAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP185")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK ANAHTAR AGZI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP186")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK KONIK AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP190")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALANS ALMA");
                    }
                    else if (ctxtOperasyon.Text == "OP191")
                    {
                        cmd.Parameters.AddWithValue("@p12", "DEGIRMENCI BALANS");
                    }
                    else if (ctxtOperasyon.Text == "OP195")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL ROLLING");
                    }
                    else if (ctxtOperasyon.Text == "OP196")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA ROLLING");
                    }
                    else if (ctxtOperasyon.Text == "OP200")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YÜZEY PÜRÜZ TEMIZLEME / HAVSA AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP210")
                    {
                        cmd.Parameters.AddWithValue("@p12", "EGIKLIK KONTROL");
                    }
                    else if (ctxtOperasyon.Text == "OP220")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALANS KONTROL");
                    }
                    else if (ctxtOperasyon.Text == "OP230")
                    {
                        cmd.Parameters.AddWithValue("@p12", "POLISAJ ILE ÖLÇÜ TAMLASTIRMA");
                    }
                    else if (ctxtOperasyon.Text == "OP235")
                    {
                        cmd.Parameters.AddWithValue("@p12", "NITRASYON");
                    }
                    else if (ctxtOperasyon.Text == "OP240")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ÇATLAK KONTROL");
                    }
                    else if (ctxtOperasyon.Text == "OP245")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KALITE EGIKLIK KONTROL");
                    }
                    else if (ctxtOperasyon.Text == "OP250")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAGA DIS AÇMA  (AZDIRMA)");
                    }
                    else if (ctxtOperasyon.Text == "OP260")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAGLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP270")
                    {
                        cmd.Parameters.AddWithValue("@p12", "SON KONTROL");
                    }
                    else if (ctxtOperasyon.Text == "OP273")
                    {
                        cmd.Parameters.AddWithValue("@p12", "PIM MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP274")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KAMA MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP275")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP276")
                    {
                        cmd.Parameters.AddWithValue("@p12", "DISLI MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP277")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KEÇE MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP278")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK APARATI MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP279")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN APARAT MONTAJI");
                    }
                    else if (ctxtOperasyon.Text == "OP280")
                    {
                        cmd.Parameters.AddWithValue("@p12", "AMBALAJLAMA");
                    }
                    else if (ctxtOperasyon.Text == "OP290")
                    {
                        cmd.Parameters.AddWithValue("@p12", "SEVKIYAT");
                    }
                    else if (ctxtOperasyon.Text == "OP300")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ARA OPERASYON");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP073+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+KOL+TAPA+YAG+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+TAPA+KOL+KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+TAPA+KOL+VOLAN VIDA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP072+OP074+OP090+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+TAPA+KOL+BALTA YERI+KASNAK KAMA YERI");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI+YAG DELIGI+HAVSA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+VOLAN VIDA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP71+OP073+OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP073+OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+YAG+KASNAK VIDA DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP074")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA + KOL DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA+KOL+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+KASNAK UCU VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP085+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+KASNAK UCU VIDA YERI+BALTA YERI");
                    }
                    else if (ctxtOperasyon.Text == "OP071+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "ANA DELIGI DELME+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA DELIGI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA + YAG DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA YERI+YAG DELIGI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073+OP074")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA+YAG+KOL DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073+OP074+OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA+YAG+KOL+KASNAK UCU VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP073+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA + YAG + VOLAN DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP074+OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA+KOL DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP072+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "TAPA DELIGI DELME + VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIGI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL+YAN+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP074+OP090+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG+TAPA DELIGI+BALTA YERI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIGI DELME+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP080+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIGI+VOLAN VIDA YERI+KAMA AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "YAG DELIGI+VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP073+OP085")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK UCU VIDA YERI ISLEME+YAG DELIGI DELME");
                    }
                    else if (ctxtOperasyon.Text == "OP074+OP080")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL DELIGI+VOLAN VIDA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP074+OP090+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KOL DELIGI+BALTA YERI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP080+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN NIDA YERI ISLEME + KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP080+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "VOLAN VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP085+OP180")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK UCU VIDA YERI+KASNAK KAMA YERI AÇMA");
                    }
                    else if (ctxtOperasyon.Text == "OP085+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP085+OP090")
                    {
                        cmd.Parameters.AddWithValue("@p12", "KASNAK VIDA YERI+BALTA YERI ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP090+OP091")
                    {
                        cmd.Parameters.AddWithValue("@p12", "BALTA YERI DELME + DELIK ISLEME");
                    }
                    else if (ctxtOperasyon.Text == "OP095+OP096")
                    {
                        cmd.Parameters.AddWithValue("@p12", "AGIRLIK DELME + AGIRLIK ISLEME");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@p12", "BOŞ");
                    }
                    #endregion //opisim
                    cmd.ExecuteNonQuery();
                    _BasarıEkran.Show();
                    Temizle();
                    EtütSayısı();
                    Listele();
                }
            }
        }

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
                        SQLiteCommand cmd = new SQLiteCommand("Update Envanter_Listesi set Durum = 'P' where ID = @p1", bgl.baglanti());
                        cmd.Parameters.AddWithValue("@p1", _KullanıcıKayıtlar.txtID.Text);
                        cmd.ExecuteNonQuery();
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

        private void txt11_Click(object sender, EventArgs e)
        {
            txt11.Text = "";
        }

        private void txt12_Click(object sender, EventArgs e)
        {
            txt12.Text = "";
        }

        private void txt21_Click(object sender, EventArgs e)
        {
            txt21.Text = "";
        }

        private void txt22_Click(object sender, EventArgs e)
        {
            txt22.Text = "";
        }

        private void txt31_Click(object sender, EventArgs e)
        {
            txt31.Text = "";
        }

        private void txt32_Click(object sender, EventArgs e)
        {
            txt32.Text = "";
        }

        private void txt13_Click(object sender, EventArgs e)
        {
            txt13.Text = "";
        }

        private void txt14_Click(object sender, EventArgs e)
        {
            txt14.Text = "";
        }

        private void txt23_Click(object sender, EventArgs e)
        {
            txt23.Text = "";
        }

        private void txt24_Click(object sender, EventArgs e)
        {
            txt24.Text = "";
        }

        private void txt33_Click(object sender, EventArgs e)
        {
            txt33.Text = "";
        }

        private void txt34_Click(object sender, EventArgs e)
        {
            txt34.Text = "";
        }

        private void txt15_Click(object sender, EventArgs e)
        {
            txt15.Text = "";
        }

        private void txt16_Click(object sender, EventArgs e)
        {
            txt16.Text = "";
        }

        private void txt25_Click(object sender, EventArgs e)
        {
            txt25.Text = "";
        }

        private void txt26_Click(object sender, EventArgs e)
        {
            txt26.Text = "";
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
    }
}
