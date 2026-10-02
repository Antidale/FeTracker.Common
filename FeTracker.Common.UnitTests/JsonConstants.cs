using System;

namespace FeTracker.Common.UnitTests.ConverterTests;

public class JsonConstants
{

    public const string MetdataDocIndicatingCompression = """
    {
        "version": "v5.0.0-a.4",
        "seed": "ZN23DRTTLY",
        "framework_version": "v5.0.0",
        "metadata_addr": "0x1FFBC2",
        "metadata_len": "0x436"
    }
    """;

    public const string DecompressedMetadataDoc = """
    {"flags": "OA1:boss_odin/2:boss_golbez/random:3,boss/do_1:dkmatter3/do_2:dkmatter3/do_3:dkmatter3/do_4:dkmatter3/do_5:dkmatter3 OB1:quest_forge/2:quest_tradepink/3:quest_baronbasement/random:2,tough_quest/do_1:dkmatter5/do_2:dkmatter5/do_3:dkmatter5/do_4:dkmatter5/do_5:dkmatter5 OC1:quest_falcon/2:quest_murasamealtar/random:2,tough_quest/do_1:dkmatter7/do_2:dkmatter7/do_3:dkmatter7/do_4:dkmatter7 OD1:quest_giant/do_1:dkmatter10 OE1:collect_dkmatter20/2:collect_dkmatter50/do_1:superweapon/do_all:game Kmain/char/force:magma/start:earthcrystal Pnone Cstandard/distinct:8/start:any/partner:kicheck/no:fusoya/j:abilities/nekkie/wishes Twildish/playable/maxtier:7 Mpro/locations:vanilla/mark Scabins/free Bchaos/no:fabulgauntlet/chaosburn/whichbez Etoggle/noexp Xnokeybonus/objbonus:10/zonkbonus:5 Glife/sylph/backrow Qfastrom/msgspeedfix -kit:better -kit2:freedom -kit3:exit -noadamants -spoon -smith:alt,playable", "binary_flags": "cBQACcPIBAAUwdL1er1cABaSqgAAFQCSbzWazAAXwDAEABohst9stAAWAIAAJ8AIACGlyAAkIAAdAICAQhAABAkAAASgAAoAAAWAAARugAAEEVwABgAECAAccQLBQAAG4RcE1", "objectives": [{"key": "objectives_a", "name": "Objective Group A", "tasks": ["boss_odin", "boss_golbez", "boss_waterhag", "boss_dmist", "boss_valvalis"], "rewards": [{"description": "Complete 1 objective to win 3 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 3 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 3 DkMatter", "req": 3}, {"description": "Complete 4 objectives to win 3 DkMatter", "req": 4}, {"description": "Complete all objectives to win 3 DkMatter", "req": "all"}]}, {"key": "objectives_b", "name": "Objective Group B", "tasks": ["quest_forge", "quest_tradepink", "quest_baronbasement", "quest_crystalaltar", "quest_zot"], "rewards": [{"description": "Complete 1 objective to win 5 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 5 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 5 DkMatter", "req": 3}, {"description": "Complete 4 objectives to win 5 DkMatter", "req": 4}, {"description": "Complete all objectives to win 5 DkMatter", "req": "all"}]}, {"key": "objectives_c", "name": "Objective Group C", "tasks": ["quest_falcon", "quest_murasamealtar", "quest_monsterqueen", "quest_magnes"], "rewards": [{"description": "Complete 1 objective to win 7 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 7 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 7 DkMatter", "req": 3}, {"description": "Complete all objectives to win 7 DkMatter", "req": "all"}]}, {"key": "objectives_d", "name": "Objective Group D", "tasks": ["quest_giant"], "rewards": [{"description": "Complete all objectives to win 10 DkMatter", "req": "all"}]}, {"key": "objectives_e", "name": "Objective Group E", "tasks": [{"objective": "internal_dkmatter", "threshold": 20}, {"objective": "internal_dkmatter", "threshold": 50}], "rewards": [{"description": "Complete 1 objective to win a special weapon", "req": 1}, {"description": "Complete all objectives to win the game", "req": "all"}]}]}
    """;

