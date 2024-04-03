namespace Assignment_04_Accounts;

//PERSON CLASS
public class Person
{
    private string password;
    public event EventHandler OnLogin;

    public string Sin { get; }
    public string Name { get; }
    public bool IsAuthenticated { get; private set; }

    public Person(string name, string sin)
    {
        Name = name;
        Sin = sin;
        password = sin.Substring(0, 3); // Set password to the first three letters of SIN
    }

    public void Login(string password)
    {
        if (password != this.password)
        {
            IsAuthenticated = false;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, false));
            throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
        }

        IsAuthenticated = true;
        OnLogin?.Invoke(this, new LoginEventArgs(Name, true));
    }

    public void Logout()
    {
        IsAuthenticated = false;
    }

    public override string ToString()
    {
        return $"[{Name}, {Name} {(IsAuthenticated ? "" : " Not logged in")}]";
    }
}
