using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI_Escola.Domains
{
    public class Escola
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Aluno>Alunos {get;set;}
        public Escola()
        {
            Id = Guid.NewGuid();
        }
    }
}
