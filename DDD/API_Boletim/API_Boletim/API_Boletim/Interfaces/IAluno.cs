using API_Boletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Interfaces
{
    interface IAluno
    {
        //CRUD
        public void Create(Aluno a);
        public void Delete(int id);
        Aluno SearchForId(int id);
        List<Aluno> ReadAll();
        Aluno Update(int id,Aluno a);

    }
}
