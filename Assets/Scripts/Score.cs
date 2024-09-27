using System;

namespace OneButton
{
    [Serializable]
    public class Score
    {
        public int h;
        public int m;
        public int p;

        public override string ToString()
        {
            return $"{h} {m} {p}";
        }
    }
}
