using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCodingChallenge.Models.Interfaces
{
    public interface IWallet
    {
        List<decimal> CalculateInterestPerCard(int months);
        decimal CalculateInterest(int months);
    }
}
