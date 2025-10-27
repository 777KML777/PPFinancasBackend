using Domain.Entities.Expense;
using Domain.Entities.Extrato;
using Domain.Enums;

// Cadastrar cartão. 

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

        public decimal TotalExpenses() =>
            Expenses.Where(x => !x.Inactive).Sum(x => x.SumTotalExpense());

        public decimal LiquidedBalance() =>
           Expenses.Where(x => !x.Inactive).Sum(x => Balance - x.SumTotalExpense());
        public List<ExtratoEntity> Extrato = new();
        public IReadOnlyCollection<ExpenseEntity> Expenses { get { return _expenses.ToArray(); } }

        public void GerarExtrato(EOperacao operacao, decimal valorTransacao)
        {
            ExtratoEntity extrato = new
            (
                operacao,
                Balance,
                valorTransacao
            );
            extrato.LinkedIdBank(Id);

            Extrato.Add(extrato);
        }
        public void AddExpensesToBanks(ExpenseEntity expenses) =>
            _expenses.Add(expenses);

        public void AlterBankEntity
        (
            int id,
            string name,
            decimal balance,
            int paymentDay,
            bool available = true,
            EOperacao operacao = EOperacao.NENHUMA
        )
        {
            Id = id;
            Name = name;
            Available = available;
            PaymentDay = paymentDay;

            if (operacao == EOperacao.NENHUMA)
                Balance = balance;
            else
            {
                GerarExtrato(operacao, balance);
                Balance += balance;
            }
        }
    }
}