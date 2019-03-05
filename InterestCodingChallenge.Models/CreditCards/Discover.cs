using InterestCodingChallenge.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCodingChallenge.Models.CreditCards
{
    public class Discover : ICreditCard
    {
        public Discover(decimal balance)
        {
            Balance = balance;
        }

        public decimal Balance { get; set; }

        public decimal Interest { get; private set; } = 0.01m;

        public decimal CalculateInterest(int months)
        {
            return Balance * Interest * months;
        }
    }
}
