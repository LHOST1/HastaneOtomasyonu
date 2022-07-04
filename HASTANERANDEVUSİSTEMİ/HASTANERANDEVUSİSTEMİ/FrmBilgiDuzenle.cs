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
    public partial class FrmBilgiDuzenle : Form
    {
        sql bgl=new sql();

        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public String TCno;


        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskdTxtTc.Text = TCno;
            SqlCommand komut = new  SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTxtTc.Text);
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                txtTel.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbxCinsi.Text = dr[6].ToString();
                
            }
            bgl.baglanti().Close();
        }


        private void cmbxCinsi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
