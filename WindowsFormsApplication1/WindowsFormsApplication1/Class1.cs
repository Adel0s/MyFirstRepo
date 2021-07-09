using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public class Class1
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }

        public Class1(SqlConnection con, int id)
        {
            this.ID = id;
            SqlCommand cmd = new SqlCommand("Select * From Utilizatori Where IdUtilizator = @id",con);
            cmd.Parameters.AddWithValue("id",id);
            var red = cmd.ExecuteReader();
            if(red.Read())
            {
                this.Nume= red[1].ToString();
                this.Email= red[2].ToString();
                this.Parola= red[3].ToString();
            }
        }
    }
}
