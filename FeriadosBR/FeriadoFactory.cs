using FeriadosBR.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public Feriado GetProxFeriado()
        {
            Feriado feriado = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://feriado.hcfsolutions.com.br/app/feriados")
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  feriado = JsonConvert.DeserializeObject<Feriado>(jsonString.Result);

              });
            task.Wait();

            return feriado;
        }

        public ColecaoFeriado GetFeriadosAno(int ano)
        {
            ColecaoFeriado listaFeriadosDoAno = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://feriado.hcfsolutions.com.br/app/feriados/" + ano)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  listaFeriadosDoAno = JsonConvert.DeserializeObject<ColecaoFeriado>(jsonString.Result);
                  
              });
            task.Wait();

            return listaFeriadosDoAno;
        }

        public async Task<ColecaoFeriado> GetFeriadosAnoById(int ano, int id)
        {
            String erro;
            Uri geturi = new Uri("http://feriado.hcfsolutions.com.br/app/feriados/" + ano + "/" + id);
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            ColecaoFeriado feriado = new ColecaoFeriado();
            if (responseGet.IsSuccessStatusCode)
            {
                string response = await responseGet.Content.ReadAsStringAsync();
                feriado = JsonConvert.DeserializeObject<ColecaoFeriado>(response);
            }
            else
            {
                erro = responseGet.StatusCode.ToString() + " - " + responseGet.ReasonPhrase;
            }

            return feriado;
        }

    }
}
