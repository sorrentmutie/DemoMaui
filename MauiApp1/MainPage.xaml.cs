using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly ToDoItemDatabase database;
        int count = 0;

        public ObservableCollection<ToDoItem> Items { get; set; }
            = new ObservableCollection<ToDoItem>();

        public MainPage(ToDoItemDatabase database)
        {
            InitializeComponent();
            this.database = database;
            this.BindingContext = this;
            Task.Run(async () =>
            {
                var data = await database.GetItemsAsync();
                await database.GetItemsAsync();
                Items.Clear();
                foreach (var item in data)
                {
                    Items.Add(item);
                }
            });
            
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await database.SaveItemAsync(new ToDoItem { Name = Guid.NewGuid().ToString() });

            var data = await database.GetItemsAsync();
            Items.Clear();
            foreach (var item in data)
            {
                Items.Add(item);
            }

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}