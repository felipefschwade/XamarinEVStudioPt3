using AluracarPCL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluracarPCL.ViewModel
{
    public class AgendamentoViewModel : ViewModelBase
    {
        const string URL_POST_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";
        private bool isbusy;

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); }
        }

        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); ((Command)AgendarCommand).ChangeCanExecute(); }
        }

        public bool IsBusy
        {
            get { return isbusy; }
            set { isbusy = value; OnPropertyChanged(); }
        }

        public AgendamentoViewModel(Carro veiculo)
        {
            Agendamento = new Agendamento(veiculo);
            AgendarCommand = new Command(() => 
            {
                MessagingCenter.Send(Agendamento, "Agendamento");
            }, () => {
                return !String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Telefone) && !String.IsNullOrEmpty(Email);
            });
        }

        public ICommand AgendarCommand { get; set; }

        public Agendamento Agendamento { get; set; }

        public async Task SalvaAgendamento()
        {
            IsBusy = true;
            var client = new HttpClient();
            var dataEHora = new DateTime(Agendamento.Data.Year, Agendamento.Data.Month, Agendamento.Data.Day, Agendamento.Hora.Hours, Agendamento.Hora.Minutes, 0);
            var json = JsonConvert.SerializeObject(new {
                nome = Agendamento.Nome,
                fone = Agendamento.Telefone,
                email = Agendamento.Email,
                carro = Agendamento.Veiculo.Nome,
                preco = Agendamento.Veiculo.Valor,
                dataAgendamento = dataEHora
            });
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL_POST_AGENDAMENTO, conteudo);
            IsBusy = false;
            if (result.IsSuccessStatusCode)
            {
                MessagingCenter.Send(Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send(new ArgumentException(), "FalhaAgendamento");
            }
        }

    }
}
