using API_ClinicaVet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ClinicaVet.Interfaces
{
    interface ITipo
    {
        List<Tipo> ReadAll();
        List<Tipo> Create(Tipo a);
        List<Tipo> Update(int id, Tipo a);
        public void Delete(int id);
        Tipo SearchForId(int id);
    }
}
