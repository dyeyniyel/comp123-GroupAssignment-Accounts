namespace Assignment_04_Accounts;

//TRANSACTION STRUCT
public struct Transaction
{
    public string AccountNumber { get; }
    public double Amount { get; }
    public Person Originator { get; }
    public DayTime Time { get; }

    public Transaction(string accountNumber, double amount, Person person)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        Originator = person;
        Time = Utils.Time;
    }

    public override string ToString()
    {
        string transactionType = Amount >= 0 ? "deposited" : "withdrawn";
        return $"{AccountNumber} ${Math.Abs(Amount):N2} {transactionType} by {Originator.Name} on {Time:yyyy-MM-dd HH:mm}";
    }
}
