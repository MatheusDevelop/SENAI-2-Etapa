using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI_Escola.Domains
{
    public class EscolaAluno
    {
        public Guid Id { get; set; }
        public Aluno Aluno { get; set; }
        public Guid IdAluno { get; set; }
        public Escola Escola  { get; set; }
        public Guid IdEscola { get; set; }


        public EscolaAluno()
        {
            Id = Guid.NewGuid();
        }
    }
}
