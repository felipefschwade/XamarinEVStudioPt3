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
                HttpResponseMessage response = null;
                try
                {
                    response = await client.PostAsync(URL_LOGIN, conteudo);
                }
                catch (Exception)
                {
                    MessagingCenter.Send<LoginException>(
                        new LoginException(
                            @"Ocorreu um erro ao conectar-se com o servidor. Por favor, verifique sua conexão com a internet e tente novamente mais tarde."),
                            "LoginFailed"
                        );
                }
                if (response.IsSuccessStatusCode)
                {
                    var resultadoString = await response.Content.ReadAsStringAsync();
                    var usuarioJSON = JsonConvert.DeserializeObject<UsuarioJSON>(resultadoString);
                    MessagingCenter.Send<Usuario>(usuarioJSON.Usuario, "LoginSuccess");
                }
                else
                {
                    var text = JsonConvert.DeserializeObject<MensagemJson>(await response.Content.ReadAsStringAsync());
                    MessagingCenter.Send<LoginException>(
                        new LoginException(text.Mensagem), "LoginFailed");
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
