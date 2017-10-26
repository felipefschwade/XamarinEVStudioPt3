using Aluracar.Model;
using Aluracar.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView (Carro veiculo)
		{
			InitializeComponent ();
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
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }

        private void MarcaAgendamento(Agendamento agendamento)
        {
            DisplayAlert("Agendamento",
            String.Format(@"Veiculo: {0}
                            Nome: {1}
                            Telefone: {2}
                            Email: {3}
                            Data: {4}
                            Hora {5}", agendamento.Veiculo.Nome,
                                       agendamento.Nome,
                                       agendamento.Telefone,
                                       agendamento.Email,
                                       agendamento.Data.ToString("dd/MM/yyyy"),
                                       agendamento.Hora),
            "Ok");
        }
    }
}
