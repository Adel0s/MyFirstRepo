using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private SqlConnection con;
        private Class1 utilizatori;
        public Form2(SqlConnection con, Class1 utilizatori)
        {
            InitializeComponent();
            this.con = con;
            this.utilizatori = utilizatori;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(@"Anonymus.jpg");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            label1.Text = " Logat cu " + utilizatori.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            forma.Show();
            this.Hide();
        }
    }
}
