using Aluracar.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Aluracar.ViewModel
{
    public class ListagemViewModel : ViewModelBase
    {
        public IList<Carro> Veiculos { get; set; }

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
            Veiculos = new List<Carro>();
        }

    }
}
