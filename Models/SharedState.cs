namespace DemoMaui.Models;

public class SharedState
{
    public int CurrentCount { get; private set; }
    public event EventHandler CountChanged;

    public void IncrementCount()
    {
        CurrentCount++;
        CountChanged?.Invoke(this, EventArgs.Empty);
    }
}
