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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }

        public string TCnumara;

        Sqlbaglanti bgl = new Sqlbaglanti();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TCnumara;

            // adsoyad çekme
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Table_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lblADSOYAD.Text = dr1[0].ToString();    
            }
            bgl.baglanti().Close();

            // branşları datagridviewe aktarma
            DataTable dt1=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Table_Brans",bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource= dt1;

            // doktorları datagride aktarma
            DataTable dt2=new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',DoktorBrans from Table_Doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource= dt2;



        }
    }
}
