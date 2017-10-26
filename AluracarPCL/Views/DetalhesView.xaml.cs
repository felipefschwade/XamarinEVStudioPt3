using Aluracar.Model;
using Aluracar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aluracar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesView : ContentPage
	{
       public Carro Veiculo { get; set; }

        public DetalhesView (Carro veiculo)
		{
			InitializeComponent ();
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
