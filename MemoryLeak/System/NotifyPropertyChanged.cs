using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemoryLeak.System
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChangedByName(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T storage, T value, Func<bool> checkLambda, [CallerMemberName] string propertyName = null)
        {
            if (!checkLambda.Invoke()) return false;

            storage = value;
            OnPropertyChangedByName(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChangedByName(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
