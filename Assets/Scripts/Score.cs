using System;
using UnityEngine;

namespace OneButton
{
    [Serializable]
    public class Score
    {
        public const int DEFAULT = MAX / 2;
        public const int MAX = 100;
        public const float MAXF = MAX;

        private int h = DEFAULT;
        private int m = DEFAULT;
        private int p = DEFAULT;



        public int Happiness { get => h; set => h = Mathf.Min(MAX, value); }
        public int Mental { get => m; set => m = Mathf.Min(MAX, value); }
        public int Physical { get => p; set => p = Mathf.Min(MAX, value); }
        public float PhysicalPercentage => p / MAXF;
        public float MentalPercentage => m / MAXF;
        public float HappinessPercentage => h / MAXF;


        public override string ToString()
        {
            return $"{Happiness} {Mental} {Physical}";
        }
    }
}
