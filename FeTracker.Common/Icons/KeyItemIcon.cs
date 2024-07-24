using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons
{
    public class KeyItemIcon(KeyItem keyItem, IconState state = IconState.Gray) : IClickable
    {
        public KeyItem Icon { get => keyItem; }
        public string Class { get => keyItem.ToString(); }

        public string Name => keyItem.GetDescription();

        public string FileName { get; private set; } = $"{keyItem}-{state}.png";

        public void SetIconState(IconState iconState)
        {
            //Color/Check/Gray are the only valid states for a KeyItem
            state = iconState switch
            {
                IconState.Color => IconState.Color,
                IconState.Check => IconState.Check,
                _ => IconState.Gray
            };

            FileName = UpdateName();
        }

        public IconState HandleClick()
        {
            state = state switch
            {
                IconState.Gray => IconState.Color,
                IconState.Color => IconState.Check,
                IconState.Check => IconState.Gray,
                _ => IconState.Gray
            };

            FileName = UpdateName();

            return state;
        }

        private string UpdateName() => $"{keyItem}-{state}.png";
    }
}
