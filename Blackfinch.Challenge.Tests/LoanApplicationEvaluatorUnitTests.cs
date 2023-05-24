using Blackfinch.Challenge.BusinessRules.Loan;
using Blackfinch.Challenge.Dto.Loan;

namespace Blackfinch.Challenge.Tests
{
    public class Tests
    {
        LoanApplicationEvaluator _loanEvaluator;

        [SetUp]
        public void Setup()
        {
            _loanEvaluator = new LoanApplicationEvaluator();
        }

        //If the value of the loan is more than £1.5 million or less than £100,000 then the application must be declined

        [Test]
        public void WhenLoanMoreThan_1500000_ShouldFail()
        {
            LoanApplication a = new LoanApplication{ Amount = 1500001, AssetValue = 0, CreditScore = 0 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenLoanLessThan_100000_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 99999, AssetValue = 0, CreditScore = 0 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //If the value of the loan is £1 million or more then the LTV must be 60% or less and the credit score of the applicant must be 950 or more

        [Test]
        public void WhenInRange_and_Over_1000000_LTVMoreThan60PC_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 1200000, AssetValue = 1999999, CreditScore = 0 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenInRange_and_Over_1000000_LTVLessThanOrEqualTo60PC_AndCreditScoreGreaterThanOrEqualTo_950_ShouldPass()
        {
            LoanApplication a = new LoanApplication { Amount = 1200000, AssetValue = 2000000, CreditScore = 950 };

            var expected = true;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenInRange_and_Over_1000000_LTVLessThanOrEqualTo60PC_AndCreditScoreEqualTo_900_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 1200000, AssetValue = 2000000, CreditScore = 900 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);
            Assert.That(actual, Is.EqualTo(expected));
        }

        //If the value of the loan is less than £1 million then the following rules apply:
        //If the LTV is less than 60%, the credit score of the applicant must be 750 or more

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo60PC_AndCreditScoreEqualTo_750_ShouldPass()
        {
            LoanApplication a = new LoanApplication { Amount = 120000, AssetValue = 200000, CreditScore = 750 };

            var expected = true;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo60PC_AndCreditScoreEqualTo_749_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 120000, AssetValue = 200000, CreditScore = 749 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //If the LTV is less than 80%, the credit score of the applicant must be 800 or more

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo80PC_AndCreditScoreEqualTo_800_ShouldPass()
        {
            LoanApplication a = new LoanApplication { Amount = 160000, AssetValue = 200000, CreditScore = 800 };

            var expected = true;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo80PC_AndCreditScoreEqualTo_799_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 160000, AssetValue = 200000, CreditScore = 790 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //If the LTV is less than 90%, the credit score of the applicant must be 900 or more

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo90PC_AndCreditScoreEqualTo_900_ShouldPass()
        {
            LoanApplication a = new LoanApplication { Amount = 180000, AssetValue = 200000, CreditScore = 900 };

            var expected = true;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenInRange_and_Under_1000000_LTVLessThanOrEqualTo90PC_AndCreditScoreEqualTo_899_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 180000, AssetValue = 200000, CreditScore = 899 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //If the LTV is 90% or more, the application must be declined

        [Test]
        public void WhenInRange_and_Under_1000000_LTVMoreThanOrEqualToEqualTo90PC_AndCreditScoreEqualTo_899_ShouldFail()
        {
            LoanApplication a = new LoanApplication { Amount = 180000, AssetValue = 200000, CreditScore = 899 };

            var expected = false;

            var actual = _loanEvaluator.Evaluate(a);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}