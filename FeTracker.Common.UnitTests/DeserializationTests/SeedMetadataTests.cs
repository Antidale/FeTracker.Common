using System.Text.Json;
using FeTracker.Common.UnitTests.ConverterTests;
using FeTracker.Sni.Models;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.DeserializationTests;

public class SeedMetadataTests
{
    [Fact]
    public void IsTrue()
    {
        Assert.True(true);
    }

    [Fact]
    public void DecompressedMetadataDeserializesAsSeedMetadata()
    {
        var result = JsonSerializer.Deserialize<SeedMetadata>(JsonConstants.DecompressedMetadataDoc);

        result.Should().NotBeNull();
        result.BinaryFlags.Should().Be("""
        cBQACcPIBAAUwdL1er1cABaSqgAAFQCSbzWazAAXwDAEABohst9stAAWAIAAJ8AIACGlyAAkIAAdAICAQhAABAkAAASgAAoAAAWAAARugAAEEVwABgAECAAccQLBQAAG4RcE1
        """);

        result.Flags.Should().Be("""
        OA1:boss_odin/2:boss_golbez/random:3,boss/do_1:dkmatter3/do_2:dkmatter3/do_3:dkmatter3/do_4:dkmatter3/do_5:dkmatter3 OB1:quest_forge/2:quest_tradepink/3:quest_baronbasement/random:2,tough_quest/do_1:dkmatter5/do_2:dkmatter5/do_3:dkmatter5/do_4:dkmatter5/do_5:dkmatter5 OC1:quest_falcon/2:quest_murasamealtar/random:2,tough_quest/do_1:dkmatter7/do_2:dkmatter7/do_3:dkmatter7/do_4:dkmatter7 OD1:quest_giant/do_1:dkmatter10 OE1:collect_dkmatter20/2:collect_dkmatter50/do_1:superweapon/do_all:game Kmain/char/force:magma/start:earthcrystal Pnone Cstandard/distinct:8/start:any/partner:kicheck/no:fusoya/j:abilities/nekkie/wishes Twildish/playable/maxtier:7 Mpro/locations:vanilla/mark Scabins/free Bchaos/no:fabulgauntlet/chaosburn/whichbez Etoggle/noexp Xnokeybonus/objbonus:10/zonkbonus:5 Glife/sylph/backrow Qfastrom/msgspeedfix -kit:better -kit2:freedom -kit3:exit -noadamants -spoon -smith:alt,playable
        """);

        result.Objectives.Should().Be("""
[{"key": "objectives_a", "name": "Objective Group A", "tasks": ["boss_odin", "boss_golbez", "boss_waterhag", "boss_dmist", "boss_valvalis"], "rewards": [{"description": "Complete 1 objective to win 3 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 3 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 3 DkMatter", "req": 3}, {"description": "Complete 4 objectives to win 3 DkMatter", "req": 4}, {"description": "Complete all objectives to win 3 DkMatter", "req": "all"}]}, {"key": "objectives_b", "name": "Objective Group B", "tasks": ["quest_forge", "quest_tradepink", "quest_baronbasement", "quest_crystalaltar", "quest_zot"], "rewards": [{"description": "Complete 1 objective to win 5 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 5 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 5 DkMatter", "req": 3}, {"description": "Complete 4 objectives to win 5 DkMatter", "req": 4}, {"description": "Complete all objectives to win 5 DkMatter", "req": "all"}]}, {"key": "objectives_c", "name": "Objective Group C", "tasks": ["quest_falcon", "quest_murasamealtar", "quest_monsterqueen", "quest_magnes"], "rewards": [{"description": "Complete 1 objective to win 7 DkMatter", "req": 1}, {"description": "Complete 2 objectives to win 7 DkMatter", "req": 2}, {"description": "Complete 3 objectives to win 7 DkMatter", "req": 3}, {"description": "Complete all objectives to win 7 DkMatter", "req": "all"}]}, {"key": "objectives_d", "name": "Objective Group D", "tasks": ["quest_giant"], "rewards": [{"description": "Complete all objectives to win 10 DkMatter", "req": "all"}]}, {"key": "objectives_e", "name": "Objective Group E", "tasks": [{"objective": "internal_dkmatter", "threshold": 20}, {"objective": "internal_dkmatter", "threshold": 50}], "rewards": [{"description": "Complete 1 objective to win a special weapon", "req": 1}, {"description": "Complete all objectives to win the game", "req": "all"}]}]
""");
    }

    [Fact]
    public void DocIndicatingCompressionDeserializesAsSeedMetadata()
    {

        var result = JsonSerializer.Deserialize<SeedMetadata>(JsonConstants.MetdataDocIndicatingCompression);

        result.Should().NotBeNull();
        result.Flags.Should().BeEmpty();
        result.Objectives.Should().BeEmpty();
        result.BinaryFlags.Should().BeEmpty();
        result.Seed.Should().Be("ZN23DRTTLY");
        result.MetadataAddr.Should().Be(0x1FFBC2);
        result.MetadataLen.Should().Be(0x436);
        result.Version.Should().Be("v5.0.0-a.4");
        result.FrameworkVersion.Should().Be("v5.0.0");

    }

