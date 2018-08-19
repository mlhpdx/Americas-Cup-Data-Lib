using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public enum BoatStatusEnum
    {
        NotActive = 0,
        Prestart = 1,
        Racing = 2,
        Finished = 3,
        DidNotStart = 4,
        DidNotFinish = 5,
        Disqualified = 6,
        OnCourseSide = 7,
        ClearBehindStart = 8
    }
}
