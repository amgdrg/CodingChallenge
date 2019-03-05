using System;
using System.Collections.Generic;
using InterestCodingChallenge.Models.CreditCards;
using InterestCodingChallenge.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterestCodingChallenge.Models.Tests
{
    [TestClass]
    public class CreditCardTests
    {
        #region TestDataSetup
        private static IEnumerable<object[]> CreditCardTestCases => new List<object[]>
        {
            //Visa credit card with one month interest rate of 10
            new object[]
            {
                new Visa(100),
                10.0m
            },
            //MasterCard credit card with one month interest rate of 5
            new object[]
            {
                new MasterCard(100),
                5.0m
            },
            //Discover credit card with one month interest rate of 1
            new object[]
            {
                new Discover(100),
                1.0m
            }
        };
        #endregion TestDataSetup

        [DataTestMethod]
        [DynamicData(nameof(CreditCardTestCases))]
        public void VisaCalculateInterest_IntegerMonths_Decimal(ICreditCard card, decimal expected)
        {
            //ACT
            var actual = card.CalculateInterest(1);

            //ASSERT
            Assert.AreEqual(actual, expected);
        }
    }
}
