using FeTracker.Common.Enums;
using FeTracker.Common.Icons;
using FluentAssertions;

namespace FeTracker.Common.UnitTests
{
    public class CharacterIconTests
    {
        [Fact]
        public void DkcRejected_TransitionsTo_PecilColor_OnClick()
        {
            var icon = new CharacterIcon(Characters.DarkKnightCecil, IconState.Rejected);

            icon.HandleClick();

            icon.FileName.Should().BeEquivalentTo($"{Characters.PaladinCecil}-{IconState.Color}.png");
            
        }

        [Fact]
        public void PecilRejected_TransitionsTo_DkcGray_OnClick()
        {
            var icon = new CharacterIcon(Characters.PaladinCecil, IconState.Rejected);

            icon.HandleClick();

            icon.FileName.Should().BeEquivalentTo($"{Characters.DarkKnightCecil}-{IconState.Gray}.png");
        }

        [Fact]
        public void KydiaRejected_TransitionsTo_AdultRydiaColor_OnClick()
        {
            var icon = new CharacterIcon(Characters.Rydia, IconState.Rejected);

            icon.HandleClick();

            icon.FileName.Should().BeEquivalentTo($"{Characters.AdultRydia}-{IconState.Color}.png");
        }

        [Fact]
        public void AdultRydiaRejected_TransitionsTo_KydiaGray_OnClick()
        {
            var icon = new CharacterIcon(Characters.AdultRydia, IconState.Rejected);

            icon.HandleClick();

            icon.FileName.Should().BeEquivalentTo($"{Characters.Rydia}-{IconState.Gray}.png");
        }
    }
}