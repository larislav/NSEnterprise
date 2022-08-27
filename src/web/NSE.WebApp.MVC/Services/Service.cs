using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            var dataContent = new StringContent
                (
                    JsonSerializer.Serialize(dado),
                    Encoding.UTF8,
                    "application/json"
                );

            return dataContent;
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:

                case 403:

                case 404:

                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;

                default:
                    break;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
