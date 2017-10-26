using Aluracar.Model;
using Aluracar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aluracar.Views
{
	public partial class ListagemView : ContentPage
    { 
        public ListagemView()
		{
            BindingContext = new ListagemViewModel();
			InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Carro>(this, "VeiculoSelecionado", 
                (carro) => Navigation.PushAsync(new DetalhesView(carro)));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Carro>(this, "VeiculoSelecionado");
        }

    }
}
