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
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }
        sql bgl=new sql();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da =new SqlDataAdapter("Select * From Tbl_randevular ",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;




        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            mskdTarih.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            maskdSaat.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbDoktor.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskdTc.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void FrmRandevuListesi_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Tbl_randevular set randevuTarih=@p1 , randevuSaat=@p2 , RandevuBrans=@p3 ,randevuDoktor=@p4 , hastaTC=@p5 where RandevuID=@p6", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p1", mskdTarih.Text);
            cmd2.Parameters.AddWithValue("@p2", maskdSaat.Text);
            cmd2.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd2.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            cmd2.Parameters.AddWithValue("@p5", mskdTc.Text);
            cmd2.Parameters.AddWithValue("@p6", txtID.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi", "Bilgi");
        }

        private void listele_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
