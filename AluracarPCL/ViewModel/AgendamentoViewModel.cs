using Aluracar.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aluracar.ViewModel
{
    public class AgendamentoViewModel
    {
        public AgendamentoViewModel(Carro veiculo)
        {
            Agendamento = new Agendamento(veiculo);
            AgendarCommand = new Command(() => 
            {
                MessagingCenter.Send(Agendamento, "Agendamento");
            });
        }

        public ICommand AgendarCommand { get; set; }

        public Agendamento Agendamento { get; set; }
    }
}
