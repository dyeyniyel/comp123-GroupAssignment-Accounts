using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment_Accounts
{
    public class MainAccount
    {

//ExceptionType ENUM
        public enum ExceptionType
        {
            ACCOUNT_DOES_NOT_EXIST,
            CREDIT_LIMIT_HAS_BEEN_EXCEEDED,
            NAME_NOT_ASSOCIATED_WITH_ACCOUNT,
            NO_OVERDRAFT,
            PASSWORD_INCORRECT,
            USER_DOES_NOT_EXIST,
            USER_NOT_LOGGED_IN
        }
//AccountType ENUM
        public enum AccountType
        {
            Checking,
            Saving,
            Visa
        }

//UTILS CLASS
        //this class depends of the implementation of the following types:
        //DayTime struct and AccountType enum
        public static class Utils
        {
            static DayTime _time = new DayTime(1_048_000_000);
            static Random random = new Random();
            public static DayTime Time
            {
                get => _time += random.Next(1000);
            }
            public static DayTime Now
            {
                get => _time += 0;
            }

            public readonly static Dictionary<AccountType, string> ACCOUNT_TYPES =
                new Dictionary<AccountType, string>
            {
            { AccountType.Checking , "CK" },
             { AccountType.Saving , "SV" },
              { AccountType.Visa , "VS" }
            };

        }

//AccountException CLASS
        public class AccountException : Exception
        {
            public AccountException(ExceptionType reason) : base(reason.ToString())
            {
            }
        }

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

//TransactionEventArgs CLASS
        public class TransactionEventArgs : LoginEventArgs
        {
            public double Amount { get; }

            public TransactionEventArgs(string personName, double amount, bool success) : base(personName, success)
            {
                Amount = amount;
            }
        }

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
                Time = Utils.Now;
            }

            public override string ToString()
            {
                string transactionType = Amount >= 0 ? "Deposit" : "Withdraw";
                return $"{transactionType} of {Math.Abs(Amount)} made by {Originator.Name} at {Time}.";
            }
        }
//DAYTIME STRUCT
        public struct DayTime
        {
            private long minutes;

            public DayTime(long minutes)
            {
                this.minutes = minutes;
            }

            public static DayTime operator +(DayTime lhs, int minute)
            {
                return new DayTime(lhs.minutes + minute);
            }

            public override string ToString()
            {
                long remainingMinutes = minutes;
                long year = remainingMinutes / (518400 * 60);
                remainingMinutes %= (518400 * 60);
                long month = remainingMinutes / (43200 * 60);
                remainingMinutes %= (43200 * 60);
                long day = remainingMinutes / (1440 * 60);
                remainingMinutes %= (1440 * 60);
                long hour = remainingMinutes / (60 * 60);
                remainingMinutes %= (60 * 60);
                long minute = remainingMinutes / 60;

                return $"{year:0000}-{month + 1:00}-{day + 1:00} {hour:00}:{minute:00}";
            }
        }


//LOGGER CLASS
        public static class Logger
        {
            private static readonly List<string> loginEvents = new List<string>();
            private static readonly List<string> transactionEvents = new List<string>();

            public static void LoginHandler(object sender, EventArgs args)
            {
                if (args is LoginEventArgs loginArgs)
                {
                    string log = $"{loginArgs.PersonName} - Login {(loginArgs.Success ? "Successful" : "Failed")} at {Utils.Now}";
                    loginEvents.Add(log);
                }
            }

            public static void TransactionHandler(object sender, EventArgs args)
            {
                if (args is TransactionEventArgs transactionArgs)
                {
                    string operation = transactionArgs.Amount >= 0 ? "Deposit" : "Withdraw";
                    string log = $"{transactionArgs.PersonName} - {operation} of {Math.Abs(transactionArgs.Amount)} {(transactionArgs.Success ? "Successful" : "Failed")} at {Utils.Now}";
                    transactionEvents.Add(log);
                }
            }

            public static void ShowLoginEvents()
            {
                Console.WriteLine($"Current Time: {Utils.Now}");
                for (int i = 0; i < loginEvents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {loginEvents[i]}");
                }
            }

            public static void ShowTransactionEvents()
            {
                Console.WriteLine($"Current Time: {Utils.Now}");
                for (int i = 0; i < transactionEvents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
                }
            }
        }

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
                return $"{Name} - Authenticated: {IsAuthenticated}";
            }
        }
        //ACCOUNT CLASS
        public abstract class Account
        {
            private static int LAST_NUMBER = 100000;
            private readonly List<Person> users = new List<Person>();
            public readonly List<Transaction> transactions = new List<Transaction>();

            public event EventHandler OnTransaction;

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
                string userList = string.Join(", ", users.Select(user => user.Name));
                string transactionList = string.Join("\n", transactions.Select((transaction, index) => $"{index + 1}. {transaction}"));

                return $"Account Number: {Number}\nUsers: {userList}\nBalance: {Balance}\nTransactions:\n{transactionList}";
            }
        }

