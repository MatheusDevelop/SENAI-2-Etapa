using API_ClinicaVet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ClinicaVet.Interfaces
{
    interface IAtendimento
    {
        List<Atendimento> ReadAll();
        List<Atendimento> Create(Atendimento a );
        List<Atendimento> Update(int id,Atendimento a);
        public void Delete(int id);
        Atendimento SearchForId(int id);


    }
}
