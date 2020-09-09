using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI_Escola.Domains
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno()
        {
            Id = Guid.NewGuid();
        }
    }
}
