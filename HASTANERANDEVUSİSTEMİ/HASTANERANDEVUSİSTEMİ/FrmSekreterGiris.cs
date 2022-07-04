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
    public partial class FrmSekreterGiris : Form
    {
        sql bgl=new sql();
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            


            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTxtTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dt = komut.ExecuteReader();
            if (dt.Read())
            {
                sekreterDetay sekreterDetay = new sekreterDetay();
                sekreterDetay.TC = mskdTxtTc.Text;

                sekreterDetay.Show();
                this.Hide();
                

            }
            else
            {
        
                MessageBox.Show("Hatalı Giriş Yaptınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

            private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {
          
            
        }

        private void mskdTxtTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
    }

