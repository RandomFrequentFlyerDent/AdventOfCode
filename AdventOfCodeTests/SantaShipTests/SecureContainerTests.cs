using NUnit.Framework;
using SantaShip;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCodeTests.SantaShipTests
{
    public class SecureContainerTests
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

        [TestCase(111111)]
        public void PasswordIsSixDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsTrue(secureContainer.IsValid(password, maxTwoAdjacent: false));
        }

        [TestCase(11111)]
        [TestCase(1111111)]
        public void PasswordIsNotSixDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsFalse(secureContainer.IsValid(password, maxTwoAdjacent: false));
        }

        [TestCase(112345)]
        [TestCase(122345)]
        [TestCase(123345)]
        [TestCase(123445)]
        [TestCase(123455)]
        public void PasswordHasTwoEqualAdjacentDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsTrue(secureContainer.IsValid(password, maxTwoAdjacent: false));
        }

        [TestCase(123789)]
        public void PasswordDoesNotHaveTwoEqualAdjacentDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsFalse(secureContainer.IsValid(password, maxTwoAdjacent: false));
        }

        [TestCase(223450)]
        public void PasswordDecreases(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsFalse(secureContainer.IsValid(password, maxTwoAdjacent: false));
        }

        [TestCase(112233)]
        [TestCase(111122)]
        public void PasswordHasOnlyTwoAdjacentDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsTrue(secureContainer.IsValid(password, maxTwoAdjacent: true));
        }

        [TestCase(123444)]
        public void PasswordDoesNotHaveOnlyTwoAdjacentDigits(int password)
        {
            var secureContainer = new SecureContainer();
            Assert.IsFalse(secureContainer.IsValid(password, maxTwoAdjacent: true));
        }
    }
}
