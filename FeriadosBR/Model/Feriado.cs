using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriadosBR
{
    public class Feriado
    {
        public Data data { get; set; }
    }

    public class Data
    {
        private int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
        public string data { get; set; }
        public string diaSemana { get; set; }
        public string diaSemanaW { get; set; }
        public int intervalo { get; set; }
    }
}
