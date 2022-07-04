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
    public partial class FrmHasta : Form

    {
       
        public FrmHasta()
        {
            InitializeComponent();
        }
        sql bgl = new sql();
      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komt = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());


            komt.Parameters.AddWithValue("@p1", mskdTxtTc.Text);
            komt.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komt.ExecuteReader();
            if (dr.Read())
            {
              
                
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = mskdTxtTc.Text;
                fr.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre girdf");
            }
            
            
        }

    

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr=new FrmHastaKayit();
            fr.Show();

        }

        private void mskdTxtTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
