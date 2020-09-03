using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Domains
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public int Idade { get; set; }



        public Aluno()
        {

        }
        public Aluno(int _IdAluno , string _Nome , string _Ra , int _Idade)
        {
            Idade   = _Idade;
            Nome    = _Nome;
            Ra      = _Ra;
            IdAluno = _IdAluno;

        }

    }


}
