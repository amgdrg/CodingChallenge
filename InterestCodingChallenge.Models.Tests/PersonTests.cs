using System;
using System.Collections.Generic;
using InterestCodingChallenge.Models.CreditCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterestCodingChallenge.Models.Interfaces;
using System.Linq;

namespace InterestCodingChallenge.Models.Tests
{
    [TestClass]
    public class PersonTests
    {
        #region TestDataSetup
        private static IEnumerable<object[]> TotalTestCases => new List<object[]>
        {
            /*
             * Person has one wallet with visa, mastercard, and discover
             * All the cards have a blanace of 100 
             * The expected interest is 16
             */
            new object[] 
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new MasterCard(100),
                        new Discover(100)
                    })
                }),
                16.0m
            },
            
            /*
             * Person has two wallets the first with Visa and Discover and the second with a Mastercard
             * All the cards have a balance of 100
             * The expected interest is 16
             */
            new object[] 
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new Discover(100)
                    }),
                    new Wallet (new List<ICreditCard>
                    {
                        new MasterCard(100)
                    })
                }),
                16.0m
            },
            /*
             * Person has one wallet, with MasterCard and Visa
             * All the cards have a balance of 100
             * Expected interest of 15
             */
            new object[]
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new MasterCard(100),
                        new Visa(100)
                    })
                }),
                15.0m
            },
            /*
             * Person has one wallet with Visa and MasterCard
             * All the cards have a balance of 100
             * Expected interest of 15
             */
            new object[]
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new MasterCard(100)
                    })
                }), 
                15.0m
            },
        };

        private static IEnumerable<object[]> PerCardTestCases => new List<object[]>
        {
            /*
             * Person has one wallet with Visa, MasterCard and Discover
             * All the cards have a balance of 100
             * expected per card interest of 10, 5, and 1
             */
            new object[] 
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new MasterCard(100),
                        new Discover(100)
                    })
                }),
                new List<decimal> { 10, 5, 1 }
            }
        };

        private static IEnumerable<object[]> PerWalletTestCases => new List<object[]>
        {
            /*
             * Person has two wallets the first with Visa and Discover and the second with a Mastercard.
             * All the cards have a balance of 100.
             * The expected interest per wallet is 11 and 5
             */
            new object[] 
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new Discover(100)
                    }),
                    new Wallet (new List<ICreditCard>
                    {
                        new MasterCard(100)
                    })
                }), new List<decimal> { 11.0m, 5.0m }
            },
            /*
             * Person has one wallet, with MasterCard and Visa
             * All the cards have a balance of 100
             * Expected interest of 5 and 10
             */
            new object[]
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new MasterCard(100),
                        new Visa(100)
                    })
                }), new List<decimal> { 15.0m }
            },
            /*
             * Person has one wallet, with Visa and MasterCard
             * All the cards have a balance of 100
             * Expected interest of 10 and 5
             */
            new object[]
            {
                new Person(new List<IWallet>
                {
                    new Wallet(new List<ICreditCard>
                    {
                        new Visa(100),
                        new MasterCard(100)
                    })
                }), new List<decimal> { 15.0m }
            },
        };

        #endregion TestDataSetup

        [DataTestMethod]
        [DynamicData (nameof(TotalTestCases))]
        public void CalculateInterest_IntegerMonths_Decimal(Person person, decimal expected)
        {
            //ACT
            var actual = person.CalculateInterest(1);

            //ASSERT
            Assert.AreEqual(actual, expected);
        }

        [DataTestMethod]
        [DynamicData (nameof(PerCardTestCases))]
        public void CalculateInterestPerCard_IntegerMonths_ListOfDecimal(Person person, List<decimal> expected)
        {
            //ACT
            List<decimal> actual = person.CalculateInterestPerCard(1);

            //ASSERT
            Assert.AreEqual(actual.Count, expected.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }

        }

        [DataTestMethod]
        [DynamicData(nameof(PerWalletTestCases))]
        public void CalculateInterestPerWallet_IntegerMonths_ListOfDecimal(Person person, List<decimal> expected)
        {
            //ACT
            List<decimal> actual = person.CalculateInterestPerWallet(1);

            //ASSERT
            Assert.AreEqual(actual.Count, expected.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}
