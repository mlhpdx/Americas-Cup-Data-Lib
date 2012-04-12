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
        ZeroPenalties = 100
    }
}
