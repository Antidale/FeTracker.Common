using FeTracker.Common.Enums;
using Microsoft.AspNetCore.Components;

namespace FeTracker.Common.RazorComponents;

public class TrackerNotifier
{
    private readonly Dictionary<TrackerEvent, List<EventCallback<StatePropertyChangedArgs>>> Subscriptions = [];

    public void RegisterCallback(TrackerEvent trackerEvent, EventCallback<StatePropertyChangedArgs> callback)
    {
        if (!Subscriptions.TryGetValue(trackerEvent, out List<EventCallback<StatePropertyChangedArgs>>? callbacks))
        {
            callbacks = [];
            Subscriptions[trackerEvent] = callbacks;
        }

        if (!callbacks.Contains(callback))
        {
            callbacks.Add(callback);
        }
    }

    public async Task PublishEvent(TrackerEvent tEvent, StatePropertyChangedArgs args)
    {
        var subs = Subscriptions[tEvent];

        foreach (var callback in subs)
        {
            // Ignore exceptions due to dangling references
            try
            {
                // Invoke the callback
                await callback.InvokeAsync(args);
            }
            catch { }
        }
    }
}
