using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons
{
    public class CharacterIcon(Characters character, IconState iconState = IconState.Gray) : IClickable<Characters>
    {
        public string Class { get => character.ToString(); }

        public string FileName { get; private set; } = $"{character}-{iconState}.png";

        public string Name => character.GetDescription();

        public void HandleClick()
        {
            (character, iconState) = (character, iconState) switch
            {
                (Characters.DarkKnightCecil, IconState.Rejected) => (Characters.PaladinCecil, IconState.Color),
                (Characters.PaladinCecil, IconState.Rejected) => (Characters.DarkKnightCecil, IconState.Gray),
                (Characters.Rydia, IconState.Rejected) => (Characters.AdultRydia, IconState.Color),
                (Characters.AdultRydia, IconState.Rejected) => (Characters.Rydia, IconState.Gray),
                (_, IconState.Gray) => (character, IconState.Color),
                (_, IconState.Color) => (character, IconState.Rejected),
                (_, IconState.Rejected) => (character, IconState.Gray),
                (_, _) => (character, IconState.Gray),
            };

            FileName = UpdateName();
        }

        private string UpdateName() => $"{character}-{iconState}.png";
    }
}
