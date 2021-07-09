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
    public partial class Form4 : Form
    {
        private SqlConnection con;
        bool firstC=false;
        int contor = 0;
        public Form4(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;

            dataGridView1.CellClick += (a, b) =>
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();
                };
        }

        private void logareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
            form.FormClosed += (a, b) =>
            {
                this.Show();
            };
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT * FROM Utilizatori",con);
            var red = cmd.ExecuteReader();
            while (red.Read())
            {
                dataGridView1.Rows.Add(red[1], red[2], red[3]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand("Insert into Utilizatori(Nume,Email,Parola) Values(@nume,@email,@parola)", con);
                cmd.Parameters.AddWithValue("nume", textBox1.Text);
                cmd.Parameters.AddWithValue("email", textBox2.Text);
                cmd.Parameters.AddWithValue("parola", textBox3.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
        }
       
        private void creareContToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(con);
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow newDataRow = dataGridView1.Rows[rowIndex];
            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow newDataRow = dataGridView1.Rows[rowIndex];
            dataGridView1.Rows.RemoveAt(rowIndex);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            SqlCommand cmd = new SqlCommand("DELETE FROM Utilizatori WHERE Nume = @n, Email=@e, Parola=@p",con);
            cmd.Parameters.AddWithValue("n", textBox1.Text);
            cmd.Parameters.AddWithValue("e",textBox2.Text);
            cmd.Parameters.AddWithValue("p", textBox3.Text);
            cmd.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            contor--;
            button6.Enabled = true;
            if (contor == 1) button5.Enabled = false;
            //else button5.Enabled = true;
            pictureBox1.BackgroundImage = Image.FromFile(contor + ".png");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contor++;
            button5.Enabled = true;
            if (contor == 8) button6.Enabled = false;
            //else button6.Enabled = true;
            pictureBox1.BackgroundImage = Image.FromFile(contor + ".png");
        }
    }
}
