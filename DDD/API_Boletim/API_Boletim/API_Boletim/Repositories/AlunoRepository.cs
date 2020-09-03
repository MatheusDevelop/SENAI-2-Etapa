using API_Boletim.Context;
using API_Boletim.Domains;
using API_Boletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        //Chamando class de conexao do banco
        BoletimContext conexao = new BoletimContext();

        //Obj que executa os comandos do banco
        SqlCommand cmd = new SqlCommand();

        public void Create(Aluno a)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText =
                "INSERT INTO Aluno(Nome,Ra,Idade) " +
                "VALUES(@Nome,@Ra,@Idade')"
                ;
            cmd.Parameters.AddWithValue("Nome", a.Nome);
            cmd.Parameters.AddWithValue("Ra",a.Ra);
            cmd.Parameters.AddWithValue("Idade", a.Idade);
            SqlDataReader data = cmd.ExecuteReader();
            conexao.Desconectar();
           
        }

        public void Delete(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "DELETE FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader data = cmd.ExecuteReader();

            conexao.Desconectar();


        }

        public List<Aluno> ReadAll()
        {
            //Sempre o metodo abre uma conexao e fecha uma conexao

            //ABRINDO

            //Conecta e define qual comando sql
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno";



            SqlDataReader dados = cmd.ExecuteReader();

            //Criando lista pra guardar as informaçoes
            List<Aluno> a = new List<Aluno>();

            while (dados.Read())
            {
                int IdAluno     = Convert.ToInt32(dados.GetValue(0));
                string Nome     = Convert.ToString(dados.GetValue(1));
                string Ra       = Convert.ToString(dados.GetValue(2));
                int Idade       = Convert.ToInt32(dados.GetValue(3));

                a.Add(new Aluno(IdAluno,Nome,Ra,Idade));

            }





            conexao.Desconectar();
            //Fechando
            return a;    

        }

        public Aluno SearchForId(int id)
        {
            cmd.Connection = conexao.Conectar();

            
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (dados.Read())
            {
                a.IdAluno   = Convert.ToInt32(dados.GetValue(0));
                a.Nome      = Convert.ToString(dados.GetValue(1));
                a.Ra        = Convert.ToString(dados.GetValue(2));
                a.Idade     = Convert.ToInt32(dados.GetValue(3));

            }

            return a;



        }

        public Aluno Update(int id,Aluno a)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText =
               "UPDATE Aluno SET " +
               "Nome = @Nome , " +
               "Ra = @Ra " +               
               "WHERE IdAluno = @IdAluno";
            cmd.Parameters.AddWithValue("IdAluno", id);
            cmd.Parameters.AddWithValue("Ra", a.Ra);
            cmd.Parameters.AddWithValue("Nome", a.Nome);

            SqlDataReader data = cmd.ExecuteReader();

            conexao.Desconectar();
            return SearchForId(id);
        }
    }
}
