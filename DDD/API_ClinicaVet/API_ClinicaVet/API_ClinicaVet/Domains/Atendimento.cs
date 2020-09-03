using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ClinicaVet.Domains
{
    public class Atendimento
    {
        public int IdAtendimento { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string Descricao { get; set; }
        public int IdVet { get; set; }
        public int IdPet { get; set; }
    }
}
