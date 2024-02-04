using FeTracker.Common.Enums;
using FeTracker.Common.Icons;

namespace FeTracker.Common.UnitTests
{
    public class CharacterIconTests
    {
        [Fact]
        public void DkcRejected_TransitionsTo_PecilColor_OnClick()
        {
            var icon = new CharacterIcon(Characters.DarkKnightCecil, IconState.Rejected);

            icon.HandleClick();

            Assert.Equal(icon.FileName, $"{Characters.PaladinCecil}-{IconState.Color}.png");
        }

        [Fact]
        public void PecilRejected_TransitionsTo_DkcGray_OnClick()
        {
            var icon = new CharacterIcon(Characters.PaladinCecil, IconState.Rejected);

            icon.HandleClick();

            Assert.Equal(icon.FileName, $"{Characters.DarkKnightCecil}-{IconState.Gray}.png");
        }

        [Fact]
        public void KydiaRejected_TransitionsTo_AdultRydiaColor_OnClick()
        {
            var icon = new CharacterIcon(Characters.Rydia, IconState.Rejected);

            icon.HandleClick();

            Assert.Equal(icon.FileName, $"{Characters.AdultRydia}-{IconState.Color}.png");
        }

        [Fact]
        public void AdultRydiaRejected_TransitionsTo_KydiaGray_OnClick()
        {
            var icon = new CharacterIcon(Characters.AdultRydia, IconState.Rejected);

            icon.HandleClick();

            Assert.Equal(icon.FileName, $"{Characters.Rydia}-{IconState.Gray}.png");
        }
    }
}