    [Fact]
    public void AlphaNeverCompressedMetadataDocDeserializesCorrectly()
    {
        var result = JsonSerializer.Deserialize<SeedMetadata>(JsonConstants.AlphaNeverCompressedMetadataDoc);

        result.Should().NotBeNull();
        result.Seed.Should().Be("8L713VZ79J");
        result.Version.Should().Be("v5.0.0-a.3");
        result.Flags.Should().Be("OArandom:5,tough_quest OB1:quest_forge/group_a:4/do_all:crystal Kmain/summon/moon/char/nofree/latedark Pkey Cstandard/nofree/nogiant/distinct:9/start:any/partner:char/no:fusoya/j:abilities/nekkie Twildish/maxtier:7/miabs:pro Sstandard Bmaybe/alt:gauntlet/chaosburn/whichbez Etoggle Xnokeybonus/objbonus:20/kicheckbonus:3/maxmulti:400/bonuses:mul Gwarp/life/sylph/backrow Qfastrom/msgspeedfix -kit:basic -kit2:better -noadamants -spoon -smith:super,playable");
        result.Objectives.Should().Contain("Complete all objectives to win [crystal]Crystal");
        result.FrameworkVersion.Should().BeEmpty();
        result.MetadataLen.Should().Be(0);
        result.MetadataAddr.Should().Be(0);
    }

    [Fact]
    public void FourDotSixMetadataDoc_Should_DeserializeCorrectly()
    {
        var result = JsonSerializer.Deserialize<SeedMetadata>(JsonConstants.FourDotSixMetadataDoc);

        result.Should().NotBeNull();
        result.Seed.Should().Be("DUCUWFSGSW");
        result.Version.Should().Be("v4.6.0");
        result.Flags.Should().Be("O1:quest_forge/2:quest_tradepink/random:1,quest,char/req:all/win:crystal Kmain/summon/moon Pkey Cstandard/nofree/j:abilities Twildish Sstandard Bstandard/alt:gauntlet Etoggle Glife/sylph/backrow -kit:basic -kit2:miab -spoon -smith:super -pushbtojump");
        result.BinaryFlags.Should().Be("bBAYAIK0CAAAAABAZHqgAAAAAAAAAABCAAgABJAFwQQEGAAE");
        result.Objectives.Should().Be("""
        ["Have Kokkol forge Legend Sword with Adamant", "Trade away the Pink Tail", "Complete Cave Bahamut"]
        """);
        result.FrameworkVersion.Should().BeEmpty();
        result.MetadataLen.Should().Be(0);
        result.MetadataAddr.Should().Be(0);
    }

    [Fact]
    public void GaleswiftMetadataDoc4Dot7_Should_DeserializeCorrectly()
    {
        var result = JsonSerializer.Deserialize<SeedMetadata>(JsonConstants.GaleswiftMetadataDoc4Dot7);

        result.Should().NotBeNull();
        result.Seed.Should().Be("BYM2J1YHQH");
        result.Version.Should().Be("v4.7.0.Gale");
        result.Flags.Should().Be("O1:quest_monsterking/2:quest_ordeals/random:5,tough_quest/random2:2,quest,boss/req:7/hardreq:1,2/win:crystal Kmain/moon/nofree:dwarf/unreliabledark/start:legend Pkey Crelaxed/noearned/distinct:7/start:any/no:fusoya/abilities:j/nekkie/nodupes Twildish/playable/maxtier:7/mintier:3 Sstandard/playable/always:sirens,hrglass,bacchus,starveil,cure3,illusion,coffin Bstandard/alt:gauntlet/whichburn/newscriptstats Etoggle Hrandom Gwarp/life/backrow Fweighted Aagnostic Xzonkbonus:10 Zvanilla -kit:better -kit2:freedom -kit3:hero -noadamants -spoon -smith:super,good,spoilsuper -vanilla:miabs -tweak:yanghp");
        result.BinaryFlags.Should().Be("bBAcAAADwqwEAAAAAUCIFAAAAAADIAADAAgQ6KQcAAQAAABAAQAYAAAYIqBAggL4AEAJAIAAAgAkAAEAAAABCwRVIAQAACAAAAAAAAAAAAQ");
        result.Objectives.Should().Be("""
        ["Defeat the king at the Town of Monsters", "Complete Mt. Ordeals", "Liberate Baron Castle", "Defeat the Baron Castle basement throne", "Trade away the Pink Tail", "Complete Cave Magnes", "Trade away the Rat Tail", "Defeat Ogopogo", "Wake Yang with the Pan"]
        """);
        result.FrameworkVersion.Should().BeEmpty();
        result.MetadataLen.Should().Be(0);
        result.MetadataAddr.Should().Be(0);
    }

}
