namespace Domain
{
    public class BankEntity : Entity
    {

        private IList<ExpensesEntity> _expenses;
        public BankEntity () 
        {
            // Quando conectar com o banco, provavelmente irá precisar instanciar o Expenses.

        }

        public BankEntity (string name, decimal balance)
        {
            Balance = balance; 
            Name = name;
        }
        
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<ExpensesEntity> Expenses { get {return _expenses.ToArray(); }}

        public void AddExpensesToBanks(ExpensesEntity expenses) => 
            _expenses.Add(expenses);
        
    }

}
