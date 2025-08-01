using Domain.Entities.Expense;

namespace Domain.Entities.Bank
{
    public class BankEntity : Entity
    {

        private IList<ExpenseEntity> _expenses = new List<ExpenseEntity>();

        public BankEntity()
        {

        }

        public BankEntity
        (
            string name,
            decimal balance,
            int paymentDay,
            bool available = true
        )
        {
            Name = name;
            Balance = balance;
            Available = available;
            PaymentDay = paymentDay;
        }

        public string Name { get; private set; }
        public int PaymentDay { get; private set; }
        public bool Available { get; private set; }
        public decimal Balance { get; private set; }

        public IReadOnlyCollection<ExpenseEntity> Expenses { get { return _expenses.ToArray(); } }

        public void AddExpensesToBanks(ExpenseEntity expenses) =>
            _expenses.Add(expenses);

        public void AlterBankEntity
        (
            int id, string name, decimal balance, int paymentDay, bool available = true
        )
        {
            Id = id;
            Name = name;
            Balance = balance;
            Available = available;
            PaymentDay = paymentDay;
        }
    }
}