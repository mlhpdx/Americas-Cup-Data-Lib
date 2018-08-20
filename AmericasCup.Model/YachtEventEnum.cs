using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public enum YachtEventEnum
    {
        EnteredEarly = 1,
        NotOverStartline = 2,
        OverStartlineEarly = 3,
        ClearBehindStartline = 4,
        YFlagPenalty = 5,
        NoPenalty = 6,
        Disqualified41 = 7,
        Disqualified = 8,
        PenaltyComplete = 9,
        PenaltyOffset = 10,
        Finished = 11,
        YFlagProtestAcknowledgement = 12,
        PenaltyDealtWith = 13,
        DidNotStart = 14,
        DidNotFinish = 15,
        RaceTerminated = 16,
        CourseLimits = 17,
        YachtLimitBoundaryViolation = 18,
        ClearSinglePenalty = 19,
        ClearAtStart = 20,
        NotAFinish = 21,
        OcsPenaltyComplete = 22,
        VmxPenaltyPayoffActive = 23,
        BoatOnBoatPenaltyPayoff = 24,
        YachtNotCompeting = 25,
        YachtCrossedOutsideBoundary = 26,
        YachtClearedInsideBoundary = 27,
        IdOffender = 28,
        UmpOwn = 29,
        UmpInitiated = 30,
        PenaltyServed = 31,
        IdPacer = 32,

        ZeroPenalties = 100,
        OnePenalties = 101,
        TwoPenalties = 102,
        ThreePenalties = 103,
        FourPenalties = 104,
        FivePenalties = 105,
        SixPenalties = 106,
        SevenPenalties = 107,
        EightPenalties = 108,
        NinePenalties = 109,
        TenPenalties = 110 // ten or more
   }
}
