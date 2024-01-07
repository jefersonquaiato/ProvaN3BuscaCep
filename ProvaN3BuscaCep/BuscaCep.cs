using System;
using System.Net.Http;
using System.Threading.Tasks;
using ProvaN3BuscaCep;
using Newtonsoft.Json;

public class BuscaCEP
{
    private const string ViaCEPBaseUrl = "https://viacep.com.br/ws/";

    public async Task<Endereco> ConsultarCEPAsync(string cep)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ViaCEPBaseUrl}{cep}/json";
                HttpResponseMessage response = await client.GetAsync(cep);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Endereco endereco = JsonConvert.DeserializeObject<Endereco>(data);

                    return endereco;
                }
                else
                {
                    throw new Exception("Erro ao consultar o ViaCEP. Verifique o CEP e tente novamente.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro durante a consulta ao ViaCEP.", ex);
        }
    }
}