using AluracarPCL.Model;
using AluracarPCL.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluracarPCL.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; OnPropertyChanged(); ((Command)LogarCommand).ChangeCanExecute(); }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; OnPropertyChanged(); ((Command)LogarCommand).ChangeCanExecute(); }
        }

        public ICommand LogarCommand { get; private set; }

        public LoginViewModel()
        {
            LogarCommand = new Command(async () =>
            {
                await LoginService.FazLogin(new Login(Usuario, Senha));
            },
            () => {
                return !string.IsNullOrEmpty(usuario) &&
                       usuario.Length > 3 &&
                       !string.IsNullOrEmpty(senha) &&
                       senha.Length > 3;
            });
            
        }
    }
}
