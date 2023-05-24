using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.BusinessRules.Loan
{
    internal class LoanLessThanOneMillionRule : ILoanApplicationRule
    {
        public bool Passes(LoanApplication loanApplication)
        {
            if(loanApplication.Amount > 1000000)
            {
                // loan is > 1000000 so rule does not apply and therefore passes
                return true;
            }

            decimal ltv = (int)loanApplication.Amount / loanApplication.AssetValue;

            //If the LTV is 90% or more, the application must be declined
            if (ltv > 0.9M)
            {
                return false;
            }

            if (ltv <= 0.6M && loanApplication.CreditScore >= 750)
            {
                return true;
            }

            if (ltv <= 0.8M && loanApplication.CreditScore >= 800)
            {
                return true;
            }

            if (ltv <= 0.9M && loanApplication.CreditScore >= 900)
            {
                return true;
            }

            return false;
        }
    }
}
