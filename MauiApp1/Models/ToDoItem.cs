using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.Models;

public class ViewModelBase : INotifyPropertyChanged
{
    public void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
    {
        if (object.Equals(member, value)) return;
        member = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class ToDoItem: ViewModelBase
{
    public int Id { get; set; }
    private string? name;

    public string? Name {
        get { return name; }
        set {
            if (value == name) return;
            SetProperty(ref name, value);
        } 
    }
    public bool Done { get; set; }
}