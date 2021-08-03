using MemoryLeak.Views;
using Windows.UI.Xaml.Controls;

namespace MemoryLeak
{
    public sealed partial class StringListView
    {
        private StringList _stringList;

        public StringListView()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) =>
            {
                if (_stringList == args.NewValue) return;
                _stringList = (StringList) args.NewValue;
                Bindings.Update();
            };
        }

        private void ListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
        }
    }
}
