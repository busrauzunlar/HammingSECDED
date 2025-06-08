using System;
using System.Collections;
using System.Windows.Forms;
using Busra_Uzunlar_Mimari_Proje.Classes;  // HammingCoder'ý kullanmak için


namespace Busra_Uzunlar_Mimari_Proje
{
    public partial class anaMenu : Form
    {
        hammingCoder coder = new hammingCoder();
        memory memory = new memory();
        int hataBitSayisi = 0;
        int hataBitNo = -1;


        public anaMenu()
        {
            InitializeComponent();/*
            gBox_16bit.Enabled = false;
            gBox_8bit.Enabled = false;
            gBox_32bit.Enabled = false;
            rbtn_16bit.Checked = false;
            rbtn_8bit.Checked = false;
            rbtn_32bit.Checked = false;*/

            // Ortak Click event handler'ý baðla
            button_Event_Baglama();
        }

        private bool IsBinary(string input)
        {
            foreach (char c in input)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }
        private void rbtn_16bit_CheckedChanged(object sender, EventArgs e)
        {
            gBox_16bit.Enabled = true;
            gBox_8bit.Enabled = false;
            gBox_32bit.Enabled = false;
            txt_8bit.Clear();
            txt_32bit.Clear();
            txt_cikti.Text = "";
            lbl_hatali.Text = "";
            lbl_sonuc.Text = "";
            lbl_orijinalveri.Text = "";
            buttonTemizle();
        }

        private void rbtn_8bit_CheckedChanged(object sender, EventArgs e)
        {
            gBox_16bit.Enabled = false;
            gBox_8bit.Enabled = true;
            gBox_32bit.Enabled = false;
            txt_16bit.Clear();
            txt_32bit.Clear();
            txt_cikti.Text = "";
            lbl_hatali.Text = "";
            lbl_sonuc.Text = "";
            lbl_orijinalveri.Text = "";
            buttonTemizle();
        }

        private void rbtn_32bit_CheckedChanged(object sender, EventArgs e)
        {
            gBox_16bit.Enabled = false;
            gBox_8bit.Enabled = false;
            gBox_32bit.Enabled = true;
            txt_8bit.Clear();
            txt_16bit.Clear();
            txt_cikti.Text = "";
            lbl_hatali.Text = "";
            lbl_sonuc.Text = "";
            lbl_orijinalveri.Text = "";
            buttonTemizle();
        }
        private void btn_getir_Click(object sender, EventArgs e)
        {
            string veri = "";

            if (gBox_32bit.Enabled == true)
            {
                veri = txt_32bit.Text.Trim();
                veri = txt_32bit.Text.Replace(" ", "");
            }

            else if (gBox_8bit.Enabled == true)
            {
                veri = txt_8bit.Text.Trim();
                veri = txt_8bit.Text.Replace(" ", "");
            }

            else if (gBox_16bit.Enabled == true)
            {
                veri = txt_16bit.Text.Trim();
                veri = txt_16bit.Text.Replace(" ", "");
            }

            // 1. Girdi kontrolü
            if (veri.Length != 8 && veri.Length != 16 && veri.Length != 32)
            {
                MessageBox.Show("Lütfen 8, 16 veya 32 bitlik veri girin.");
                return;
            }

            if (!IsBinary(veri))
            {
                MessageBox.Show("Veri yalnýzca 1 ve 0 içermelidir.");
                return;
            }

            // 2. Kodlama iþlemi
            string kodlanmis = coder.Encode(veri);

            // 3. Sonucu göster
            txt_cikti.Text = kodlanmis;

            // 2. aþama

            memory.Write(kodlanmis);




        }

        private void btn_hataOlustur_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrWhiteSpace(txtBitKonumu.Text))
            {
                MessageBox.Show("Lütfen bozulacak bit konumunu girin.");
                return;
            }

            if (!int.TryParse(txtBitKonumu.Text.Trim(), out int bitPos))
            {
                MessageBox.Show("Geçerli bir sayý girin.");
                return;
            }
            */

            string veri = memory.Read();


            if (veri == null)
            {
                MessageBox.Show("Bellekte veri yok. Önce kodlama yapýn.");
                return;
            }

            if (hataBitNo < 0 || hataBitNo >= veri.Length)
            {
                MessageBox.Show("Bit konumu 0 ile " + (veri.Length - 1) + " arasýnda olmalý. Lütfen hata bitini seçiniz. ");
                return;
            }

            if (hataBitSayisi > 1)
            {
                MessageBox.Show("Lütfen sadece bir adet hata biti seçin.");
                return;
            }

            // Hata enjekte et
            memory.InjectError(hataBitNo);

