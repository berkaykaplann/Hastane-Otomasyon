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
    public partial class Doktor_Detay : Form
    {
        public Doktor_Detay()
        {
            InitializeComponent();
        }
        Sqlbaglanti bgl = new Sqlbaglanti();
        public string TC;
        private void Doktor_Detay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            SqlCommand komut = new SqlCommand("Select DoktorAd , DoktorSoyad From Table_Doktor where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr= komut.ExecuteReader();    
            while(dr.Read())
            {
                lblAdSoyad.Text = dr[0]+ " " + dr[1];

            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("select * from Table_Randevular where RandevuDoktor='"+lblAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;




        }

        private void Doktor_Detay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doktor_Bilgi_Düzenleme fr =new  Doktor_Bilgi_Düzenleme();
            fr.TCNO = lblTC.Text;
            fr.Show();
        }
    }
}
