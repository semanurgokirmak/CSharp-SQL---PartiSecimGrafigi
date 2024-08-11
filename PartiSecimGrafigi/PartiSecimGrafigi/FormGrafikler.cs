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

namespace PartiSecimGrafigi
{
    public partial class FormGrafikler : Form
    {
        public FormGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TTT8CS4\SQLEXPRESS;Integrated Security=True;Initial Catalog=DBsecimproje");        //bağlantı cümlesini buraya da ekledik

        private void FormGrafikler_Load(object sender, EventArgs e)
        {
            // ilçe adlarını comboboxa çekme
            baglanti .Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD from TBLILCE", baglanti);         
            SqlDataReader dr = komut.ExecuteReader();                      
            while (dr.Read())                           
            {
                comboBox1.Items.Add(dr[0]);            

            }
            baglanti .Close();                    

            // grafiğe toplam sonuçları getirme
            baglanti .Open ();
            SqlCommand komut2 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE",baglanti  );     
            SqlDataReader dr2 = komut2.ExecuteReader();                    
            while (dr2.Read())                                      
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr2[0]);            
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[4]);    

                
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            baglanti.Open();
            SqlCommand komut = new SqlCommand ("Select * from TBLILCE where ILCEAD=@P1", baglanti  );
            komut.Parameters .AddWithValue ("@p1", comboBox1 .Text );
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1 .Value =int.Parse(dr[2].ToString ());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();

            }
            baglanti.Close();
        }
    }
}
