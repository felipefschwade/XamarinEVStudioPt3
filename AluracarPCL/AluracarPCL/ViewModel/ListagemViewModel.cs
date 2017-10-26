using AluracarPCL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AluracarPCL.ViewModel
{
    public class ListagemViewModel : ViewModelBase
    {
        public ObservableCollection<Carro> Veiculos { get; set; }
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private Carro veiculoSelecionado;

        public Carro VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if (value != null) MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado"); }
        }


        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Carro>();
        }

        public async Task GetVeiculosAsync()
        {
            IsBusy = true;
            const string url = "https://aluracar.herokuapp.com/";
            var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            var veiculos = JsonConvert.DeserializeObject<ObservableCollection<Carro>>(result);
            foreach (var item in veiculos)
            {
                Veiculos.Add(item);
            }
            IsBusy = false;
        } 
    }
}
