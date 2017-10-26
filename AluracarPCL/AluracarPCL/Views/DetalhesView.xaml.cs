using AluracarPCL.Model;
using AluracarPCL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    public partial class DetalhesView : ContentPage
    {
        public Carro Veiculo { get; set; }

        public DetalhesView(Carro veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            BindingContext = new DetalhesViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Carro>(this, "Proximo", (msg) => Navigation.PushAsync(new AgendamentoView(msg)));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Carro>(this, "Proximo");
        }

    }
}
