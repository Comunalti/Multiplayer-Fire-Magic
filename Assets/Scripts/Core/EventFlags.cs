using System;

namespace Core
{
    [Flags]
    public enum EventFlags
    {
        None = 0,
        RefreshUi = 1,
        Particles = 2,
        Sound = 4,
        Everything = 7,
    }
}