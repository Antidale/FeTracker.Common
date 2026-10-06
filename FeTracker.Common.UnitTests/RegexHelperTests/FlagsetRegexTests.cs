using System;
using FeTracker.Common.RegexHelpers;
using FluentAssertions;
using Xunit.Runner.Common;

namespace FeTracker.Common.UnitTests.RegexHelperTests;

public class FlagsetRegexTests
{
    [Fact]
    public void GetWinCondition_Parses_WinCrystal_Correctly()
    {
        var flagset = "O1:quest_forge/random:7,tough_quest/req:6/win:crystal Kmain/summon/moon/nofree:package Pkey Cstandard/nofree/start:cecil,kain,rydia,edward,rosa,yang,palom,porom,cid,edge/no:tellah,fusoya/nekkie/nodupes/hero Tpro/no:j/maxtier:7/mintier:3 Spro Bstandard/alt:gauntlet/whichburn Etoggle/no:jdrops Hrandom Glife/backrow Fweighted Ahero Zvanilla -kit:freedom -noadamants -nocursed -spoon";

        var result = FlagsRegexHelper.GetV4WinCondition(flagset);

        result.Should().Be("crystal");
    }

    [Fact]
    public void GetWinCondition_Parses_WinGame_Correctly()
    {
        var flagset = "O1:quest_forge/random:7,tough_quest/req:6/win:game Kmain/summon/moon/nofree:package Pkey Cstandard/nofree/start:cecil,kain,rydia,edward,rosa,yang,palom,porom,cid,edge/no:tellah,fusoya/nekkie/nodupes/hero Tpro/no:j/maxtier:7/mintier:3 Spro Bstandard/alt:gauntlet/whichburn Etoggle/no:jdrops Hrandom Glife/backrow Fweighted Ahero Zvanilla -kit:freedom -noadamants -nocursed -spoon";

        var result = FlagsRegexHelper.GetV4WinCondition(flagset);

        result.Should().Be("game");
    }

    [Fact]
    public void GetWinCondition_Parses_ONone_Correctly()
    {
        var flagset = "Onone Kmain/summon/moon/nofree Pkey Cstandard/nofree/start:cecil,kain,rydia,edward,rosa,yang,palom,porom,cid,edge/no:tellah,fusoya/j:abilities/nekkie/nodupes/hero Tpro/no:j/mintier:3/maxtier:7 Spro Bstandard/alt:gauntlet/whichburn Etoggle/no:jdrops Glife/backrow -kit:freedom -noadamants -nocursed -spoon";

        var result = FlagsRegexHelper.GetV4WinCondition(flagset);

        result.Should().Be(string.Empty);
    }

    [Fact]
    public void GetRequiredObjectiveNumbers_Parses_PaladinCup_Correctly()
    {
        var flagset = "O1:quest_monsterking/2:quest_ordeals/random:5,tough_quest/random2:2,quest,boss/req:7/hardreq:1,2/win:crystal Kmain/moon/nofree:dwarf/unreliabledark/start:legend Pkey Crelaxed/noearned/distinct:7/start:any/no:fusoya/abilities:j/nekkie/nodupes Twildish/playable/maxtier:7/mintier:3 Sstandard/playable/always:sirens,hrglass,bacchus,starveil,cure3,illusion,coffin Bstandard/alt:gauntlet/whichburn/newscriptstats Etoggle Hrandom Gwarp/life/backrow Fweighted Aagnostic Xzonkbonus:10 Zvanilla -kit:better -kit2:freedom -kit3:hero -noadamants -spoon -smith:super,good,spoilsuper -vanilla:miabs -tweak:yanghp";

        var result = FlagsRegexHelper.GetRequiredObjectiveNumbers(flagset);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo([1, 2]);
    }

    [Fact]
    public void GetRequiredObjectiveCount_Parses_PaladinCup_Correctly()
    {
        var flagset = "O1:quest_monsterking/2:quest_ordeals/random:5,tough_quest/random2:2,quest,boss/req:7/hardreq:1,2/win:crystal Kmain/moon/nofree:dwarf/unreliabledark/start:legend Pkey Crelaxed/noearned/distinct:7/start:any/no:fusoya/abilities:j/nekkie/nodupes Twildish/playable/maxtier:7/mintier:3 Sstandard/playable/always:sirens,hrglass,bacchus,starveil,cure3,illusion,coffin Bstandard/alt:gauntlet/whichburn/newscriptstats Etoggle Hrandom Gwarp/life/backrow Fweighted Aagnostic Xzonkbonus:10 Zvanilla -kit:better -kit2:freedom -kit3:hero -noadamants -spoon -smith:super,good,spoilsuper -vanilla:miabs -tweak:yanghp";

        var result = FlagsRegexHelper.GetRequiredObjectiveCount(flagset);

        result.Should().NotBeNull();
        result.Should().Be("7");
    }

    [Fact]
    public void GetRequiredObjectiveCount_Parses_ReqAll_Correctly()
    {
        var flagset = "O1:quest_monsterking/2:quest_ordeals/random:5,tough_quest/random2:2,quest,boss/req:all/hardreq:1,2/win:crystal Kmain/moon/nofree:dwarf/unreliabledark/start:legend Pkey Crelaxed/noearned/distinct:7/start:any/no:fusoya/abilities:j/nekkie/nodupes Twildish/playable/maxtier:7/mintier:3 Sstandard/playable/always:sirens,hrglass,bacchus,starveil,cure3,illusion,coffin Bstandard/alt:gauntlet/whichburn/newscriptstats Etoggle Hrandom Gwarp/life/backrow Fweighted Aagnostic Xzonkbonus:10 Zvanilla -kit:better -kit2:freedom -kit3:hero -noadamants -spoon -smith:super,good,spoilsuper -vanilla:miabs -tweak:yanghp";

        var result = FlagsRegexHelper.GetRequiredObjectiveCount(flagset);

        result.Should().NotBeNull();
        result.Should().Be("all");
    }
}
