using InterestCodingChallenge.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCodingChallenge.Models.CreditCards
{
    public class MasterCard : ICreditCard
    {
        public MasterCard(decimal balance)
        {
            Balance = balance;
        }

        public decimal Balance { get; set; }

        public decimal Interest { get; private set; } = 0.05m;

        public decimal CalculateInterest(int months)
        {
            return Balance * Interest * months;
        }
    }
}
