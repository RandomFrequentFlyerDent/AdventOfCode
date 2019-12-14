using System;
using System.Linq;

namespace SantaShip
{
    public class SecureContainer
    {
        public bool IsValid(int password, bool maxTwoAdjacent)
        {
            if (IsIncorrectLength(password))
                return false;

            if (Decreases(password))
                return false;

            if (DoesNotHaveTwoAdjacentSameDigits(password, maxTwoAdjacent))
                return false;

            return true;
        }

        private bool IsIncorrectLength(int password)
        {
            return password.ToString().Length != 6;
        }

        private bool Decreases(int password)
        {
            var convertedPassword = password
                .ToString()
                .ToArray()
                .Select(c => Int16.Parse(c.ToString()))
                .ToArray();

            for (int i = 0; i < convertedPassword.Length - 1; i++)
            {
                if (convertedPassword[i + 1] < convertedPassword[i])
                    return true;
            }

            return false;
        }

        private bool DoesNotHaveTwoAdjacentSameDigits(int password, bool maxTwoAdjacent)
        {
            var convertedPassword = password.ToString();

            var multipleOccurences = convertedPassword
                .GroupBy(letter => letter, letter => letter.ToString().Count())
                .ToDictionary(group => group.Key, group => group.ToArray())
                .Where(dict => dict.Value.Length > 1)
                .Select(dict => dict.Key.ToString())
                .ToList();

            if (multipleOccurences.Count() == 0)
                return true;

            var hasTwoAdjacent = false;
            foreach (var doubleDigit in multipleOccurences)
            {
                if (maxTwoAdjacent && convertedPassword.Contains(doubleDigit + doubleDigit + doubleDigit))
                    continue;

                hasTwoAdjacent = convertedPassword.Contains(doubleDigit + doubleDigit);
            }

            return !hasTwoAdjacent;
        }
    }
}
