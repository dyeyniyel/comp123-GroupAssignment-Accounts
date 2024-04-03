namespace Assignment_04_Accounts;

//LOGGER CLASS
public static class Logger
{
    private static readonly List<string> loginEvents = new List<string>();
    private static readonly List<string> transactionEvents = new List<string>();

    public static void LoginHandler(object? sender, EventArgs args)
    {
        ArgumentNullException.ThrowIfNull(sender);

        if (args is LoginEventArgs loginArgs)
        {
            string status = loginArgs.Success ? "successfully" : "unsuccessfully";
            string log = $"{loginArgs.PersonName} logged in {status} on {Utils.Time}";
            loginEvents.Add(log);
        }
    }

    public static void TransactionHandler(object sender, EventArgs args)
    {
        ArgumentNullException.ThrowIfNull(sender);

        if (args is TransactionEventArgs transactionArgs)
        {
            string status = transactionArgs.Success ? "successfully" : "unsuccessfully";
            string operation = transactionArgs.Amount >= 0 ? "deposit" : "withdraw";
            string log = $"{transactionArgs.PersonName} {operation} ${(Math.Abs(transactionArgs.Amount)).ToString("F2")} {status} on {Utils.Now}";
            transactionEvents.Add(log);
        }
    }

    public static void ShowLoginEvents()
    {
        Console.WriteLine($"Login events as of {Utils.Time}");
        for (int i = 0; i < loginEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {loginEvents[i]}");
        }
    }


    public static void ShowTransactionEvents()
    {
        Console.WriteLine($"Transaction events as of {Utils.Time}");
        for (int i = 0; i < transactionEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
        }
    }
}
