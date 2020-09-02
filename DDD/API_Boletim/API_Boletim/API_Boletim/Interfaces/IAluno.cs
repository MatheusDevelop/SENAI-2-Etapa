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
        Aluno Create(Aluno a);
        Aluno Delete(Aluno a);
        Aluno SearchForId(int id);
        List<Aluno> ReadAll();
        Aluno Update(Aluno a);

    }
}
