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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        sql bgl = new sql();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into Tbl_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutekle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutekle.Parameters.AddWithValue("@p3", cmbxBrans.Text);
            komutekle.Parameters.AddWithValue("@p4", mskdTxtTc.Text);
            komutekle.ExecuteNonQuery();
            MessageBox.Show("Doktor Başarıyla Eklendi");
        }

        public int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbxBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskdTxtTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Doktor where DoktorTC=@p1 ",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1",mskdTxtTc.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void brnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("Update  Tbl_Doktor set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d4 where DoktorTC=@p1", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@d1",txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", cmbxBrans.Text);
            komutGuncelle.Parameters.AddWithValue("@d4", txtSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@p1", mskdTxtTc.Text);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }

      
}
