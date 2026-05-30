using BankCashFlowManagement.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public DateTime CreatedDate { get; set; }

    public ICollection<Account>? Accounts { get; set; }
}