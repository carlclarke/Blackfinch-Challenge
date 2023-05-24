using Blackfinch.Challenge.Dto.Loan;
using Blackfinch.Challenge.BusinessRules.Loan;

if (args.Length > 0 && args.Length == 3)
{
    Decimal.TryParse(args[0], out decimal loanAmount);
    Decimal.TryParse(args[1], out decimal assetValue);
    int.TryParse(args[2], out int creditScore);

    Console.WriteLine($"Loan application for £{loanAmount}, asset value £{assetValue}, credit score {creditScore}");

    LoanApplication loanApplication = new LoanApplication { Amount = loanAmount, AssetValue = assetValue, CreditScore = creditScore };
    LoanApplicationEvaluator loanApplicationEvaluator = new LoanApplicationEvaluator();

    bool result = loanApplicationEvaluator.Evaluate(loanApplication);

    Console.WriteLine($"Loan application was " + (result ? "Successful" : "Unsuccessful"));

    // call some service wrapping classes (that could use RESTSharp etc) to get:

    // The total number of applicants to date, broken down by their success status
    // The total value of loans written to date
    // The mean average Loan to Value of all applications received to date

    // map data from the service into some UI objects used for display and display the data
    Console.WriteLine("The total number of applicants to date, x applications successful, y applications unsuccessful");
    Console.WriteLine("The total value of loans written to date is £nnnn");
    Console.WriteLine("The mean average Loan to Value of all applications received to date is zz%");

}
else
{
    Console.WriteLine("Insufficient input");
    Console.WriteLine("Please re-run and supply Loan Amount, Asset Value, Credit Score");
}

