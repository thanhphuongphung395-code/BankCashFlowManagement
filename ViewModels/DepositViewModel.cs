namespace BankCashFlowManagement.ViewModels
{
    public class DepositViewModel
    {
        public int AccountId { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }
    }
}
