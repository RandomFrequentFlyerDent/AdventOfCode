using System;
using System.Linq;
using System.Threading.Tasks;

namespace DayFour
{
    public class PasswordChecker
    {
        public static async Task<bool> IsValid(int password, int rangeStart, int rangeEnd, bool extraRequirement)
        {
            var valid = await Task.Run(() =>
            {
                if (!IsCorrectLength(password))
                    return false;

                if (!IsWithinRange(password, rangeStart, rangeEnd))
                    return false;

                if (!HasTwoAdjacentSameDigits(password, extraRequirement))
                    return false;

                return DoesNotDecrease(password);
            })
                .ConfigureAwait(false);

            return valid;
        }

        private static bool IsCorrectLength(int password)
        {
            return password.ToString().Length == 6;
        }

        private static bool IsWithinRange(int password, int rangeStart, int rangeEnd)
        {
            var range = Enumerable.Range(rangeStart, (rangeEnd + 1) - rangeStart);
            if (range.Contains(password))
                return true;

            return false;
        }

        private static bool HasTwoAdjacentSameDigits(int password, bool extraRequirement)
        {
            var convertedPassword = password.ToString();

            var multipleOccurences = convertedPassword
                .GroupBy(letter => letter, letter => letter.ToString().Count())
                .ToDictionary(group => group.Key, group => group.ToArray())
                .Where(dict => dict.Value.Length > 1)
                .Select(dict => dict.Key.ToString())
                .ToList();

            if (multipleOccurences.Count() == 0)
                return false;

            foreach (var doubleDigit in multipleOccurences)
            {
                var exists = convertedPassword.Contains(doubleDigit + doubleDigit);

                if (extraRequirement)
                    exists = exists && !convertedPassword.Contains(doubleDigit + doubleDigit + doubleDigit);

                if (exists)
                    return true;
            }

            return false;
        }

        private static bool DoesNotDecrease(int password)
        {
            var convertedPassword = password
                .ToString()
                .ToArray()
                .Select(letter => Int16.Parse(letter.ToString()))
                .ToArray();

            for (int i = 0; i < convertedPassword.Length -1; i++)
            {
                if (convertedPassword[i + 1] < convertedPassword[i])
                    return false;
            }

            return true;
        }
    }

}
