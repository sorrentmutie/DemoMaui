

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoMaui.Helpers
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        {
            if (object.Equals(member, value)) return;
            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
