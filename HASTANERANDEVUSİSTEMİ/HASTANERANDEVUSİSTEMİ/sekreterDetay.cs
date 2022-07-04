using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HASTANERANDEVUSİSTEMİ
{
    public partial class sekreterDetay : Form
    {
        public sekreterDetay()
        {
            InitializeComponent();
        }
        public string TC;
        sql bgl=new sql();


       
        private void sekreterDetay_Load(object sender, EventArgs e)
        {
           
            lblTC .Text= TC;
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable() ;
            SqlDataAdapter da = new SqlDataAdapter("Select * From tblBrans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            

            DataTable dt1=new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource= dt1;


            //Brans Ekleme
            SqlCommand cmd1 = new SqlCommand("Select BransAd from tblBrans", bgl.baglanti());
            SqlDataReader dr2=cmd1.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }

          


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_randevular (randevuTarih,randevuSaat,randevuBrans,randevuDoktor,hastaTC) values (@r1,@r2,@r3,@r4,@r5)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1", mskdTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2", maskdSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komutKaydet.Parameters.AddWithValue("@r5",mskdTc.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();    
            SqlCommand sqlCommand = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktor where DoktorBrans=@p1",bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                cmbDoktor.Items.Add(reader[0]+" " + reader[1]);
            }
            bgl.baglanti().Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtDuy.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");

        }

        private void doktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr=new FrmDoktorPaneli();
            fr.Show();

        }

        private void btnBrans_Click(object sender, EventArgs e)
        {
            FrmBrans brans = new FrmBrans();
            brans.Show();




        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi randevuListesi=new FrmRandevuListesi();
            randevuListesi.Show();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular duy = new FrmDuyurular();
            duy.Show();

        }
    }
}
