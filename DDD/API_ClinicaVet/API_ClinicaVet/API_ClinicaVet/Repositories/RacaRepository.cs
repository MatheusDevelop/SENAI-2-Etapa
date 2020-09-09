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
    public class RacaRepository : IRaca
    {
        ClinicaContext con = new ClinicaContext();
        SqlCommand cmd = new SqlCommand();
        public List<Raca> Create(Raca a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
                "INSERT INTO Raca(NomeRaca) " +
                "VALUES(@NomeRaca)"
                ;
            cmd.Parameters.AddWithValue("NomeRaca", a.NomeRaca);

            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
            return ReadAll();
        }

        public void Delete(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca= @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
        }

        public List<Raca> ReadAll()
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader data = cmd.ExecuteReader();
            List<Raca> listaRaca = new List<Raca>();

            Listar(data, listaRaca);
            con.Desconnect();

            return listaRaca;
        }

        public Raca SearchForId(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader data = cmd.ExecuteReader();
            Raca raca = new Raca();

            ReadEspecify(data, raca);

            con.Desconnect();
            return raca;
        }

        public List<Raca> Update(int id, Raca a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
               "UPDATE Raca SET " +
               "NomeRaca = @NomeRaca " +
               "WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("NomeRaca", a.NomeRaca);

            SqlDataReader data = cmd.ExecuteReader();
            con.Desconnect();
            return ReadAll();
        }


        public void Listar(SqlDataReader data, List<Raca> listaRaca)
        {
            while (data.Read())
            {
                listaRaca.Add(new Raca()
                {
                    IdRaca = Convert.ToInt32(data.GetValue(0)),
                    NomeRaca = Convert.ToString(data.GetValue(1))
                });
            }
        }
        public void ReadEspecify(SqlDataReader data, Raca raca)
        {
            while (data.Read())
            {
                raca.IdRaca = Convert.ToInt32(data.GetValue(0));
                raca.NomeRaca = Convert.ToString(data.GetValue(1));
            }
        }


    }
}
