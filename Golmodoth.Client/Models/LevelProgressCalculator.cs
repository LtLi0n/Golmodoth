using System;
using System.Numerics;

namespace Golmodoth.Client
{
    public class LevelProgressCalculator
    {
        private Func<BigInteger, LevelProgress> _func;

        public LevelProgressCalculator(Func<BigInteger, LevelProgress> func)
        {
            _func = func;
        }

        public LevelProgress GetProgress(BigInteger xp) => _func(xp);

        public static LevelProgress CharacterLevelProgressConverter(string totalXp)
        {
            BigInteger xp = BigInteger.Parse(totalXp);

            uint level = 1;
            ulong xpCap = 100;

            while(xp >= xpCap)
            {
                xp -= xpCap;
                level++;
                xpCap += level * 250;
            }

            return new LevelProgress(level, (ulong)xp, xpCap);
        }
    }
}
