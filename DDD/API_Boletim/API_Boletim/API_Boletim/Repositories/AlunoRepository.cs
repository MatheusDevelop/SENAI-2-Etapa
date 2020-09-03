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

        public Aluno Create(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno Delete(Aluno a)
        {
            throw new NotImplementedException();
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

        public Aluno Update(Aluno a)
        {
            throw new NotImplementedException();
        }
    }
}
