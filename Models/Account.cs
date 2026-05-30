namespace BankCashFlowManagement.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}