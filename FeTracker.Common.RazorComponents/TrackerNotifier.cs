using Microsoft.AspNetCore.Components;

namespace FeTracker.Common.RazorComponents;

public class TrackerNotifier
{
    private readonly List<EventCallback<StatePropertyChangedArgs>> Callbacks
    = [];

    // Each component will register a callback
    public void RegisterCallback(EventCallback<StatePropertyChangedArgs> callback)
    {
        // Only add if we have not already registered this callback
        if (!Callbacks.Contains(callback))
        {
            Callbacks.Add(callback);
        }
    }

    public void NotifyPropertyChanged(StatePropertyChangedArgs args)
    {
        foreach (var callback in Callbacks)
        {
            // Ignore exceptions due to dangling references
            try
            {
                // Invoke the callback
                callback.InvokeAsync(args);
            }
            catch { }
        }
    }

    public string Version
    {
        get;
        set
        {
            field = value;
            NotifyPropertyChanged(new(nameof(Version), value));
        }
    } = string.Empty;
}