using System;
using static GroupAssignment_Accounts.MainAccount;

public interface ITransaction
{
    void Withdraw(double amount, Person person);
    void Deposit(double amount, Person person);
}
