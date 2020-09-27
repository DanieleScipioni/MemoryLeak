using Windows.UI.Xaml;

namespace MemoryLeak.Views
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            App.NavigateTo(typeof(ListsPage));
        }
    }
}
