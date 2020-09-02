using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_teste.Domains;

namespace API_teste.Interfaces
{
    interface IAtendimento
    {

        Atendimento Create(Atendimento a);
        List<Atendimento> Read();
        Atendimento SearchForId(int id);
        Atendimento Update(Atendimento a);
        Atendimento Delete(Atendimento a);
         
    }
}
