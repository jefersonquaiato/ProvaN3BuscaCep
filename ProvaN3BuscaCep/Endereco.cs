using Newtonsoft.Json;

namespace ProvaN3BuscaCep
{
    public class Endereco
    {
        public string UF { get; set; }

        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        [JsonProperty("ibge")]
        public int CodigoIbge { get; set; }

        public int DDD { get; set; }
    }
}
