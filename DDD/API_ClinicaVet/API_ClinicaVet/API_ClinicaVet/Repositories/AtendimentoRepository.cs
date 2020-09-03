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
    public class AtendimentoRepository : IAtendimento
    {
        ClinicaContext con = new ClinicaContext();

        SqlCommand cmd = new SqlCommand();

        public List<Atendimento> Create(Atendimento a)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText =
                "INSERT INTO Atendimento(DataAtendimento,Descricao,IdVet,IdPet) " +
                "VALUES(@DataAtendimento,@Descricao,@IdVet,@IdPet)"
                ;
            cmd.Parameters.AddWithValue("DataAtendimento", a.DataAtendimento);
            cmd.Parameters.AddWithValue("Descricao",a.Descricao);
            cmd.Parameters.AddWithValue("IdVet", a.IdVet);
            cmd.Parameters.AddWithValue("IdPet", a.IdPet);

            SqlDataReader data = cmd.ExecuteReader();


            con.Desconnect();
            return ReadAll();



        }
        public List<Atendimento> ReadAll()
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Atendimento";

            SqlDataReader data = cmd.ExecuteReader();

            List<Atendimento> listaAtendimento = new List<Atendimento>();

            while (data.Read())
            {
                listaAtendimento.Add(new Atendimento()
                {
                    IdAtendimento   =Convert.ToInt32(data.GetValue(0)),
                    DataAtendimento =Convert.ToDateTime(data.GetValue(1)),
                    Descricao       =Convert.ToString(data.GetValue(2)),
                    IdPet           =Convert.ToInt32(data.GetValue(3)),
                    IdVet           =Convert.ToInt32(data.GetValue(4))
                });
            }    



            con.Desconnect();

            return listaAtendimento;
        }
        public void Delete(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "DELETE FROM Atendimento WHERE IdAtendimento = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();

        }
        public Atendimento SearchForId(int id)
        {
            cmd.Connection = con.Connect();
            cmd.CommandText = "SELECT * FROM Atendimento WHERE IdAtendimento = @id";
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader data = cmd.ExecuteReader();

            Atendimento atendimento = new Atendimento();

            while (data.Read())
            {
                atendimento.IdAtendimento   = Convert.ToInt32(data.GetValue(0));
                atendimento.DataAtendimento = Convert.ToDateTime(data.GetValue(1));
                atendimento.Descricao       = Convert.ToString(data.GetValue(2));
                atendimento.IdPet           = Convert.ToInt32(data.GetValue(3));
                atendimento.IdVet           = Convert.ToInt32(data.GetValue(4));
            }

            con.Desconnect();
            return atendimento;

            
        }
        public List<Atendimento> Update(int id,Atendimento a)
        {
            cmd.Connection = con.Connect();

            //IdPet e IdVet trocam de valores quando atualizados por este metodo
            //Não tentei resolver ainda
            
            cmd.CommandText = 
                "UPDATE Atendimento SET " +
                "Descricao = @Descricao , " +
                "DataAtendimento = @DtaAtendimento ," +
                "IdPet = @IdPet ," +
                "IdVet = @IdVeterinario " +
                "WHERE IdAtendimento = @IdAtendimento";


            cmd.Parameters.AddWithValue("IdAtendimento",id);
            cmd.Parameters.AddWithValue("IdPet",a.IdPet);
            cmd.Parameters.AddWithValue("IdVeterinario",a.IdVet);
            cmd.Parameters.AddWithValue("Descricao",a.Descricao);
            cmd.Parameters.AddWithValue("DtaAtendimento",a.DataAtendimento);





            SqlDataReader data = cmd.ExecuteReader();

            con.Desconnect();
            return ReadAll();


        }
    }
}
