using AluracarPCL.Model;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace AluracarPCL.Services
{
    public class LoginService
    {
        private const string URL_LOGIN = "https://aluracar.herokuapp.com/login";
        public static async Task FazLogin(Login credentials)
        {
            using (var client = new HttpClient())
            {
                var conteudo = new FormUrlEncodedContent(new[] {
                        new KeyValuePair<string, string>("email", credentials.Email),
                        new KeyValuePair<string, string>("senha", credentials.Senha)
                    });
                try
                {
                    var response = await client.PostAsync(URL_LOGIN, conteudo);
                    if (response.IsSuccessStatusCode) MessagingCenter.Send<Usuario>(new Usuario(), "LoginSuccess");
                    else
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        using (var streamReader = new StreamReader(stream))
                        {
                            var text = JsonConvert.DeserializeObject<MensagemJson>(await streamReader.ReadToEndAsync());
                            MessagingCenter.Send<LoginException>(
                                new LoginException(text.Mensagem), "LoginFailed");
                        }
                    }
                }
                catch (Exception)
                {
                    MessagingCenter.Send<LoginException>(
                        new LoginException(
                            @"Ocorreu um erro ao conectar-se com o servidor. Por favor, verifique sua conexão com a internet e tente novamente mais tarde."),
                            "LoginFailed"
                        );
                }
            }
        }
    }

    public class MensagemJson
    {
        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
    }

}
