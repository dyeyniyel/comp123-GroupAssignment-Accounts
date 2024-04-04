namespace Assignment_04_Accounts;

//SAVINGACCOUNT CLASS

public class SavingAccount : Account, ITransaction
{
    private const double COST_PER_TRANSACTION = 0.5;
    private const double INTEREST_RATE = 0.015;
    private readonly bool hasOverdraft;

    public SavingAccount(double balance = 0, bool hasOverdraft = false) : base("SV", balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public new void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
    }

    public void Withdraw(double amount, Person person)
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

        if (amount > Balance && !hasOverdraft)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.NO_OVERDRAFT);
        }

        base.Deposit(-amount, person);
        OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
    }

    public override void PrepareMonthlyStatement()
    {
        double serviceCharge = transactions.Count * COST_PER_TRANSACTION;
        double interest = LowestBalance * INTEREST_RATE / 12;

        Balance += interest - serviceCharge;
        transactions.Clear();
    }
}