//CHECKINGACCOUNT CLASS
        public class CheckingAccount : Account, ITransaction
        {
            private const double COST_PER_TRANSACTION = 0.05;
            private const double INTEREST_RATE = 0.005;
            private readonly bool hasOverdraft;

            public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base("CK", balance)
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


            //BANK CLASS


            public static class Bank
            {
                public static readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
                public static readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();

                static Bank()
                {
                    // Initialize USERS collection
                    AddPerson("Narendra", "1234-5678");    //0
                    AddPerson("Ilia", "2345-6789");        //1
                    AddPerson("Mehrdad", "3456-7890");     //2
                    AddPerson("Vijay", "4567-8901");       //3
                    AddPerson("Arben", "5678-9012");       //4
                    AddPerson("Patrick", "6789-0123");     //5
                    AddPerson("Yin", "7890-1234");         //6
                    AddPerson("Hao", "8901-2345");         //7
                    AddPerson("Jake", "9012-3456");        //8
                    AddPerson("Mayy", "1224-5678");        //9
                    AddPerson("Nicoletta", "2344-6789");   //10

                    // Initialize ACCOUNTS collection
                    AddAccount(new VisaAccount());              //VS-100000
                    AddAccount(new VisaAccount(150, -500));     //VS-100001
                    AddAccount(new SavingAccount(5000));        //SV-100002
                    AddAccount(new SavingAccount());            //SV-100003
                    AddAccount(new CheckingAccount(2000));      //CK-100004
                    AddAccount(new CheckingAccount(1500, true));//CK-100005
                    AddAccount(new VisaAccount(50, -550));      //VS-100006
                    AddAccount(new SavingAccount(1000));        //SV-100007 

                    // Associate users with accounts
                    string number = "VS-100000";
                    AddUserToAccount(number, "Narendra");
                    AddUserToAccount(number, "Ilia");
                    AddUserToAccount(number, "Mehrdad");

                    number = "VS-100001";
                    AddUserToAccount(number, "Vijay");
                    AddUserToAccount(number, "Arben");
                    AddUserToAccount(number, "Patrick");

                    number = "SV-100002";
                    AddUserToAccount(number, "Yin");
                    AddUserToAccount(number, "Hao");
                    AddUserToAccount(number, "Jake");

                    number = "SV-100003";
                    AddUserToAccount(number, "Mayy");
                    AddUserToAccount(number, "Nicoletta");

                    number = "CK-100004";
                    AddUserToAccount(number, "Mehrdad");
                    AddUserToAccount(number, "Arben");
                    AddUserToAccount(number, "Yin");

                    number = "CK-100005";
                    AddUserToAccount(number, "Jake");
                    AddUserToAccount(number, "Nicoletta");

                    number = "VS-100006";
                    AddUserToAccount(number, "Ilia");
                    AddUserToAccount(number, "Vijay");

                    number = "SV-100007";
                    AddUserToAccount(number, "Patrick");
                    AddUserToAccount(number, "Hao");
                }

                public static void PrintAccounts()
                {
                    foreach (var account in ACCOUNTS.Values)
                    {
                        Console.WriteLine(account);
                    }
                }

                public static void PrintPersons()
                {
                    foreach (var person in USERS.Values)
                    {
                        Console.WriteLine(person);
                    }
                }

                public static Person GetPerson(string name)
                {
                    if (USERS.ContainsKey(name))
                    {
                        return USERS[name];
                    }
                    else
                    {
                        throw new AccountException(ExceptionType.USER_DOES_NOT_EXIST);
                    }
                }

                public static Account GetAccount(string number)
                {
                    if (ACCOUNTS.ContainsKey(number))
                    {
                        return ACCOUNTS[number];
                    }
                    else
                    {
                        throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST);
                    }
                }

                public static void AddPerson(string name, string sin)
                {
                    var person = new Person(name, sin);
                    person.OnLogin += Logger.LoginHandler;
                    USERS.Add(name, person);
                }

                public static void AddAccount(Account account)
                {
                    account.OnTransaction += Logger.TransactionHandler;
                    ACCOUNTS.Add(account.Number, account);
                }

                public static void AddUserToAccount(string number, string name)
                {
                    if (ACCOUNTS.ContainsKey(number) && USERS.ContainsKey(name))
                    {
                        var account = ACCOUNTS[number];
                        var person = USERS[name];
                        account.AddUser(person);
                    }
                    else
                    {
                        throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST);
                    }
                }

                public static List<Transaction> GetAllTransactions()
                {
                    List<Transaction> allTransactions = new List<Transaction>();
                    foreach (var account in ACCOUNTS.Values)
                    {
                        allTransactions.AddRange(account.transactions);
                    }
                    return allTransactions;
                }
            }




        }
    }



}




