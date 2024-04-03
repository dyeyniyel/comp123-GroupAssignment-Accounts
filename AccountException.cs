namespace Assignment_04_Accounts;

//AccountException CLASS
public class AccountException : Exception
{
    public AccountException(ExceptionType reason) : base(reason.ToString())
    {
    }
}

