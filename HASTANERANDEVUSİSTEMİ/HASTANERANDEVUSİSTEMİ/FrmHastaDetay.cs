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
    public partial class FrmHastaDetay : Form
    {
        public String tc;
        sql bgl =new sql();
        
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTC_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            
            lblTC.Text = tc;
            mskdTc.Text = lblTC.Text;
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader sqlDataReader = komut.ExecuteReader();
            while (sqlDataReader.Read())
            {
                lblAd.Text = sqlDataReader[0] + " " + sqlDataReader[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_randevular where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From tblBrans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);

            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut4 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktor where DoktorBrans=@p1",bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader dr3 = komut4.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_randevular where RandevuBrans= '" + cmbBrans.Text+ "'" , bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.Show();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnRandevu_Click(object sender, EventArgs e)
        {
            SqlCommand ran = new SqlCommand("insert into Tbl_randevular (RandevuBrans, randevuDoktor ,hastaTC) values (@p2,@p3,@p4)", bgl.baglanti());
            
            ran.Parameters.AddWithValue("@p2", cmbBrans.Text);
            ran.Parameters.AddWithValue("@p3", cmbDoktor.Text);
            ran.Parameters.AddWithValue("@p4", lblTC.Text);
            ran.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu", "Bilgi");
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_randevular (randevuTarih,randevuSaat,randevuBrans,randevuDoktor,hastaTC) values (@r1,@r2,@r3,@r4,@r5)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1", mskdTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2", maskdSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komutKaydet.Parameters.AddWithValue("@r5", mskdTc.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbBrans_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand sqlCommand = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktor where DoktorBrans=@p1", bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                cmbDoktor.Items.Add(reader[0] + " " + reader[1]);
            }
            bgl.baglanti().Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
    }

