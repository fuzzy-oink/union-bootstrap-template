using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstiEnFrancois.Common
{
    public static class Extensions
    {
        private static readonly Random Rng = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            var i = list.Count;

            while (i > 0)
            {
                i--;
                var k = Rng.Next(i + 1);
                var value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
        }
    }
}