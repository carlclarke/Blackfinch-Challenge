using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.BusinessRules.Loan
{
    internal interface ILoanApplicationRule
    {
        bool Passes(LoanApplication loanApplication);
    }
}