            // Hatalý veriyi al ve göster
            string hataliVeri = memory.Read();
            lbl_hatali.Text = hataliVeri;

        }

        // Hata biti secme fonksiyonlarý

        void button_Event_Baglama()
        {
            btn_0.Click += Button_Click;
            btn_1.Click += Button_Click;
            btn_2.Click += Button_Click;
            btn_3.Click += Button_Click;
            btn_4.Click += Button_Click;
            btn_5.Click += Button_Click;
            btn_6.Click += Button_Click;
            btn_7.Click += Button_Click;
            btn_8.Click += Button_Click;
            btn_9.Click += Button_Click;
            btn_10.Click += Button_Click;
            btn_11.Click += Button_Click;
            btn_12.Click += Button_Click;
            btn_13.Click += Button_Click;
            btn_14.Click += Button_Click;
            btn_15.Click += Button_Click;
            btn_16.Click += Button_Click;
            btn_17.Click += Button_Click;
            btn_18.Click += Button_Click;
            btn_19.Click += Button_Click;
            btn_20.Click += Button_Click;
            btn_21.Click += Button_Click;
            btn_22.Click += Button_Click;
            btn_23.Click += Button_Click;
            btn_24.Click += Button_Click;
            btn_25.Click += Button_Click;
            btn_26.Click += Button_Click;
            btn_27.Click += Button_Click;
            btn_28.Click += Button_Click;
            btn_29.Click += Button_Click;
            btn_30.Click += Button_Click;
            btn_31.Click += Button_Click;
            btn_32.Click += Button_Click;
            btn_33.Click += Button_Click;
            btn_34.Click += Button_Click;
            btn_35.Click += Button_Click;
            btn_36.Click += Button_Click;
            btn_37.Click += Button_Click;
            btn_38.Click += Button_Click;
            btn_39.Click += Button_Click;
            btn_40.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if(clickedButton.BackColor == Color.Green)
                {
                    clickedButton.BackColor = SystemColors.Control;
                    hataBitSayisi -= 1;
                    return;
                }
                if(hataBitSayisi >= 1)
                {
                    MessageBox.Show("Lütfen bir adet hata biti seçiniz");
                    return;
                }
                else
                {
                    if (clickedButton.BackColor != Color.Green)
                    {
                        clickedButton.BackColor = Color.Green;
                        hataBitSayisi += 1;
                        hataBitNo = Int32.Parse(clickedButton.Text);
                    }
                }
                
            }
        }

        // Varsayýlan rengine döndürme
        void buttonTemizle()
        {
            btn_0.BackColor = SystemColors.Control; // Varsayýlan buton rengi
            btn_1.BackColor = SystemColors.Control;
            btn_2.BackColor = SystemColors.Control;
            btn_3.BackColor = SystemColors.Control;
            btn_4.BackColor = SystemColors.Control;
            btn_5.BackColor = SystemColors.Control;
            btn_6.BackColor = SystemColors.Control;
            btn_7.BackColor = SystemColors.Control;
            btn_8.BackColor = SystemColors.Control;
            btn_9.BackColor = SystemColors.Control;
            btn_10.BackColor = SystemColors.Control;
            btn_11.BackColor = SystemColors.Control;
            btn_12.BackColor = SystemColors.Control;
            btn_13.BackColor = SystemColors.Control;
            btn_14.BackColor = SystemColors.Control;
            btn_15.BackColor = SystemColors.Control;
            btn_16.BackColor = SystemColors.Control;
            btn_17.BackColor = SystemColors.Control;
            btn_18.BackColor = SystemColors.Control;
            btn_19.BackColor = SystemColors.Control;
            btn_20.BackColor = SystemColors.Control;
            btn_21.BackColor = SystemColors.Control;
            btn_22.BackColor = SystemColors.Control;
            btn_23.BackColor = SystemColors.Control;
            btn_24.BackColor = SystemColors.Control;
            btn_25.BackColor = SystemColors.Control;
            btn_26.BackColor = SystemColors.Control;
            btn_27.BackColor = SystemColors.Control;
            btn_28.BackColor = SystemColors.Control;
            btn_29.BackColor = SystemColors.Control;
            btn_30.BackColor = SystemColors.Control;
            btn_31.BackColor = SystemColors.Control;
            btn_32.BackColor = SystemColors.Control;
            btn_33.BackColor = SystemColors.Control;
            btn_34.BackColor = SystemColors.Control;   
            btn_35.BackColor = SystemColors.Control;
            btn_36.BackColor = SystemColors.Control;
            btn_37.BackColor = SystemColors.Control;
            btn_38.BackColor = SystemColors.Control;
            btn_39.BackColor = SystemColors.Control;
            btn_40.BackColor = SystemColors.Control;
            /*for (int i = 0; i <= 40; i++)
            {
                Control control = Controls[$"btn_{i}"];
                if (control is Button btn)
                {
                    btn.BackColor = SystemColors.Control; // Varsayýlan buton rengi
                }
            }*/

        }

        private void btn_duzelt_Click(object sender, EventArgs e)
        {
            string encoded = memory.Read();

            if (string.IsNullOrEmpty(encoded))
            {
                MessageBox.Show("Bellekte veri yok.");
                return;
            }

            int errorPos;
            string originalData = coder.Decode(encoded, out errorPos);

            lbl_sonuc.Text = errorPos >= 0 ? errorPos.ToString() : "Hata Yok";
            lbl_orijinalveri.Text = originalData;
        }
    }

}
