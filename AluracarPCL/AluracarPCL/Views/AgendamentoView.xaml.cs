using AluracarPCL.Model;
using AluracarPCL.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Carro veiculo)
        {
            InitializeComponent();
            ViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", (msg) => MarcaAgendamento(msg));
            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) => DisplayAlert("Agendamento", $"Seu Agendamento para {msg.Data} foi realizado com sucesso!", "Ok"));
            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) => DisplayAlert("Agendamento", $"Não foi possível realizar o agendamento, revise os campos do formulário e se o problema persitir contate o suporte técnico!", "Ok"));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }

        private async void MarcaAgendamento(Agendamento agendamento)
        {
            var result = await DisplayAlert("Realizar Agendamento", $"Deseja mesmo realizar o Agendamento para {agendamento.Data.ToString("dd/MM/yyyy")}?", "Sim", "Não");
            if (result)
            {
                await ViewModel.SalvaAgendamento();
            }
        }
    }
}
