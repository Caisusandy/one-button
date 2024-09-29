using System;

namespace OneButton
{
    [Serializable]
    public class Score
    {
        public const int DEFAULT = 50;

        public int h = DEFAULT;
        public int m = DEFAULT;
        public int p = DEFAULT;

        public override string ToString()
        {
            return $"{h} {m} {p}";
        }
    }
}
