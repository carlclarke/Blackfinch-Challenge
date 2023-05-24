using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.BusinessRules.Loan
{
    internal class LoanMoreThanOneMillionRule : ILoanApplicationRule
    {
        public bool Passes(LoanApplication loanApplication)
        {
            if(loanApplication.Amount < 1000000)
            {
                // loan is < 1000000 so rule does not apply and therefore passes
                return true;
            }

            decimal ltv = (int)loanApplication.Amount / loanApplication.AssetValue;

            return (ltv <= 60M && loanApplication.CreditScore >= 950);
        }
    }
}
