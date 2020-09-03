using API_ClinicaVet.Context;
using API_ClinicaVet.Domains;
using API_ClinicaVet.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_ClinicaVet.Repositories
{
    public class TipoRepository:ITipo
    {

        ClinicaContext con = new ClinicaContext();
        SqlCommand cmd = new SqlCommand();

        public List<Tipo> Create(Tipo a)
        {

            cmd.Connection = con.Connect();
            cmd.CommandText =
                "INSERT INTO Tipo(NomeTipo) " +
                "VALUES(@NomeTipo)"
                ;
            cmd.Parameters.AddWithValue("NomeTipo", a.NomeTipo);
           
            SqlDataReader data = cmd.ExecuteReader();


            con.Desconnect();
            return ReadAll();
        }

        public void Delete(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "DELETE FROM Tipo WHERE IdTipo= @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
        }

        public List<Tipo> ReadAll()
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Tipo";

            SqlDataReader data = cmd.ExecuteReader();
            List<Tipo> listaTipo = new List<Tipo>();

            Listar(data, listaTipo);
            con.Desconnect();

            return listaTipo;
        }
        
        public Tipo SearchForId(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Tipo WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader data = cmd.ExecuteReader();
            Tipo tipo = new Tipo();

            ReadEspecify(data, tipo);

            con.Desconnect();
            return tipo;
        }

        public List<Tipo> Update(int id, Tipo a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
               "UPDATE Tipo SET " +
               "NomeTipo = @NomeTipo " +             
               "WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("NomeTipo", a.NomeTipo);

            SqlDataReader data = cmd.ExecuteReader();
            con.Desconnect();
            return ReadAll();

        }




        /// <summary>
        /// Lista todos os objetos
        /// </summary>
        /// <param name="data">SqlDataReader</param>
        /// <param name="listaTipo">A Lista que voce quer listar</param>

        public void Listar(SqlDataReader data, List<Tipo> listaTipo)
        {
            while (data.Read())
            {
                listaTipo.Add(new Tipo()
                {
                    IdTipo      = Convert.ToInt32(data.GetValue(0)),
                    NomeTipo    = Convert.ToString(data.GetValue(1))
                });
            }
        }
        /// <summary>
        /// Le um objeto especifico
        /// </summary>
        /// <param name="data">SqlDataReader</param>
        /// <param name="tipo">O Objeto que voce quer ler</param>
        public void ReadEspecify(SqlDataReader data,Tipo tipo)
        {
            while (data.Read())
            {
                tipo.IdTipo     = Convert.ToInt32(data.GetValue(0));
                tipo.NomeTipo   = Convert.ToString(data.GetValue(1));
            }
        }



    }
}
