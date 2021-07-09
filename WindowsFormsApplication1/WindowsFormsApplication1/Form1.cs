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
    public partial class Form1 : Form
    {
        private SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True;MultipleActiveResultSets = True;");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Utilizatori Where Email=@email AND Parola=@parola",con);
            cmd.Parameters.AddWithValue("email",textBox1.Text);
            cmd.Parameters.AddWithValue("parola", textBox2.Text);
            var red = cmd.ExecuteReader();
            if (red.Read())
            {
                int id = Convert.ToInt32(red[0]);
                Form2 forma = new Form2(con,new Class1(con,id));
                forma.Show();
                this.Hide();
                forma.FormClosed += (a,b)=>
                { 
                    this.Show();
                };
            }
            else MessageBox.Show("Date de logare incorecte!","Avertizare!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 forma3 = new Form3(con);
            forma3.Show();
            this.Hide();
            forma3.FormClosed += (a, b) =>
                {
                    this.Show();
                };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 forma = new Form4(con);
            forma.Show();
            this.Hide();
            forma.FormClosed += (a, b) =>
                {
                    this.Show();
                };
        }
    }
}
