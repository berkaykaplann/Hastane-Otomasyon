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
    public partial class Bilgi_Düzenleme : Form
    {
        public Bilgi_Düzenleme()
        {
            InitializeComponent();
        }
        public string TCno;

        Sqlbaglanti bgl = new Sqlbaglanti();
        private void Bilgi_Düzenleme_Load(object sender, EventArgs e)
        {
            maskedTextBoxTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * From Table_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBoxTC.Text);
            SqlDataReader dr =komut.ExecuteReader();    

            while(dr.Read())
            {
                textBoxAd.Text = dr[1].ToString();
                textBoxSoyad.Text = dr[2].ToString();
                maskedTextBoxTel.Text = dr[4].ToString();
                textBoxSifre.Text=dr[5].ToString(); 
                comboBoxCinsiyet.Text=dr[6].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
