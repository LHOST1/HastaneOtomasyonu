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
    public partial class frmDoktorDetay : Form
    {
        sql bgl = new sql();
        public frmDoktorDetay()
        {
            InitializeComponent();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string TC;

        private void frmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text =TC;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //AD soyad çekme
            SqlCommand ds = new SqlCommand("Select DoktorAd , DoktorSoyad From Tbl_Doktor where DoktorTC=@p1 ",bgl.baglanti());
            ds.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr=ds.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[0]+" "+dr[1];
            }
            bgl.baglanti().Close();
        }

        private void btnDuy_Click(object sender, EventArgs e)
        {
            FrmDuyurular duy = new FrmDuyurular();
            duy.Show();
        }

        private void btnCık_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            
        }
    }
}
