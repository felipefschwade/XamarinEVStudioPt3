using AluracarPCL.Model;
using AluracarPCL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<LoginException>(this, "LoginFailed", async (exc) => 
            {
                await DisplayAlert("Login", exc.Message, "Ok");
                BindingContext = new LoginViewModel();
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<LoginException>(this, "LoginFailed");
            base.OnDisappearing();
        }
    }
}