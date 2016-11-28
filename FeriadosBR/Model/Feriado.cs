using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriadosBR
{
    class Feriado
    {
        public string data { get; set; }
        public string nome { get; set; }
        public string obs { get; set; }
        public string diaSemana { get; set; }
        public string diaSemanaDescricao { get; set; }
        public int id { get; set; }
        public int intervalo { get; set; }
    }
}
