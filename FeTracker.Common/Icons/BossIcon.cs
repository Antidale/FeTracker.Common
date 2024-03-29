﻿using FeTracker.Common.Enums;
using FeTracker.Common.Extensions;
using FeTracker.Common.Interfaces;

namespace FeTracker.Common.Icons;

public class BossIcon(BossBattle bossBattle, IconState state = IconState.Gray) : IClickable
{
    public string Class { get => bossBattle.ToString(); }

    public string FileName { get; private set; } = $"{bossBattle}-{state}.png";

    public string Name => bossBattle.GetDescription();

    public IconState HandleClick()
    {
        state = state switch
        {
            IconState.Gray => IconState.Color,
            _ => IconState.Gray
        };

        FileName = UpdateName();

        return state;
    }

    private string UpdateName() => $"{bossBattle}-{state}.png";
}
