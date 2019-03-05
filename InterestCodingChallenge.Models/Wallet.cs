using InterestCodingChallenge.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCodingChallenge.Models
{
    public class Wallet : IWallet
    {

        public Wallet(List<ICreditCard> creditCards)
        {
            CreditCards = creditCards;
        }

        private List<ICreditCard> CreditCards;

        public decimal CalculateInterest(int months)
        {
            return CreditCards.Sum(card => card.CalculateInterest(months));
        }

        public List<decimal> CalculateInterestPerCard(int months)
        {
            List<decimal> interestPerCard = new List<decimal>();
            CreditCards.ForEach(card => interestPerCard.Add(card.CalculateInterest(months)));
            return interestPerCard;
        }
    }
}
