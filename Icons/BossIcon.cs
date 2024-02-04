using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons;

public class BossIcon(BossBattle bossBattle, IconState state = IconState.Gray) : IClickable<BossBattle>
{
    public string Class { get => bossBattle.ToString(); }

    public string FileName { get; private set; } = $"{bossBattle}-{state}.png";

    public string Name => bossBattle.GetDescription();

    public void HandleClick()
    {
        state = state switch
        {
            IconState.Gray => IconState.Color,
            _ => IconState.Gray
        };

        FileName = UpdateName();
    }

    private string UpdateName() => $"{bossBattle}-{state}.png";
}
