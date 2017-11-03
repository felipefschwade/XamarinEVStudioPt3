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
        public ICommand SalvarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }

        private bool editando = false;

        public bool Editando
        {
            get { return editando; }
            set { editando = value; OnPropertyChanged(); }
        }


        public string Nome
        {
            get { return usuario.Nome; }
            set { usuario.Nome = value; OnPropertyChanged(); ((Command)SalvarPerfilCommand).ChangeCanExecute(); }
        }

        public string DataNascimento
        {
            get { return usuario.DataNascimento; }
            set { usuario.DataNascimento = value; OnPropertyChanged(); ((Command)SalvarPerfilCommand).ChangeCanExecute(); }
        }


        private Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            CriaComandos(usuario);
        }

        private void CriaComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });
            this.usuario = usuario;

            SalvarPerfilCommand = new Command(() =>
            {
                Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            }, () =>
            {
                return !String.IsNullOrEmpty(usuario.Nome) && (usuario.Nome.Length > 2)
                       && !String.IsNullOrEmpty(usuario.Telefone) && (usuario.Telefone.Length > 6)
                       && !String.IsNullOrEmpty(usuario.Email) && (usuario.Email.Length > 2)
                       && !String.IsNullOrEmpty(usuario.DataNascimento);
            });

            EditarCommand = new Command(() => 
            {
                Editando = true;
            });

        }

        public string Email
        {
            get { return usuario.Email; }
            set { usuario.Email = value; OnPropertyChanged(); ((Command)SalvarPerfilCommand).ChangeCanExecute(); }
        }

        public string Telefone
        {
            get { return usuario.Telefone; }
            set { usuario.Telefone = value; OnPropertyChanged(); ((Command)SalvarPerfilCommand).ChangeCanExecute(); }
        }
    }
}
