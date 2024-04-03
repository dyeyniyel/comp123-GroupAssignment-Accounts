namespace Assignment_04_Accounts;

//VISAACCOUNT CLASS
public class VisaAccount : Account, ITransaction
{
    private readonly double creditLimit;
    private const double INTEREST_RATE = 0.1995;

    public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS", balance)
    {
        this.creditLimit = creditLimit;
    }

    public void DoPayment(double amount, Person person)
    {
        base.Deposit(amount, person);
        OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
    }

    public void DoPurchase(double amount, Person person)
    {
        if (!IsUser(person.Name))
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
        }

        if (!person.IsAuthenticated)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
        }

        if (Balance + amount > creditLimit)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            //             throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
        }

        base.Deposit(-amount, person);
        OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
    }

    public override void PrepareMonthlyStatement()
    {
        double interest = LowestBalance * INTEREST_RATE / 12;
        Balance -= interest;
        transactions.Clear();
    }

    public void Withdraw(double amount, Person person)
    {
        // Visa accounts typically do not support direct withdrawals,
        // so you can leave this method empty or throw an exception.
        // Example:
        throw new NotSupportedException("Withdrawals are not supported for Visa accounts.");
    }
}
