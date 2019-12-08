using DayFour;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    // However, they do remember a few key facts about the password:
    // - It is a six-digit number.
    // - The value is within the range given in your puzzle input.
    // - Two adjacent digits are the same (like 22 in 122345).
    // - Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
    //
    // Other than the range rule, the following are true:
    // - 111111 meets these criteria(double 11, never decreases).
    // - 223450 does not meet these criteria(decreasing pair of digits 50).
    // - 123789 does not meet these criteria(no double).

    public class DayFourTests
    {
        [TestCase(111111, 0, 11000000)]
        public void PasswordIsSixDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsTrue(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(11111, 0, 11000000)]
        [TestCase(1111111, 0, 11000000)]
        public void PasswordIsNotSixDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsFalse(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(111111, 111110, 111112)]
        [TestCase(111111, 111110, 111111)]
        [TestCase(111111, 111111, 111112)]
        public void PasswordIsWithinRange(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsTrue(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(111111, 111112, 111113)]
        [TestCase(111111, 111109, 111110)]
        public void PasswordIsNotWithinRange(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsFalse(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(112345, 0, 11000000)]
        [TestCase(122345, 0, 11000000)]
        [TestCase(123345, 0, 11000000)]
        [TestCase(123445, 0, 11000000)]
        [TestCase(123455, 0, 11000000)]
        public void PasswordHasTwoEqualAdjacentDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsTrue(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(123789, 0, 11000000)]
        public void PasswordDoesNotHaveTwoEqualAdjacentDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsFalse(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(223450, 0, 11000000)]
        public void PasswordDecreases(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsFalse(PasswordChecker.IsValid(password, rangeStart, rangeEnd, false).Result);
        }

        [TestCase(112233, 0, 11000000)]
        [TestCase(111122, 0, 11000000)]
        public void PasswordHasOnlyTwoAdjacentDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsTrue(PasswordChecker.IsValid(password, rangeStart, rangeEnd, true).Result);
        }

        [TestCase(123444, 0, 11000000)]
        public void PasswordDoesNotHaveOnlyTwoAdjacentDigits(int password, int rangeStart, int rangeEnd)
        {
            Assert.IsFalse(PasswordChecker.IsValid(password, rangeStart, rangeEnd, true).Result);
        }
    }
}
