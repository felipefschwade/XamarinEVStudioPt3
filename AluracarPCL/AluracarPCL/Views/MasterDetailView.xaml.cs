using AluracarPCL.Model;
using AluracarPCL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluracarPCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario _usuario;
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            Master = new MasterView(usuario);
            _usuario = usuario;
        }
        public MasterDetailView()
        {
            InitializeComponent();
        }
    }
}