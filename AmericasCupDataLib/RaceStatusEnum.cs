using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public enum RaceStatusEnum
    {
        NotActive = 0,
        Warning = 1,
        Preparatory = 2, 
        Started = 3,
        Finished = 4, // obsolete
        Retired = 5,  // obsolete
        Abandoned = 6,
        Postponed = 7,
        Terminated = 8,
        RaceTimeNotYetSet = 9,
        Prestart = 10
    }
}
