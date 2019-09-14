namespace Golmodoth.Client
{
    public struct LevelProgress
    {
        public uint Level { get; }
        public ulong Xp { get; }
        public ulong XpCap { get; }

        public LevelProgress(uint level, ulong xp, ulong xpCap)
        {
            Level = level;
            Xp = xp;
            XpCap = xpCap;
        }

        public override string ToString() => $"Level: {Level} ( {string.Format("{0:n0}", Xp)} / {string.Format("{0:n0}", XpCap)} )";
    }
}
