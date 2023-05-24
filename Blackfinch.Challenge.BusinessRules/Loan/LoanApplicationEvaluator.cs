using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.BusinessRules.Loan
{
    public class LoanApplicationEvaluator
    {
        List<ILoanApplicationRule> _rules = new List<ILoanApplicationRule>();

        public LoanApplicationEvaluator()
        { 
            // for this exercise the rules need to be executed in order.
            _rules.Add(new LoanValueInRangeRule());
            _rules.Add(new LoanMoreThanOneMillionRule());
            _rules.Add(new LoanLessThanOneMillionRule());
        }

        public bool Evaluate(LoanApplication loanApplication)
        {
            bool result = false;

            foreach (ILoanApplicationRule rule in _rules)
            {
                result = rule.Passes(loanApplication);

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

    }
}
