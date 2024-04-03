namespace Assignment_04_Accounts;

//TransactionEventArgs CLASS
public class TransactionEventArgs : LoginEventArgs
{
    public double Amount { get; }

    public TransactionEventArgs(string personName, double amount, bool success) : base(personName, success)
    {
        Amount = amount;
    }
}

