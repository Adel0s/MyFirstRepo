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
    public partial class Form3 : Form
    {
        private SqlConnection con;
        public Form3(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        bool userExista(string email)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori Where Email = @email", con);
            cmd.Parameters.AddWithValue("email", email);
            var red = cmd.ExecuteReader();
            bool ok = red.Read();
            if (ok)
                return true;
            return false;
        }

        bool validareEmail(string email)
        {
            if (email.Count(x => x == '@') != 1)
                return false;
            var ind = email.IndexOf('@');
            email = email.Substring(ind + 1);
            if (email.Count(x => x == '.') != 1)
                return false;
            ind = email.IndexOf('.');
            if (ind == 0 || ind == email.Length - 1)
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
                if (control is TextBox && (control as TextBox).TextLength == 0)
                {
                    MessageBox.Show("Campuri vide!");
                    break;
                }

            if (userExista(textBox2.Text))
                MessageBox.Show("User deja existent!");
            else
            {
                if (validareEmail(textBox2.Text))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Utilizatori(Nume,Email,Parola) VALUES(@nume,@email,@parola)", con);
                    cmd.Parameters.AddWithValue("nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("email", textBox1.Text);
                    cmd.Parameters.AddWithValue("parola", textBox1.Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Cont creat cu succes!");
                    }
                    else MessageBox.Show("Mai incearca o data!");
                }
                else MessageBox.Show("Email invalid!");
            }
        }
    }
}
