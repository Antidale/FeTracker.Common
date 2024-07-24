using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons
{
    public class ObjectiveIcon(Objectives objective, IconState iconState = IconState.Gray, int itemCount = 0) : IClickable
    {
        public string Class { get => objective.ToString(); }

        public string Name => objective.GetDescription().Replace("X", itemCount.ToString());

        public string FileName { get; private set; } = "NotComplete.png";

        public IconState HandleClick()
        {
            (iconState, FileName) = iconState switch
            {
                IconState.Gray => (IconState.Check, "Complete.png"),
                _ => (IconState.Gray, "NotComplete.png")
            };

            return iconState;
        }

        public void SetIconState(IconState newState)
        {
            (iconState, FileName) = newState switch
            {
                IconState.Check => (IconState.Check, "Complete.png"),
                _ => (newState, "NotComplete.png")
            };
        }
        
    }
}
