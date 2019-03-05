using System;
using System.Collections.Generic;
using InterestCodingChallenge.Models.CreditCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterestCodingChallenge.Models.Interfaces;

namespace InterestCodingChallenge.Models.Tests
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void CalculateInterest_IntegerMonths_Decimal()
        {
            //ARRANGE
            var visaCard = new Visa(100);
            var masterCard = new MasterCard(100);
            var discover = new Discover(100);
            var wallet = new Wallet(new List<ICreditCard> { visaCard, masterCard, discover} );

            //ACT
            var actual = wallet.CalculateInterest(1);

            //ASSERT
            Assert.AreEqual(actual, 16.0m);
        }

        [TestMethod]
        public void CalculateInterestPerCard_IntegerMonths_ListOfDecimal()
        {
            //ARRANGE
            var visaCard = new Visa(100);
            var masterCard = new MasterCard(100);
            var discover = new Discover(100);
            var wallet = new Wallet(new List<ICreditCard> { visaCard, masterCard, discover });
            var expected = new List<decimal> { 10.0m, 5.0m, 1.0m };

            //ACT
            var actual = wallet.CalculateInterestPerCard(1);

            //ASSERT
            Assert.AreEqual(actual.Count, expected.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}