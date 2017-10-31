using AluracarPCL.Model;
using AluracarPCL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            BindingContext = new MasterViewModel(usuario);
            InitializeComponent();
        }
        public MasterView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (usuario) => {
                this.CurrentPage = this.Children[1];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            
        }
    }
}