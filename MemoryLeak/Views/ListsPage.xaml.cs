using MemoryLeak.System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MemoryLeak.Views
{
    public sealed partial class ListsPage
    {
        private readonly SecondPageViewModel _secondPageViewModel;

        public ListsPage()
        {
            _secondPageViewModel = new SecondPageViewModel();
            InitializeComponent();
            Loaded += async (sender, args) =>
            {
                await _secondPageViewModel.Init();
            };
        }

        private void ListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
        }
    }

    public class SecondPageViewModel : NotifyPropertyChanged
    {
        private List<StringList> _list;
        public List<StringList> List
        {
            get => _list;
            private set => SetProperty(ref _list, value);
        }

        public async Task Init()
        {
            await Task.Delay(500);
            List = new List<StringList>
            {
                new StringList
                {
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a"
                },
                new StringList
                {
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "a", "a", "a"
                }
            };
        }
    }

    public class StringList : List<string>
    {
    }
}