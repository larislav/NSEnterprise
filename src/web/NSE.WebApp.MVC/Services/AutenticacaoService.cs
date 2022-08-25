using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UsuarioRepostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent
                (
                    JsonSerializer.Serialize(usuarioLogin),
                    Encoding.UTF8,
                    "application/json"
                );

            var response = await _httpClient.PostAsync("https://localhost:44325/api/identidade/autenticar", loginContent);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRepostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRepostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRepostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent
                (
                    JsonSerializer.Serialize(usuarioRegistro),
                    Encoding.UTF8,
                    "application/json"
                );

            var response = await _httpClient.PostAsync("https://localhost:44325/api/identidade/nova-conta", registroContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRepostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRepostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
