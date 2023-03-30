using SQLite;

namespace MauiApp1.Models;

public class ToDoItemDatabase
{
    SQLiteAsyncConnection Database;

    async Task Init()
    {
        if(Database is not null)
        {
            return;
        }
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<ToDoItem>();
    }

    public async Task<List<ToDoItem>> GetItemsAsync()
    {
        await Init();
        var items = await Database.Table<ToDoItem>().ToListAsync();
        return items;
    }

    public async Task<List<ToDoItem>> GetItemsNotDoneAsync()
    {
        await Init();
        return await Database.Table<ToDoItem>().Where(x => x.Done).ToListAsync();
    }

    public async Task<int> SaveItemAsync(ToDoItem item)
    {
        await Init();
        if(item.Id != 0)
        {
            return await Database.UpdateAsync(item);
        } else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(ToDoItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

}
