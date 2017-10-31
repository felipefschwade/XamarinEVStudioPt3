using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluracarPCL.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluracarPCL.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        public ICommand EditarPerfilCommand { get; private set; }

        public string Nome
        {
            get { return usuario.Nome; }
            set { usuario.Nome = value; OnPropertyChanged(); }
        }

        private Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() => 
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });
            this.usuario = usuario;
        }

        public string Email
        {
            get { return usuario.Email; }
            set { usuario.Email = value; OnPropertyChanged(); }
        }
    }
}
