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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        Sqlbaglanti bgl = new Sqlbaglanti();

        private void HastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;
 // Ad Soyad çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Table_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblADSOYAD.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

// Randevu Geçmişi görüntüleme
                DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;


            // Branşları çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Table_Brans", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while(dr2.Read())
            {
                comboBoxBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
