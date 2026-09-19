namespace FeTracker.Sni.Classes;

public static class ObjectiveDictionary
{
    /// <summary>
    /// Given the text from the objectives section in the metadata, converts into some text suitable for displaying to users.
    /// </summary>
    /// <param name="task">The name/description of the 5.0 objecive task from the embedded JSON document</param>
    /// <param name="threshold">The threshold value for objectives like Kill X bosses. Non-threshold objectives should get 0 passed in.</param>
    /// <param name="returnValue">The text to display in the tracker</param>
    /// <returns>A plain language description </returns>
    public static bool TryGetObjectiveText(string task, int threshold, out string returnValue)
    {
        if (ObjectiveLookup.TryGetValue(task, out var lookupValue))
        {
            returnValue = lookupValue is null
                ? task
                : string.Format(lookupValue, threshold);
            return true;
        }

        returnValue = lookupValue ?? task;
        return false;
    }

    public static readonly Dictionary<string, string> ObjectiveLookup = new()
    {
        ["char_cecil"] = "Find Cecil",
        ["char_kain"] = "Find Kain",
        ["char_rydia"] = "Find Rydia",
        ["char_tellah"] = "Find Tellah",
        ["char_edward"] = "Find Edward",
        ["char_rosa"] = "Find Rosa",
        ["char_yang"] = "Find Yang",
        ["char_palom"] = "Find Palom",
        ["char_porom"] = "Find Porom",
        ["char_cid"] = "Find Cid",
        ["char_edge"] = "Find Edge",
        ["char_fusoya"] = "Find FuSoYa",
        ["boss_dmist"] = "Beat D.Mist",
        ["boss_officer"] = "Beat Officer",
        ["boss_octomamm"] = "Beat Octomamm",
        ["boss_antlion"] = "Beat Antlion",
        ["boss_waterhag"] = "Beat Waterhag (boss)",
        ["boss_mombomb"] = "Beat MomBomb",
        ["boss_fabulgauntlet"] = "Beat Fabul Gauntlet",
        ["boss_milon"] = "Beat Milon",
        ["boss_milonz"] = "Beat Milon Z.",
        ["boss_mirrorcecil"] = "Beat D.Knight",
        ["boss_guard"] = "Beat Baron Guards (boss)",
        ["boss_karate"] = "Beat Karate",
        ["boss_baigan"] = "Beat Baigan",
        ["boss_kainazzo"] = "Beat Kainazzo",
        ["boss_darkelf"] = "Beat Dark Elf (dragon form)",
        ["boss_magus"] = "Beat the Magus Sisters",
        ["boss_valvalis"] = "Beat Valvalis",
        ["boss_calbrena"] = "Beat Calbrena",
        ["boss_golbez"] = "Beat Golbez",
        ["boss_lugae"] = "Beat Dr. Lugae",
        ["boss_darkimp"] = "Beat D.Imps (boss)",
        ["boss_kingqueen"] = "Beat K/Q Eblan",
        ["boss_rubicant"] = "Beat Rubicant",
        ["boss_evilwall"] = "Beat EvilWall",
        ["boss_asura"] = "Beat Asura",
        ["boss_leviatan"] = "Beat Leviatan",
        ["boss_odin"] = "Beat Odin",
        ["boss_bahamut"] = "Beat Bahamut",
        ["boss_elements"] = "Beat Elements",
        ["boss_cpu"] = "Beat CPU",
        ["boss_paledim"] = "Beat Pale Dim",
        ["boss_wyvern"] = "Beat Wyvern",
        ["boss_plague"] = "Beat Plague",
        ["boss_dlunar"] = "Beat D.Lunars",
        ["boss_ogopogo"] = "Beat Ogopogo",
        ["quest_mistcave"] = "Defeat Mist Cave Boss",
        ["quest_waterfall"] = "Defeat Waterfall Boss",
        ["quest_antlionnest"] = "Complete Antlion",
        ["quest_hobs"] = "Rescue Hobs Hostage",
        ["quest_fabul"] = "Defend Fabul",
        ["quest_ordeals"] = "Complete Ordeals",
        ["quest_baroninn"] = "Defeat Baron Inn Bosses",
        ["quest_baroncastle"] = "Liberate Baron Castle",
        ["quest_magnes"] = "Complete Magnes",
        ["quest_zot"] = "Complete Zot",
        ["quest_dwarfcastle"] = "Defeat Dwarf Castle Bosses",
        ["quest_lowerbabil"] = "Defeat Lower Bab-il Boss (top)",
        ["quest_falcon"] = "Falcon LAUNCH",
        ["quest_sealedcave"] = "Complete Sealed",
        ["quest_monsterqueen"] = "Defeat Asura Spot",
        ["quest_monsterking"] = "Defeat Levi Spot",
        ["quest_baronbasement"] = "Defeat Odin Spot",
        ["quest_giant"] = "Complete Giant",
        ["quest_cavebahamut"] = "Complete Value",
        ["quest_murasamealtar"] = "Conquer Mura altar",
        ["quest_crystalaltar"] = "Conquer CS altar",
        ["quest_whitealtar"] = "Conquer White Spear altar",
        ["quest_ribbonaltar"] = "Conquer the vanilla Ribbon room",
        ["quest_masamunealtar"] = "Conquer Masa altar",
        ["quest_burnmist"] = "Burn Mist",
        ["quest_curefever"] = "Use Sandruby",
        ["quest_unlocksewer"] = "Unlock Sewer",
        ["quest_music"] = "Play TwinHarp",
        ["quest_toroiatreasury"] = "Open Toroia treasury",
        ["quest_magma"] = "Drop Magma",
        ["quest_supercannon"] = "Destroy the Super Cannon",
        ["quest_unlocksealedcave"] = "Unlock Sealed",
        ["quest_bigwhale"] = "Raise Whale",
        ["quest_traderat"] = "Trade Rat",
        ["quest_forge"] = "Forge",
        ["quest_wakeyang"] = "Wake Yang",
        ["quest_tradepan"] = "Return Pan",
        ["quest_tradepink"] = "Trade Pink",
        ["quest_pass"] = "Unlock Pass Door",
        ["quest_kaipoinn"] = "Complete Package",
        ["internal_dkmatter"] = "Dark Matter Count: {0}",
        ["internal_keyitem"] = "KI Count: {0}",
        ["internal_bossfight"] = "Boss Count: {0}",
        ["internal_character"] = "Character Count: {0}",
        ["internal_chest"] = "Box Count: {0}",
        ["internal_gp"] = "Gil Count: {0}",
        ["objectives_a"] = "Group A, Do: {0}",
        ["objectives_b"] = "Group B, Do: {0}",
        ["objectives_c"] = "Group C, Do: {0}",
        ["objectives_d"] = "Group D, Do: {0}",
        ["objectives_e"] = "Group E, Do: {0}",
    };
}
