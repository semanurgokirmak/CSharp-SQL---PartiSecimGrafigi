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
    public partial class FormOyGiris : Form
    {
        public FormOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TTT8CS4\SQLEXPRESS;Integrated Security=True;Initial Catalog=DBsecimproje");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti .Open();                       
            SqlCommand komut = new SqlCommand("Insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@p1,@p2,@p3,@p4,@p5,@p6)" , baglanti  );       
            komut.Parameters.AddWithValue("@p1", tbxIlce.Text);         
            komut.Parameters.AddWithValue("@p2", tbxA .Text);
            komut.Parameters.AddWithValue("@p3", tbxB.Text);
            komut.Parameters.AddWithValue("@p4", tbxC.Text);
            komut.Parameters.AddWithValue("@p5", tbxD.Text);
            komut.Parameters.AddWithValue("@p6", tbxE.Text);
            komut.ExecuteNonQuery();       
            baglanti .Close();                  
            MessageBox.Show("Oy Girişi Gerçekleti");

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FormGrafikler fr = new FormGrafikler();      
            fr.Show();                                 

        }

        private void FormOyGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
