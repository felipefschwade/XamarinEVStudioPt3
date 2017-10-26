using AluracarPCL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluracarPCL.ViewModel
{
    public class DetalhesViewModel : ViewModelBase
    {
        public DetalhesViewModel(Carro veiculo)
        {
            Veiculo = veiculo;
            ProximoCommand = new Command(() => MessagingCenter.Send(Veiculo, "Proximo"));
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            base.OnPropertyChanged(nameof(ValorTotal));
        }
        public ICommand ProximoCommand { get; set; }
        public Carro Veiculo { get; set; }

        public bool TemAbs
        {
            get { return Veiculo.TemAbs; }
            set
            {
                Veiculo.TemAbs = value;
                OnPropertyChanged();
            }
        }

        public bool TemAr
        {
            get { return Veiculo.TemAr; }
            set
            {
                Veiculo.TemAr = value;
                OnPropertyChanged();
            }
        }

        public bool TemMp3
        {
            get { return Veiculo.TemMp3; }
            set
            {
                Veiculo.TemMp3 = value;
                OnPropertyChanged();
            }
        }

        public string TextoAbs
        {
            get { return String.Format("Freio ABS - R$ {0}", Veiculo.ABS); }
        }
        public string TextoArCond
        {
            get { return String.Format("Ar Condicionado - R$ {0}", Veiculo.AR_COND); }
        }
        public string TextoMp3
        {
            get { return String.Format("Ar Condicionado - R$ {0}", Veiculo.MP3); }
        }

        public string ValorTotal
        {
            get { return Veiculo.ValorTotalFormatado; }
        }
    }
}
