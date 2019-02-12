using System;

namespace CodeChallenge.LoanManagement.Api.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public String CustomerNumber { get; set; }
        public String LoanNumber { get; set; }
        public String Description { get; set; }
        public int Balance { get; set; }
        public int BalanceIncludeInterestof { get; set; }
        public int EarlyPaymentFee { get; set; }
        public int PayoutAmount { get; set; }

    }
}
