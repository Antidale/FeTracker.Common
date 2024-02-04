using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons
{
    public class ObjectiveIcon(Objectives objective, IconState iconState = IconState.Gray, int itemCount = 0) : IClickable<Objectives>
    {
        public string Class { get => objective.ToString(); }

        public string Name => objective.GetDescription().Replace("X", itemCount.ToString());

        public string FileName { get; private set; } = "NotComplete.png";

        public void HandleClick()
        {
            (iconState, FileName) = iconState switch
            {
                IconState.Gray => (IconState.Color, "Complete.png"),
                _ => (IconState.Gray, "NotComplete.png")
            };
        }
    }
}
