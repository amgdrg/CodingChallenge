using InterestCodingChallenge.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCodingChallenge.Models
{
    public class Person
    {
        public Person(List<IWallet> wallets)
        {
            Wallets = wallets;
        }

        private List<IWallet> Wallets { get; set; }

        public decimal CalculateInterest(int months)
        {
            return Wallets.Sum(wallet => wallet.CalculateInterest(months));
        }

        public List<decimal> CalculateInterestPerCard(int months)
        {
            List<decimal> interestPerCard = new List<decimal>();
            Wallets.ForEach(wallet => interestPerCard.AddRange(wallet.CalculateInterestPerCard(months)));
            return interestPerCard;
        }

        public List<decimal> CalculateInterestPerWallet(int months)
        {
            List<decimal> interestPerWallet = new List<decimal>();
            Wallets.ForEach(wallet => interestPerWallet.Add(wallet.CalculateInterest(months)));
            return interestPerWallet;
        }
    }
}