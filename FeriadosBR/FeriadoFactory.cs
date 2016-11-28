using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeriadosBR
{
    class FeriadoFactory
    {
        public async void GetRequest()
        {
            Uri geturi = new Uri("http://feriado.hcfsolutions.com.br/app/feriados");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);

            string response = await responseGet.Content.ReadAsStringAsync();
        }
    }
}
