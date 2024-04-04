namespace Assignment_04_Accounts;

//ACCOUNT CLASS
public abstract class Account
{
    private static int LAST_NUMBER = 100000;
    private readonly List<Person> users = new List<Person>();
    public readonly List<Transaction> transactions = new List<Transaction>();

    public event EventHandler? OnTransaction;

    public string Number { get; }
    public double Balance { get; protected set; }
    public double LowestBalance { get; protected set; }

    public Account(string type, double balance)
    {
        Number = $"{type}-{LAST_NUMBER++}";
        Balance = balance;
        LowestBalance = balance;
    }

    public void Deposit(double amount, Person person)
    {
        Balance += amount;
        if (Balance < LowestBalance)
            LowestBalance = Balance;

        var transaction = new Transaction(Number, amount, person);
        transactions.Add(transaction);

        OnTransactionOccur(this, EventArgs.Empty);
    }

    public void AddUser(Person person)
    {
        users.Add(person);
    }

    public bool IsUser(string name)
    {
        return users.Any(person => person.Name == name);
    }

    public abstract void PrepareMonthlyStatement();

    public virtual void OnTransactionOccur(object sender, EventArgs args)
    {
        OnTransaction?.Invoke(sender, args);
    }

    public override string ToString()
    {
        string userList = string.Join(", ", users.Select(user => $"{user.Name} {(user.IsAuthenticated ? "Logged in" : "Not logged in")}"));
        string transactionList = string.Join("\n   ", transactions.Select((transaction, index) => $"{index + 1}. {transaction}"));

        return $"{Number} {userList} ${Balance:N2} - transactions ({transactions.Count})\n   {transactionList}";
    }
}
