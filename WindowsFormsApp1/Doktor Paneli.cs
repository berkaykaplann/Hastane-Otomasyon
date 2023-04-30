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


namespace WindowsFormsApp1
{
    public partial class Doktor_Paneli : Form
    {
        public Doktor_Paneli()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        private void Doktor_Paneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Table_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Table_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", textBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBoxBrans.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBoxTC.Text);
            komut.Parameters.AddWithValue("@p5", textBoxSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen =dataGridView1.SelectedCells[0].RowIndex;
            textBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBoxBrans.Text=dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBoxTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBoxSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
