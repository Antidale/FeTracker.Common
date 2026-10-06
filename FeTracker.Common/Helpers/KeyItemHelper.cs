using System;
using FeTracker.Common.Enums;

namespace FeTracker.Common.Helpers;

public class KeyItemHelper
{
    public static readonly Dictionary<KeyItem, List<string>> RelatedObjectiveLookup = new()
    {
        [KeyItem.Adamant] =
        [
            "Forge",
            "Have Kokkol forge Legend Sword with Adamant"
        ],
        [KeyItem.BaronKey] =
        [
            "Liberate Baron",
            "Defeat Odin Spot",
            "Unlock Sewer",
            "Unlock the sewer with the Baron Key",
            "Liberate Baron Castle",
            "Defeat the Baron Castle basement throne"
        ],
        [KeyItem.Crystal] = [],
        [KeyItem.DarknessCrystal] =
        [
            "Raise Whale",
            "Complete Giant",
            "Complete Value",
            "Clear Mura altar",
            "Clear CS altar",
            "Clear White Spear altar",
            "Clear Ribbon room",
            "Clear Masa altar",
            "Raise the Big Whale",
            "Complete the Giant of Bab-il",
            "Complete Cave Bahamut",
            "Conquer the vanilla Murasame altar",
            "Conquer the vanilla Crystal Sword altar",
            "Conquer the vanilla White Spear altar",
            "Conquer the vanilla Ribbon room",
            "Conquer the vanilla Masamune altar",
        ],
        [KeyItem.EarthCrystal] =
        [
            "Complete the Tower of Zot",
            "Open the Toroia treasury with the Earth Crystal",
            "Complete Zot",
            "Open Toroia treasury"
        ],
        [KeyItem.Hook] =
        [
            "Trade Pink",
            "Trade away the Pink Tail",
            "Trade Rat",
            "Trade away the Rat Tail"
        ],
        [KeyItem.LegendSword] =
        [
            "Forge",
            "Have Kokkol forge Legend Sword with Adamant"
        ],
        [KeyItem.LucaKey] =
        [
            "Complete the Sealed Cave",
            "Unlock the Sealed Cave",
            "Complete Sealed",
            "Unlock Sealed"
        ],
        [KeyItem.MagmaKey] =
        [
            "Drop Magma",
            "Drop the Magma Key into the Agart well"
        ],
        [KeyItem.Package] =
        [
            "Burn village Mist with the Package",
            "Complete Package",
            "Burn Mist",
        ],
        [KeyItem.Pan] =
        [
            "Return Pan", "Wake Yang",
            "Wake Yang with the Pan", "Return the Pan to Yang's wife"
        ],
        [KeyItem.Pass] =
        [
            "Unlock the Pass door in Toroia",
            "Use Pass"
        ],
        [KeyItem.PinkTail] =
        [
            "Trade Pink",
            "Trade away the Pink Tail"
        ],
        [KeyItem.RatTail] =
        [
            "Trade away the Rat Tail",
            "Trade Rat"
        ],
        [KeyItem.SandRuby] =
        [
            "Use Sandruby",
            "Cure the fever with the SandRuby"
        ],
        [KeyItem.Spoon] = [],
        [KeyItem.TowerKey] =
        [
            "Super Cannon",
            "Destroy the Super Cannon"
        ],
        [KeyItem.TwinHarp] =
        [
            "Break the Dark Elf's spell with the TwinHarp",
            "Complete Cave Magnes",
            "Complete Magnes",
            "Play TwinHarp"
        ],
    };
}
