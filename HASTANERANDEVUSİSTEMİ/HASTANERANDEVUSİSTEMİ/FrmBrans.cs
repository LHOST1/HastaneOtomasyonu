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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        sql bgl=new sql();  

        private void FrmBrans_Load(object sender, EventArgs e)
        {
          DataTable dt = new DataTable();
          SqlDataAdapter adapter = new SqlDataAdapter("Select * from tblBrans ",bgl.baglanti());
          adapter.Fill(dt);
         dataGridView1.DataSource = dt;



        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tblBrans (BransAd) values (@p1)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtBransAd.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Eklendi", "Bilgi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("delete From tblBrans where BransAd=@p1 ", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", txtBransAd.Text);
            cmd1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Silindi", "Bilgi");
        }

        private void brnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update tblBrans set BransAd=@p1 where BransID=@p2", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p1", txtBransAd.Text);
            cmd2.Parameters.AddWithValue("@p2", txtBransID.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Güncellendi", "Bilgi");
        }
    }
}
