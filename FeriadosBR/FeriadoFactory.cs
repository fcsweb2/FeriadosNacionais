using Newtonsoft.Json;
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
        public async Task<Feriado> GetProxFeriado()
        {
            String erro;
            Uri geturi = new Uri("http://feriado.hcfsolutions.com.br/app/feriados");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
			Feriado feriado = new Feriado();
            if (responseGet.IsSuccessStatusCode)
            {
                string response = await responseGet.Content.ReadAsStringAsync();
                feriado = JsonConvert.DeserializeObject<Feriado>(response);
            }
            else
            {
                erro = responseGet.StatusCode.ToString() + " - " + responseGet.ReasonPhrase;
            }

			return feriado;
        }

        public async Task<List<Feriado>> GetFeriadosAno(int ano)
        {
            String erro;
            Uri geturi = new Uri("http://feriado.hcfsolutions.com.br/app/feriados/" + ano);
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            List<Feriado> listFeriadosDoAno = new List<Feriado>();
            if (responseGet.IsSuccessStatusCode)
            {
                string response = await responseGet.Content.ReadAsStringAsync();
				listFeriadosDoAno = JsonConvert.DeserializeObject<List<Feriado>>(response);
            }
            else
            {
                erro = responseGet.StatusCode.ToString() + " - " + responseGet.ReasonPhrase;
            }

			return listFeriadosDoAno;
        }

        public async Task<Feriado> GetFeriadosAnoById(int ano, int id)
        {
            String erro;
            Uri geturi = new Uri("http://feriado.hcfsolutions.com.br/app/feriados/" + ano + "/" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
			Feriado feriado = new Feriado();
            if (responseGet.IsSuccessStatusCode)
            {
                string response = await responseGet.Content.ReadAsStringAsync();
                feriado = JsonConvert.DeserializeObject<Feriado>(response);
            }
            else
            {
                erro = responseGet.StatusCode.ToString() + " - " + responseGet.ReasonPhrase;
            }

            return feriado;
        }

    }
}
