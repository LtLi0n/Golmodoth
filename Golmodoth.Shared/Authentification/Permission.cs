using System;

namespace Golmodoth.Shared
{
    [Flags]
    public enum Permission : byte
    {
        None = 0b_0000_0000,
        All = 0b_0000_1111,
        
        Create = 0b_0000_0001,
        Read = 0b_0000_0010,
        Update = 0b_0000_0100,
        Remove = 0b_0000_1000,
    }
}
