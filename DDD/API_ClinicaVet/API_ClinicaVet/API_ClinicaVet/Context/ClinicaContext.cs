using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_ClinicaVet.Context
{
    public class ClinicaContext
    {
        SqlConnection con = new SqlConnection();
        
        public ClinicaContext()
        {
            con.ConnectionString = @"Data Source=WILLIAM\SQLEXPRESS;Initial Catalog=Clinica;User ID=sa;Password=sa132";
        }
        
        
        public SqlConnection Connect()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconnect()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        


    }
}
