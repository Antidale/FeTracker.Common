using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons
{
    public class KeyItemIcon(KeyItem keyItem, IconState state = IconState.Gray) : IClickable
    {
        public string Class { get => keyItem.ToString(); }

        public string Name => keyItem.GetDescription();

        public string FileName { get; private set; } = $"{keyItem}-{state}.png";

        public void HandleClick()
        {
            state = state switch
            {
                IconState.Gray => IconState.Color,
                IconState.Color => IconState.Check,
                IconState.Check => IconState.Gray,
                _ => IconState.Gray
            };

            FileName = UpdateName();
        }

        private string UpdateName() => $"{keyItem}-{state}.png";
    }
}