    public const string GaleswiftMetadataDoc4Dot7 = """
    {"version": "v4.7.0.Gale", "flags": "O1:quest_monsterking/2:quest_ordeals/random:5,tough_quest/random2:2,quest,boss/req:7/hardreq:1,2/win:crystal Kmain/moon/nofree:dwarf/unreliabledark/start:legend Pkey Crelaxed/noearned/distinct:7/start:any/no:fusoya/abilities:j/nekkie/nodupes Twildish/playable/maxtier:7/mintier:3 Sstandard/playable/always:sirens,hrglass,bacchus,starveil,cure3,illusion,coffin Bstandard/alt:gauntlet/whichburn/newscriptstats Etoggle Hrandom Gwarp/life/backrow Fweighted Aagnostic Xzonkbonus:10 Zvanilla -kit:better -kit2:freedom -kit3:hero -noadamants -spoon -smith:super,good,spoilsuper -vanilla:miabs -tweak:yanghp", "binary_flags": "bBAcAAADwqwEAAAAAUCIFAAAAAADIAADAAgQ6KQcAAQAAABAAQAYAAAYIqBAggL4AEAJAIAAAgAkAAEAAAABCwRVIAQAACAAAAAAAAAAAAQ", "seed": "BYM2J1YHQH", "objectives": ["Defeat the king at the Town of Monsters", "Complete Mt. Ordeals", "Liberate Baron Castle", "Defeat the Baron Castle basement throne", "Trade away the Pink Tail", "Complete Cave Magnes", "Trade away the Rat Tail", "Defeat Ogopogo", "Wake Yang with the Pan"]}
    """;

    public const string FourDotSixMetadataDoc = """
    {"version": "v4.6.0", "flags": "O1:quest_forge/2:quest_tradepink/random:1,quest,char/req:all/win:crystal Kmain/summon/moon Pkey Cstandard/nofree/j:abilities Twildish Sstandard Bstandard/alt:gauntlet Etoggle Glife/sylph/backrow -kit:basic -kit2:miab -spoon -smith:super -pushbtojump", "binary_flags": "bBAYAIK0CAAAAABAZHqgAAAAAAAAAABCAAgABJAFwQQEGAAE", "seed": "DUCUWFSGSW", "objectives": ["Have Kokkol forge Legend Sword with Adamant", "Trade away the Pink Tail", "Complete Cave Bahamut"]}
    """;

    public const string AlphaNeverCompressedMetadataDoc = """
    {"version": "v5.0.0-a.3", "flags": "OArandom:5,tough_quest OB1:quest_forge/group_a:4/do_all:crystal Kmain/summon/moon/char/nofree/latedark Pkey Cstandard/nofree/nogiant/distinct:9/start:any/partner:char/no:fusoya/j:abilities/nekkie Twildish/maxtier:7/miabs:pro Sstandard Bmaybe/alt:gauntlet/chaosburn/whichbez Etoggle Xnokeybonus/objbonus:20/kicheckbonus:3/maxmulti:400/bonuses:mul Gwarp/life/sylph/backrow Qfastrom/msgspeedfix -kit:basic -kit2:better -noadamants -spoon -smith:super,playable", "binary_flags": "cBQAKKAEACVIABwQACQgAPHDQAVRJAAEIAAECAAIQAAEMQAEUoAACEAAEPAABYA4o7yBACw", "seed": "8L713VZ79J", "objectives": [{"key": "objectives_a", "name": "Objective Group A", "tasks": ["quest_crystalaltar", "quest_tradepan", "quest_falcon", "quest_baroncastle", "quest_ribbonaltar"], "rewards": []}, {"key": "objectives_b", "name": "Objective Group B", "tasks": [{"group": "objectives_a", "req": 4}, "quest_forge"], "rewards": [{"description": "Complete all objectives to win [crystal]Crystal", "req": "all"}]}]}
    """;
}
