using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankCashFlowManagement.Data;
using BankCashFlowManagement.Models;
using BankCashFlowManagement.ViewModels;

namespace BankCashFlowManagement.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Deposit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Deposit(DepositViewModel model)
        {
            var account = await _context.Accounts
                .FindAsync(model.AccountId);

            if (account == null)
            {
                return NotFound();
            }

            account.Balance += model.Amount;

            _context.Transactions.Add(new Transaction
            {
                AccountId = account.AccountId,
                Amount = model.Amount,
                TransactionType = "Deposit",
                TransactionDate = DateTime.Now,
                Description = model.Description
            });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(History));
        }
        public async Task<IActionResult> History()
        {
            var transactions = await _context.Transactions
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            return View(transactions);
        }
    }
}