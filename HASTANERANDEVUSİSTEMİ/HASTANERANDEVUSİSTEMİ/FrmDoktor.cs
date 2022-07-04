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
    public partial class FrmDoktor : Form
    {
        sql bgl = new sql();

        public FrmDoktor()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Doktor where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskdTxtTc.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                frmDoktorDetay doktor=new frmDoktorDetay();
                doktor.TC=mskdTxtTc.Text;
                doktor.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre yanlış","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }

        private void FrmDoktor_Load(object sender, EventArgs e)
        {

        }
    }
}
