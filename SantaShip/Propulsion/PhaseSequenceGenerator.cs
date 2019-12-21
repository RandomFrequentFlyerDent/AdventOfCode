using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaShip.Propulsion
{
    public class PhaseSequenceGenerator
    {
        public static List<int[]> Generate(int[] phases)
        {
            var sequences = Permutate(phases, phases.Length);
            var result = new List<int[]>();

            foreach (var sequence in sequences)
            {
                result.Add(sequence.ToArray());
            }

            return result;
        }

        private static IEnumerable<IEnumerable<int>> Permutate(IEnumerable<int> phases, int length)
        {
            if (length == 1)
                return phases.Select(phase => new int[] { phase });

            return Permutate(phases, length - 1)
                .SelectMany(list => phases.Where(phase => !list.Contains(phase)),
                    (firstList, secondList) => firstList.Concat(new int[] { secondList }));
        }
    }
}
