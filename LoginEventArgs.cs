namespace Assignment_04_Accounts;

//LoginEventArgs CLASS
public class LoginEventArgs : EventArgs
{
    public string PersonName { get; }
    public bool Success { get; }

    public LoginEventArgs(string personName, bool success)
    {
        PersonName = personName;
        Success = success;
    }
}

