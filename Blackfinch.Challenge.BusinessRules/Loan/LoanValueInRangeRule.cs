using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.BusinessRules.Loan
{
    internal class LoanValueInRangeRule : ILoanApplicationRule
    {
        public bool Passes(LoanApplication loanApplication)
        {
            return (loanApplication.Amount <= 1500000 && loanApplication.Amount >= 100000);
        }
    }
}
