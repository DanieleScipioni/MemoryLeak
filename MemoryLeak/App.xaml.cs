using MemoryLeak.Views;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MemoryLeak
{
    sealed partial class App
    {
        private readonly Stack<Type> _pageStack;

        public App()
        {
            _pageStack = new Stack<Type>();
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Window currentWindow = Window.Current;
            if (currentWindow.Content == null)
            {
                SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
                systemNavigationManager.BackRequested += (sender, eventArgs) =>
                {
                    if (!CanGoBack) return;
                    GoBack();
                };
                systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Disabled;
                NavigateTo(typeof(MainPage));
            }
            currentWindow.Activate();
        }

        public static void NavigateTo(Type type)
        {
            var app = ((App) Current);
            app._pageStack.Push(type);
            app.ChangeWindowContent(type);
        }

        private bool CanGoBack => _pageStack.Count > 1;

        public void GoBack()
        {
            _pageStack.Pop();
            Type type = _pageStack.Peek();
            ChangeWindowContent(type);
        }

        private void ChangeWindowContent(Type type)
        {
            Window.Current.Content = (FrameworkElement)Activator.CreateInstance(type);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.AppViewBackButtonVisibility = CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Disabled;
        }
    }
}
