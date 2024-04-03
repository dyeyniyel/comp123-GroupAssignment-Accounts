# Assignment 4 – Implementing a Banking Application

### Due: See course shell for due date and time

<img src="./media/image1.png" style="width:6.1375in;height:3.77292in"
alt="Graphical user interface Description automatically generated" />

Check with you professor to see if you are permitted to work as a group.

The application is by far the most complex system that you have
attempted so far. It consists of eleven classes, two structs, one
interface and two enums coupled in varying degrees of tightness. The
Bank class is the main driver of the application. It has a collection of
Accounts and Person that is initialize appropriately in the static
constructor. You will implement the entire system in Visual Studio. A
short description of each type with their members is given below.

You are advised to implement each type in the order that they are
described.

No method should have a **Console.WriteLine()** unless you are
explicitly told to output something on the console.

Each type must be in separate files.

## ExceptionType enum

You will implement this enum in Visual Studio. There are seven members:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>ExceptionType</strong></p>
<p>enum</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Constants</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>ACCOUNT_DOES_NOT_EXIST,</p>
<p>CREDIT_LIMIT_HAS_BEEN_EXCEEDED,</p>
<p>NAME_NOT_ASSOCIATED_WITH_ACCOUNT,</p>
<p>NO_OVERDRAFT,</p>
<p>PASSWORD_INCORRECT,</p>
<p>USER_DOES_NOT_EXIST,</p>
<p>USER_NOT_LOGGED_IN</p>
</blockquote></td>
</tr>
</tbody>
</table>

The members are self-explanatory.

## AccountType enum

You will implement this enum in Visual Studio. There are three members:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>AccountType</strong></p>
<p>enum</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Constants</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>Checking,</p>
<p>Saving,</p>
<p>Visa</p>
</blockquote></td>
</tr>
</tbody>
</table>

The members are self-explanatory.

## Utils class

\[The implementation for this class is given in the appendix. Create a
class called Utls and copy and past the statements into the appropriate
part of the file\]

You will implement the Utils class in Visual Studio. This class is
comprised of three fields and provides two static properties. It
simulates the passage of time. Each time the **Time** property is
accessed, it increases the internal field by a random amount. It is used
to time stamped all banking events.

A short description of each class member is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Utils</strong></p>
<p><strong>Static class</strong></p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>-$ _time : DayTime</p>
<p>-$ random : Random</p>
<p>+$ «readonly» ACCOUNT_TYPE : Dictionary&lt;AccountType,
string&gt;</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+$ «computed prop» Time : DayTime</p>
<p>+$ «computed prop» Now : DayTime</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
</tbody>
</table>

### Properties:

There are three properties.

1.  **\_time** – this private class variable is of type **DayTime** that
    store the time of this object. It is initialized (with argument
    1_048_000_000) at declaration. It is mutated (changed) whenever
    either of the properties is accessed.

2.  **random** – this private class variable is of type **Random**
    storing the time of this object. It is initialized (with argument
    1_048_000_000) at declaration. It is mutated (changed) whenever
    either of the properties is accessed.

3.  **ACCOUNT_TYPE** – this private class variable is of type
    **Dictionary\<AccountType, string\>**. It serves as a lookup table
    to match an account type with a particular prefix. It is initialized
    (code is given in the appendix) at declaration.

### Properties:

There are two properties, both of which are computed.

1.  **Time** – this public class variable is of type **DayTime**. It
    adds a random value to the internal field **\_time** and then
    returns it.

2.  **Now** – this public class variable is of type **DayTime**. It adds
    zero to the internal field **\_time** and then returns it.

### Methods:

There are no explicitly defined methods.

You do not have to code this class. Just copy the code statements from
the appendix of this document.

## ITransaction interface

You will implement the **ITransaction** Interface in Visual Studio. The
three Account sub classes implement this interface.

A short description of each class member is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>ITransaction</strong></p>
<p>Interface</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>Withdraw(amount : <strong>double</strong>, person :
<strong>Person</strong>) : <strong><mark>void</mark></strong></p>
<p>Deposit(amount : <strong>double</strong>, person :
<strong>Person</strong>) : <strong><mark>void</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Properties:

There are no properties.

### Methods:

1.  **void Withdraw(<span class="mark">double</span> amount, Person
    person).**

2.  **void Deposit(double amount, Person person).**

## AccountException class

You will implement the AccountException Class in Visual Studio. This
inherits from the **Exception** Class to provide a custom exception
object for this application. It consists of a single a constructor:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>AccountException</strong></p>
<p>Class</p>
<p>→ Exception</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» AccountException(reason : ExceptionType)</p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

There are no fields

### Properties:

There are no properties

### Constructor:

1.  **public AccountException(ExceptionType reason )**– this public
    constructor invokes the base constructor with an appropriate
    argument. The base constructer argument is obtain by calling the
    ToString() of the argument. \[You are sending the argument of the
    child constructor to the parent constructor.\]

### Methods:

There are no methods.

2.  

## LoginEventArgs class

You will implement the **LoginEventArgs** Class in Visual Studio. This
inherits from the **EventArgs** Class to provide a custom object for
this application. It consists of two properties and a single a
constructor:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>LoginEventArgs</strong></p>
<p>Class</p>
<p>→ EventArgs</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «prop, no set» PersonName : string</p>
<p>+ «prop, no set» Success : bool</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» LoginEventArgs(</p>
<p>personName : string,</p>
<p>success : bool)</p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

There are no fields

### Properties:

There are two public properties, with no accompanying setters.

### Constructors:

1.  **public LoginEventArgs(string name, bool success)** – this public
    constructor takes a string and a bool argument and does the
    following:

    1.  Invokes the base constructor

    2.  Assigns the arguments to the appropriate properties.

### Methods:

There are no explicitly defined methods.

3.  

## TransactionEventArgs class

You will implement the **TransactionEventArgs** Class in Visual Studio.
This inherits from the **LoginEventArgs** Class to provide a custom
object for this application. It consists of a single property and a
single a constructor:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>TransactionEventArgs</strong></p>
<p>Class</p>
<p>→ LoginEventArgs</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «prop, no set» Amount : double</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» TransactionEventArgs(</p>
<p>personName : string,</p>
<p>amount : double,</p>
<p>success : bool)</p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

There are no fields

### Properties:

There is one explicitly defined public property, with no accompanying
setters.

### Constructors:

1.  **public TransactionEventArgs(string name, double amount, bool
    success)** – this public constructor takes a string, a double and a
    bool argument and does the following:

    1.  Invokes the base constructor with the appropriate arguments.

    2.  Assigns the middle argument to the appropriate property.

### Methods:

There are no explicitly defined methods.

2.  

## Transaction struct

You will implement the Transaction struct in Visual Studio. The only
purpose of this stuct is to capture the data values for each
transaction. A short description of the struct members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Transaction</strong></p>
<p>struct</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «prop, no set» AccountNumber : <strong>string</strong></p>
<p>+ «prop, no set» Amount : <strong>double</strong></p>
<p>+ «prop, no set» Originator : <strong>Person</strong></p>
<p>+ «prop, no set» Time : <strong>DayTime</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» Transaction(</p>
<p>accountNumber : <strong><mark>string</mark></strong>,</p>
<p>amount : <strong>double</strong>,</p>
<p><del>endBalance : <strong>double</strong>,</del></p>
<p>person : <strong>Person</strong></p>
<p>)</p>
<p>+ ToString() : <strong><mark>string</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Properties: 

There are no fields.

### Properties: 

All the properties are public with the setter absent

1.  **AccountNumber** – this property is a **string** representing the
    account number associated with this transaction. The getter is
    public, and the setter is absent.

2.  **Amount** – this property is a **double** representing the account
    of this transaction. The getter is public, and the setter is absent.

3.  **Originator** – this property is a **Person** representing the
    person initiating this transaction. The getter is public, and the
    setter is absent.

4.  **Time** – this property is a **DayTime** type representing the time
    associated with this transaction. The getter is public, and the
    setter is absent.

### Constructors:

1.  **<span class="mark">public Transaction( string accountNumber,
    double amount,</span> Person <span class="mark">person)</span>** –
    This public constructor takes three arguments. It assigns the
    arguments to the appropriate properties. It also sets the **Time**
    property to the **Time** property of the **Utils** class.

### Methods:

1.  **<span class="mark">public override string ToString( )</span>** –
    This method overrides the same method of the Object class. It does
    not take any parameter and it returns a string representing the
    account number, name of the person, the amount, and the time that
    this transition was completed. \[See the output for clues for this
    method.\] You **must** include the word Deposit or Withdraw in the
    output.

## DayTime struct

You will implement the DayTime struct in Visual Studio. The only purpose
of this stuct is to capture the time of an event.

The logic of this class depends on the following:

- 1 hour = 60 minutes

- 1 day = 24 hours = 24 \* 60 = 1_440 minutes

- 1 month = 30 days = 30 \* 1_440 = 43_200 minutes

- 1 year = 12 months = 12 \* 43_200 = 518_400 minutes

- Time starts on the zero minute of the zero hour of the first day of
  the first month of the zero year. i.e. 0 minute will be 0000–01–01
  00:00

A short description of the struct members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>DayTime</strong></p>
<p>struct</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>- minutes : <strong>long</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» DayTime(minutes : <strong>long</strong>)</p>
<p>$+ «operator» +(</p>
<p>lhs: <strong>DayTime</strong>,</p>
<p>minute : <strong>int</strong>) : <strong>DayTime</strong></p>
<p>+ ToString() : <strong><mark>string</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Properties: 

There is a single private field.

1.  **minutes** – this private field is a **long** representing the
    minute value of this struct.  
    \[The time on a computer system is a simple counter. The long
    counter represents the number of ticks (milliseconds) since 1970
    January 1\]

### Properties: 

There are no properties.

### Constructors:

1.  **<span class="mark">public Day( long minutes )</span>** – This
    public constructor takes a single long argument and assigns it to
    the appropriate field.

### Methods:

1.  **<span class="mark">public static</span> DayTime
    <span class="mark">operator +(</span> DayTime
    <span class="mark">lhs,</span> int <span class="mark">minutes
    )</span>** – This method overload the addition operator. Returns a
    new struct with the original minutes that is increased by the second
    argument. This is used in the Util class to get the current time
    (**Utils.Now**) and incremented time (**Utils.Time**).

2.  **<span class="mark">public override string ToString( )</span>** –
    This method overrides the same method of the Object class. It
    calculates the year, month, day, hour, and remaining minutes from
    the private minutes field. \[See the output for clues for this
    method.\]

## Logger class

You will implement the Logger Class in Visual Studio. This is a static
class with some housekeeping duties. It handles all login attempts and
transaction occurrences.

A short description of each class member is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Logger</strong></p>
<p>Static Class</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$- loginEvents : <strong>List</strong>&lt;string&gt;</p>
<p>$- transactionEvents : <strong>List</strong>&lt;string&gt;</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$+ «<strong>EventHandler</strong>» LoginHandler(</p>
<p>sender : <strong>object</strong>,</p>
<p>args : <strong>EventArgs</strong>) :
<strong><mark>void</mark></strong></p>
<p>$+ «<strong>EventHandler</strong>» TransactionHandler(</p>
<p>sender : <strong>object</strong>,</p>
<p>args : <strong>EventArgs</strong>) :
<strong><mark>void</mark></strong></p>
<p>$+ ShowLoginEvents() : <strong><mark>void</mark></strong></p>
<p>$+ ShowTransactionEvents() : <strong><mark>void</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

There are two fields:

1.  **loginEvents** – this private static **List**\<string\>field
    represents login attempts to the bank. This is initialized to an
    empty collection at declaration.

2.  **transactionEvents** – this private static **List**\<string\>field
    represents login attempts to the bank. This is initialized to an
    empty collection at declaration.

### Properties:

There are no properties.

### Constructors:

There are no properties.

### Methods:

1.  **public static void LoginHandler(object sender, EventArgs args)** –
    This method does the following:

    1.  Uses the **as** operator to cast the second argument to a
        **LoginEventArgs** object.

    2.  Create a string with the following:

- PersonName (from args).

- Success (from args).

- Current time (from **Utils.Now**).

  1.  Adds the above string to the loginEvents collection.

This method does not display anything

2.  **public static void TransactionHandler(object sender, EventArgs
    args)** – This method does the following:

    1.  Uses the **as** operator to cast the second argument to a
        **TransactionEventArgs** object.

    2.  Create a string with the following:

- PersonName (from args).

- Amount (from args)

- Operation (from Amount in args)

- Success (from args).

- Current time (from **Utils.Now**).

  1.  Adds the above string to the transactionEvents collection.

This method does not display anything

3.  **<span class="mark">public static void ShowLoginEvents( )</span>**
    – This is method does not take any parameters nor does it return a
    value. The method does the following:

    1.  Prints the current time (**Utils.Now**)

    2.  Prints a number list of all the items in the **loginEvents**
        collection.

4.  **<span class="mark">public static void ShowTransactionEvents(
    )</span>** – This is method does not take any parameters nor does it
    return a value. The method does the following:

    1.  Prints the current time (**Utils.Now**)

    2.  Prints a number list of all the items in the
        **transactionEvents** collection.

5.  

## Person class

You will implement the Person Class in Visual Studio. A person object
may be associated with multiple accounts. A person initiates activities
(deposits or withdrawal) against an account that is captured in a
transaction object.

A short description of each class member is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Person</strong></p>
<p>Class</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>- password : <strong>string</strong></p>
<p>+ OnLogin : <strong>event Eventhandler</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «C# property, no set » Sin :
<strong><mark>string</mark></strong></p>
<p>+ «C# property, no set » Name :
<strong><mark>string</mark></strong></p>
<p>+ «C# property, private set» IsAuthenticated :
<strong>bool</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» Person(</p>
<p>name : <strong><mark>string</mark></strong>,</p>
<p>sin : <strong>string</strong>)</p>
<p>+ Login(password : <strong><mark>string</mark></strong>) :
<strong><mark>void</mark></strong></p>
<p>+ Logout() : <strong><mark>void</mark></strong></p>
<p>+ ToString() : <strong><mark>string</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

There are two fields:

3.  **Password** – this private **string** field represents the password
    of this person.  
    (N.B. Password are not normally stored as text but as a hash value.
    A hashing function operates on the password and the resulting hash
    value is stored. When a user supplies a password, it is passed
    through the same hashing function and the result is compared to the
    stored value.)

4.  **OnLogin** – this public **event** field represents the
    **EventHandler** that will store the method to be invoked.

### Properties:

All the properties are auto-implemented.

1.  **SIN** – this **string** property represents the sin number of this
    person. The getter is public, and setter is absent.

2.  **Name** – this property is a **string** representing the name of
    this person. This getter is public, and setter is absent.

3.  **IsAuthenticated** – this property is a **bool** representing if
    this person is logged in with the correct password. This is modified
    in the **Login()** and the **Logout()** methods. This getter is
    public, and setter is absent.

### Constructors:

1.  **<span class="mark">public Person(string name, string sin)</span>**
    – This public constructor takes two parameters: a string
    representing the name of the person and another string representing
    the SIN of this person. It does the following:

    1.  The method assigns the arguments to the appropriate fields.

    2.  It also sets the password field to the first three letters of
        the SIN.  
        \[use the Substring(start_position, length) method of the string
        class\]

### Methods:

6.  **<span class="mark">public void Login(string password)</span>** –
    This method takes a string parameter representing a password and
    does the following:

    1.  If the argument DOES NOT match the password field, it does the
        following:

- Sets the IsAuthenticated property to false

- Invokes the **EventHandler** OnLogin with the following arguments:

  - The current object reference (use
    **<span class="mark">this</span>**)

  - The second argument is of type **LoginEventArgs**. This will have
    arguments

    - the name of the current object

    - and the success on the operation (use
      **<span class="mark">false</span>** in this case).

- Creates an **AccountException** object using argument
  **AccountEnum**.PASSWORD_INCORRECT

- Throws the above exception

  1.  If the argument matches the password, it does the following:

<!-- -->

- Sets the IsAuthenticated property is set to true

- Invokes the **EventHandler** OnLogin with the following arguments:

  - The current object reference (use
    **<span class="mark">this</span>**)

  - The second argument is of type **LoginEventArgs**. This will have
    arguments

    - the name of the current object

    - and the success on the operation (use **true** in this case).

This method does not display anything

7.  **<span class="mark">public void Logout( )</span>** – This is public
    method does not take any parameters nor does it return a value.  
    This method sets the IsAuthenticated property to false  
    This method does not display anything

8.  **<span class="mark">public override string ToString( )</span>**–
    This public method overrides the same method of the Object class. It
    returns a string representing the name of the person ~~and if he is
    authenticated or not~~.

## Account class

You will implement the Account Class in Visual Studio. This class that
will serve as the base class for the Visa, Checking and Saving classes.
The member PrepareMonthlyStatement() is abstract so the class must be
declared abstract. Because this is an abstract class, you may not
instantiate this class. A short description of the class members is
given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><em><strong>Account</strong></em></p>
<p>Abstract Class</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$- LAST_NUMBER = 100_000 : int</p>
<p># «readonly» users : List&lt;Person&gt;</p>
<p>+ «readonly» transactions : List&lt;Transaction&gt;</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Event</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «virtual» OnTransaction : EventHandler&lt;EvenArgs&gt;</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «prop, no set» Number : string</p>
<p>+ «prop, protected set» Balance : double</p>
<p>+ «prop, protected set» LowestBalance : double</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» Account(</p>
<p>type : <mark>string</mark>,</p>
<p>balance : double)</p>
<p>+ Deposit(</p>
<p>balance : double,</p>
<p>person : Person) : void</p>
<p>+ AddUser(</p>
<p>Person : Person) : void</p>
<p>+ IsUser(</p>
<p>name : <mark>string</mark>) : bool</p>
<p>+ «virtual» OnTransactionOccur(</p>
<p>Sender : object</p>
<p>args :EventArgs) : void</p>
<p>+ «abstract» PrepareMonthlyStatement(): void</p>
<p>+ ToString() : <mark>string</mark></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

If these two fields are readonly, then how it is possible to add users
and transactions?

1.  **users** – this readonly protected field is a list of persons
    representing the user who have access to this account. This is
    initialized at in the constructor to an empty collection.

2.  **transactions** – this readonly puble field is a list of
    transaction representing the deposits, withdrawal, payments and
    purchases of this account. This initialized at in the constructor to
    an empty collection.

3.  **LAST_NUMBER** – this private field is a class variable of type
    int. It represents the last account number that was used to generate
    the unique account number. It is initialized at declaration to
    100,000 and is modify in the constructor.

### Properties:

1.  **Balance** – this property is a double representing the amount in
    this account. This is modified in the **Deposit()** method and in
    the **PrepareMonthlyReport()** method of the derived classes. This
    is an auto-implemented property the getter is public and the setter
    is protected

2.  **LowestBalance** – this property is a double representing the
    lowest balance that this amount ever drops to. This is modified in
    the **Deposit()** method. This is an auto-implemented property the
    getter is public and the setter is protected

3.  **Number** – this property is a string representing the account
    number of this account. The getter is public and the setter is
    absent.

### Events:

1.  **OnTransaction** – this event is a double representing the amount
    in this account. This is modified in the **Deposit()** method and in
    the **PrepareMonthlyReport()** method of the derived classes. This
    is an auto-implemented property the getter is public and the setter
    is protected

### Methods:

1.  **<span class="mark">public Account( string type, double balance
    )</span>** – This is the public constructor. It takes two
    parameters: a three-letter string representing the type of the
    account **(“VS-”**, **“SV-”** and **“CK-”** for visa, saving and
    checking account respectively) and a double representing the
    starting balance. The method does the following:

    1.  Sets the Number property to the concatenation (joining) of the
        first argument and the class variable LastNumber

    2.  Increments the class variable LastNumber

    3.  Assigns the second argument to the property Balance

    4.  Assigns the second argument to the property LowestBalance

    5.  Initializes the field **transactions** to an empty list of
        **Transactions**.

    6.  Initializes the field **users** to an empty list of **Persons**.

This constructor is called in the constructors on the three derived
classes

2.  **<span class="mark">public void Deposit( double amount,</span>
    Person <span class="mark">person )</span>** – This public method
    take a double parameter representing the amount to change balance by
    and a person object representing the person who is performing this
    transaction. This method does the following:

    1.  Increase (or decrease) the property Balance by the amount
        specified by its argument.

    2.  Update the property LowestBalance based on the current value of
        Balance.

    3.  Create a Transaction object based on the account Number, the
        amount (specified by the argument), a person object (specified
        by the argument.

    4.  Adds the above object to the list of **transactions**

This is method is called by the **Deposit** and **Withdraw** methods of
the derived classes **CheckingAccount** and **SavingsAccount** as well
as the **DoPurchase** and **DoPayment** of the **VisaAccount** class.

This method does not display anything, nor does it return a value.

3.  **<span class="mark">public void AddUser(</span> Person
    <span class="mark">person )</span>** – This public method takes a
    person object as a parameter. It adds the argument to holders (the
    list of persons). This method does not return a value, nor does it
    display anything on the screen.

4.  **<span class="mark">public bool IsUser( string name )</span>** –
    This public method that takes a string parameter representing the
    name of the user and returns true if the argument matches the name
    of a person in holders (the list of persons) and false otherwise.  
    You cannot use the Contains method of the list class because the
    list is a list of persons and not a list of strings. ~~You will have
    to use a loop to check each person in the collection~~. Use linq to
    implement this method.  
    This method does not display anything on screen.

**Note**: This is not a sound design because it is possible that
multiple users will have the same name

5.  ***<span class="mark">public abstract void PrepareMonthlyReport(
    )</span>**– This abstract public method does not take any parameter
    nor does it return a value.  
    Research how to declare an abstract method.  
    This method is implemented in the classes derived from Accounts.*

6.  **public virtual void OnTransactionOccur(object sender, EventArgs
    args)** – This public method invoke the **EventHandler**
    **OnTransaction** with its two arguments. This method does not
    return a value, nor does it display anything on the screen.

7.  **<span class="mark">public override string ToString( )</span>** –
    This method overrides the same method of the Object class. It does
    not take any parameter but returns a string representation of this
    account. It does the following:

    1.  Declare and initialise a string variable to store the return
        value and add the following to it:

        - The Number of this account

        - The names of each of the users of the account

        - The Balance

        - All the transactions

## CheckingAccount class

You will implement the CheckingAccount Class in Visual Studio. This is a
sub class is derived from the Account class and implements the
ITransaction interface. There are two class variables i.e. variables
that are shared but all the objects of this class. A short description
of the class members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>CheckingAccount</strong></p>
<p>Class</p>
<p>→ Account, ITransaction</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$- COST_PER_TRANSACTION = 0.05 : <strong>double</strong></p>
<p>$- INTEREST_RATE = 0.005 : <strong>double</strong></p>
<p>- hasOverdraft : <strong>bool</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» CheckingAccount(</p>
<p>balance = 0 : <strong>double</strong>,</p>
<p>hasOverdraft = false: <strong>bool</strong>)</p>
<p>+ Deposit(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ Withdraw(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ PrepareMonthlyReport() : <strong>void</strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

1.  **<span class="mark">COST_PER_TRANSACTION</span>** – this is a class
    variable of type double representing the unit cost per transaction.
    All of the objects on this class will have the same value. This
    class variable is initialized to **0.05**.

2.  **<span class="mark">INTEREST_RATE</span>** – this is a class
    variable of type double representing the annual interest rate. All
    of the objects on this class will have the same value. This class
    variable is initialized to **0.005**.

3.  **<span class="mark">hasOverdraft</span>** – this is a bool
    indicating if the balance on this account can be less than zero.
    This private instance variable is set in the constructor.

### Methods:

1.  **<span class="mark">public CheckingAccount( double balance = 0,
    bool hasOverdraft = false )</span>** – This public constructor takes
    a parameter of type double representing the starting balance of the
    account and a bool indicating if this account has over draft
    permission. The constructor does the following:

    1.  It invokes the base constructor with the string “CK-” and the
        appropriate argument.  
        \[It uses the dictionary ACCOUNT_TYPE and the enum AccountType
        to obtain the two letter prefix for this account type\]

    2.  Assigns the hasOverdraft argument to the appropriate field.

2.  **<span class="mark">public new void Deposit( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    deposited and a person object representing the person do the
    transaction. The method does the following:

This definition hides the corresponding member in the parent class
because the base class implementation is needed for this method as well
as the Withdraw() method

1.  Calls the **Deposit()** method of the base class with the
    appropriate arguments.

2.  Calls the **OnTransactionOccur()** method of the base class with the
    appropriate arguments.

    1.  The second argument TransactionEventArgs needs the name of the
        person, the amount and true (success of the operation)

<!-- -->

3.  **<span class="mark">public void Withdraw( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    withdrawn and a person object representing the person do the
    transaction. The method does the following:

    1.  If this person in not associated with this account, it does the
        following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments. Read the above Deposit()
            method for more explanation

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object

    2.  If this person in not logged in, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    3.  If the withdrawal amount is greater than the balance and there
        is no overdraft facility, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    4.  Otherwise, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  calls the **Deposit()** method of the base class with the
            appropriate arguments (you will send negative of the amount)

4.  **<span class="mark">public override void PrepareMonthlyReport(
    )</span>** – this public method override the method of the base
    class with the same name. The method does the following:

    1.  Calculate the service charge by multiplying the number of
        transactions by the
        **<span class="mark">COST_PER_TRANSACTION</span>** (how can you
        find out the number of transactions?).

    2.  Calculate the interest by multiplying the
        **<span class="mark">LowestBalance</span>** by the
        **<span class="mark">INTEREST_RATE</span>** and then dividing by
        12.

    3.  Update the **<span class="mark">Balance</span>** by adding the
        interest and subtracting the service charge.

    4.  Re-initializes the collection
        **<span class="mark">transactions</span>** (use the **Clear()**
        method of the list class)

This method does not take any parameter, nor does it display anything

In a real-world application, the transaction objects would be archived
before clearing.

## SavingAccount class

You will implement the SavingAccount Class in Visual Studio. This is a
sub class derived from the **Account** class and implements the
**ITransaction** interface. Again, there are two class variables. A
short description of the class members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>SavingAccount</strong></p>
<p>Class</p>
<p>→ Account, ITransaction</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$- COST_PER_TRANSACTION = 0.5 : <strong>double</strong></p>
<p>$- INTEREST_RATE = 0.015 : <strong>double</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» SavingAccount(</p>
<p>balance = 0 : <strong>double</strong>,</p>
<p>hasOverdraft = false: <strong>bool</strong>)</p>
<p>+ + Deposit(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ Withdraw(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ PrepareMonthlyReport() : <strong>void</strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

1.  **<span class="mark">COST_PER_TRANSACTION</span>** – this is a class
    variable of type double representing the unit cost per transaction.
    All of the objects on this class will have the same value. This
    class variable is initialized to **0.05**.

2.  **<span class="mark">INTEREST_RATE</span>** – this is a class
    variable of type double representing the annual interest rate. All
    of the objects on this class will have the same value. This class
    variable is initialized to **0.015**.

### Methods:

1.  **<span class="mark">public SavingAccount( double balance = 0
    )</span>** – This public constructor takes a parameter of type
    double representing the starting balance of the account. The
    constructor does the following:

    1.  It invokes the base constructor with the string “SV-” and its
        argument.  
        \[It uses the dictionary ACCOUNT_TYPE and the enum AccountType
        to obtain the two letter prefix for this account type\]

<!-- -->

5.  **<span class="mark">public new void Deposit( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    deposited and a person object representing the person do the
    transaction. This method does the following:

    1.  Calls the **Deposit()** method of the base class with the
        appropriate arguments.

    2.  Calls the **OnTransactionOccur()** method of the base class with
        the appropriate arguments.

        1.  The second argument TransactionEventArgs needs the name of
            the person, the amount and true (success of the operation)

<!-- -->

2.  **<span class="mark">public void Withdraw( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    withdrawn and a person object representing the person do the
    transaction. The method does the following:

    1.  If this person in not associated with this account, it does the
        following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments. Read the above Deposit()
            method for more explanation

        2.  Throws the appropriate **AccountException** object

    2.  If this person in not logged in, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    3.  If the withdrawal amount is greater than the balance and there
        is no overdraft facility, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    4.  Otherwise it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  calls the **Deposit()** method of the base class with the
            appropriate arguments (you will send negative of the amount)

3.  **<span class="mark">public override void PrepareMonthlyReport(
    )</span>** – this public method override the method of the base
    class with the same name. The method does the following:

    1.  Calculate the service charge by multiplying the number of
        transactions by the
        **<span class="mark">COST_PER_TRANSACTION</span>** (how can you
        find out the number of transactions?)

    2.  Calculate the interest by multiplying the
        **<span class="mark">LowestBalance</span>** by the
        **<span class="mark">INTEREST_RATE</span>** and then dividing by
        12

    3.  Update the **<span class="mark">Balance</span>** by adding the
        interest and subtracting the service charge

    4.  **<span class="mark">transactions</span>** is re-initialized
        (use the **Clear()** method of the list class)

This method does not take any parameters, nor does it display anything

## VisaAccount class

You will implement the VisaAccount Class in Visual Studio. This is a sub
class derived from the **Account** class and implements **ITransaction**
interface. This class has a single class variable. A short description
of the class members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>VisaAccount</strong></p>
<p>Class</p>
<p>→ Account, ITransaction</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>- creditLimit : <strong>double</strong></p>
<p>$- INTEREST_RATE = 0.1995 : <strong>double</strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «Constructor» VisaAccount(</p>
<p>balance = 0 : <strong>double</strong>,</p>
<p>creditLimit = 1200: <strong>double</strong>)</p>
<p>+ DoPayment(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ DoPurchase(</p>
<p>amount : <strong>double</strong>,</p>
<p>person : <strong>Person</strong>) : <strong>void</strong></p>
<p>+ PrepareMonthlyReport() : <strong>void</strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

1.  **<span class="mark">creditLimit</span>** – this is a double
    representing the maximum balance allowable on this account. This
    private instance variable is set in the constructor.

2.  **<span class="mark">INTEREST_RATE</span>** – this is a class
    variable of type double representing the annual interest rate. All
    of the objects on this class will have the same value. This class
    variable is initialized to **0.1995**.

### Methods:

1.  **<span class="mark">public VisaAccount( double balance = 0, double
    creditLimit = 1200 )</span>** – This public constructor takes a
    parameter of type double representing the starting balance of the
    account and a double representing the credit limit of this account.
    The constructor does the following:

    1.  It invokes the base constructor with the string “VS-” and the
        appropriate argument.  
        \[It uses the dictionary ACCOUNT_TYPE and the enum AccountType
        to obtain the two letter prefix for this account type\]

    2.  Assigns the argument to the appropriate field

<!-- -->

6.  **<span class="mark">public void DoPayment( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    deposited and a person object representing the person do the
    transaction. This method does the following:

    1.  Calls the **Deposit()** method of the base class with the
        appropriate arguments.

    2.  Calls the **OnTransactionOccur()** method of the base class with
        the appropriate arguments.

        1.  The second argument TransactionEventArgs needs the name of
            the person, the amount and true (success of the operation).

<!-- -->

2.  **<span class="mark">public void DoPurchase( double amount,</span>
    Person <span class="mark">person )</span>** – this public method
    takes two arguments: a double representing the amount to be
    withdrawn and a person object representing the person do the
    transaction. The method does the following:

    1.  If this person in not associated with this account, it does the
        following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments. Read the above Deposit()
            method for more explanation

        2.  Throws the appropriate **AccountException** object

    2.  If this person in not logged in, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    3.  If the withdrawal amount is greater than the balance and there
        is no overdraft facility, it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  Throws the appropriate
            <span class="mark"></span>**AccountException** object.

    4.  Otherwise it does the following:

        1.  Calls the **OnTransactionOccur()** method of the base class
            with the appropriate arguments.

        2.  calls the **Deposit()** method of the base class with the
            appropriate arguments (you will send negative of the amount)

3.  **<span class="mark">public override void PrepareMonthlyReport(
    )</span>** – this public method override the method of the base
    class with the same name. The method does the following:

    1.  Calculate the interest by multiplying the
        **<span class="mark">LowestBalance</span>** by the
        **<span class="mark">InterestRate</span>** and then dividing by
        12

    2.  Update the Balance by subtraction the interest

    3.  Transactions is re-initialized

This method does not take any parameter nor does it display anything

## Bank class

You will implement the Bank Class in Visual Studio. This is a static
class where all its members are also static. \[All the members of a
static class must also be declared static.\] A short description of the
class members is given below:

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Bank</strong></p>
<p>Static Class</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$+ «readonly» ACCOUNTS :
<strong>Dictionary</strong>&lt;<strong>string</strong>,
<strong>Account</strong>&gt;</p>
<p>$+ «readonly» USERS :
<strong>Dictionary</strong>&lt;<strong>string</strong>,
<strong>Person</strong>&gt;</p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>$ «Constructor» Bank()</p>
<p>$+ AddPerson(</p>
<p>name : <strong>string</strong>,</p>
<p>sin : <strong>string</strong>) : <strong>void</strong></p>
<p>$+ AddAccount(</p>
<p>account : <strong>Account</strong>) : <strong>void</strong></p>
<p>$+ AddUserToAccount(</p>
<p>number : <strong>string</strong>,</p>
<p>name : <strong>string</strong>) : <strong>void</strong></p>
<p>$+ GetAccount(number : <strong>string</strong>) :
<strong>Account</strong></p>
<p>$+ GetPerson(name : <strong>string</strong>) :
<strong>Person</strong></p>
<p>$+ PrintAccounts() : <strong>void</strong></p>
<p>$+ PrintUsers() : <strong>void</strong></p>
<p>$+ GetAllTransactions() :
<strong>List</strong>&lt;<strong>Transaction</strong>&gt;</p>
</blockquote></td>
</tr>
</tbody>
</table>

### Fields:

1.  **<span class="mark">ACCOUNTS</span>** – this public readonly class
    variable is a dictionary of account. It is initialized at
    declaration.

2.  **<span class="mark">USERS</span>** – this public readonly class
    variable is a dictionary of person. It is initialized at
    declaration.

### Methods:

1.  **<span class="mark">static Bank( )</span>** – This static
    constructor contains the following statements to initialize the
    USERS and ACCOUNTS collections.

``` cs
//initialize the USERS collection

AddPerson("Narendra", "1234-5678"); //0

AddPerson("Ilia", "2345-6789"); //1

AddPerson("Mehrdad", "3456-7890"); //2

AddPerson("Vijay", "4567-8901"); //3

AddPerson("Arben", "5678-9012"); //4

AddPerson("Patrick", "6789-0123"); //5

AddPerson("Yin", "7890-1234"); //6

AddPerson("Hao", "8901-2345"); //7

AddPerson("Jake", "9012-3456"); //8

AddPerson("Mayy", "1224-5678"); //9

AddPerson("Nicoletta", "2344-6789"); //10

//initialize the ACCOUNTS collection

AddAccount(new VisaAccount()); //VS-100000

AddAccount(new VisaAccount(150, -500)); //VS-100001

AddAccount(new SavingAccount(5000)); //SV-100002

AddAccount(new SavingAccount()); //SV-100003

AddAccount(new CheckingAccount(2000)); //CK-100004

AddAccount(new CheckingAccount(1500, true));//CK-100005

AddAccount(new VisaAccount(50, -550)); //VS-100006

AddAccount(new SavingAccount(1000)); //SV-100007

//associate users with accounts

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

AddUserToAccount(number, "Nicoletta")

number = "CK-100004";

AddUserToAccount(number, "Mehrdad");

AddUserToAccount(number, "Arben");

AddUserToAccount(number, "Yin");

number = "CK-100005";

AddUserToAccount(number, "Jake");

AddUserToAccount(number, "Nicoletta")

number = "VS-100006";

AddUserToAccount(number, "Ilia");

AddUserToAccount(number, "Vijay");

number = "SV-100007";

AddUserToAccount(number, "Patrick");

AddUserToAccount(number, "Hao");

```

2.  **<span class="mark">public static void PrintAccounts( )</span>** –
    this public static method displays all the accounts in the ACCOUNTS
    collection

3.  **<span class="mark">public static void PrintPersons( )</span>** –
    this public static method displays all the persons in the USERS
    collection

4.  **<span class="mark">public static</span> Person
    <span class="mark">GetPerson( string name )</span>** – this public
    static method takes a string representing the name of a person and
    returns the matching person object. This method does the following:

    1.  Check if the argument is present in the key of the static
        collection USERS.

    2.  If the argument is present the value part of this pair is
        returned.

    3.  Else the appropriate **AccountException** object is thrown

This method does not display anything on screen

5.  **<span class="mark">public static</span> Account
    <span class="mark">GetAccount( string number )</span>** – this
    public static method takes a string representing an account number
    and returns the matching account. This method does the following:

    1.  Check if the argument is present in the key of the static
        collection ACCOUNTS.

    2.  If the argument is present the value part of this pair is
        returned.

    3.  Else the appropriate **AccountException** object is thrown

6.  **<span class="mark">public static void AddPerson(string name,
    string sin)</span>** – this method takes two strings and does the
    following:

<!-- -->

1.  Creates a Person object with the two arguments.

2.  Add the static method **LoginHandler()** of the **Logger** class to
    the **Eventhandler** field (OnLogin) of the above object.

3.  Adds a key-value pair to the USERS collection. The key is the first
    argument and the value is the object in Step A respectively.

<!-- -->

7.  **<span class="mark">public static void AddAccount(</span>Account
    <span class="mark">account)</span>** – this method takes an account
    argument and does the following:

<!-- -->

1.  Add the static method **TransactionHandler()** of the **Logger**
    class to the **Eventhandler** field (OnTransaction) of the argument.

2.  Adds a key-value pair to the ACCOUNTS collection. The key is the
    Number property of the argument and the value is the actual argument
    respectively.

<!-- -->

8.  **<span class="mark">public static void AddUserToAccount(string
    number, string name)</span>** – this method takes two string
    arguments and does the following:

<!-- -->

1.  Locates the account matching the first argument.

2.  Locates the person matching the second argument.

3.  Invokes the AddUser() method on the account object and passing the
    person object.

## Testing

Use the following code in your test harness.

``` cs
Console.WriteLine("\nAll acounts:");

Bank.PrintAccounts();

Console.WriteLine("\nAll Users:");

Bank.PrintPersons();

Person p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;

p0 = Bank.GetPerson("Narendra");

p1 = Bank.GetPerson("Ilia");

p2 = Bank.GetPerson("Mehrdad");

p3 = Bank.GetPerson("Vijay");

p4 = Bank.GetPerson("Arben");

p5 = Bank.GetPerson("Patrick");

p6 = Bank.GetPerson("Yin");

p7 = Bank.GetPerson("Hao");

p8 = Bank.GetPerson("Jake");

p9 = Bank.GetPerson("Mayy");

p10 = Bank.GetPerson("Nicoletta");

p0.Login("123"); p1.Login("234");

p2.Login("345"); p3.Login("456");

p4.Login("567"); p5.Login("678");

p6.Login("789"); p7.Login("890");

p10.Login("234"); p8.Login("901");

//a visa account

VisaAccount a = Bank.GetAccount("VS-100000") as VisaAccount;

a.Pay(1500, p0);

a.Purchase(200, p1);

a.Purchase(25, p2);

a.Purchase(15, p0);

a.Purchase(39, p1);

a.Pay(400, p0);

Console.WriteLine(a);

a = Bank.GetAccount("VS-100001") as VisaAccount;

a.Pay(500, p0);

a.Purchase(25, p3);

a.Purchase(20, p4);

a.Purchase(15, p5);

Console.WriteLine(a);

//a saving account

SavingAccount b = Bank.GetAccount("SV-100002") as SavingAccount;

b.Withdraw(300, p6);

b.Withdraw(32.90, p6);

b.Withdraw(50, p7);

b.Withdraw(111.11, p8);

Console.WriteLine(b);

b = Bank.GetAccount("SV-100003") as SavingAccount;

b.Deposit(300, p3); //ok even though p3 is not a holder

b.Deposit(32.90, p2);

b.Deposit(50, p5);

b.Withdraw(111.11, p10);

Console.WriteLine(b);

//a checking account

CheckingAccount c = Bank.GetAccount("CK-100004") as CheckingAccount;

c.Deposit(33.33, p7);

c.Deposit(40.44, p7);

c.Withdraw(150, p2);

c.Withdraw(200, p4);

c.Withdraw(645, p6);

c.Withdraw(350, p6);

Console.WriteLine(c);

c = Bank.GetAccount("CK-100005") as CheckingAccount;

c.Deposit(33.33, p8);

c.Deposit(40.44, p7);

c.Withdraw(450, p10);

c.Withdraw(500, p8);

c.Withdraw(645, p10);

c.Withdraw(850, p10);

Console.WriteLine(c);

a = Bank.GetAccount("VS-100006") as VisaAccount;

a.Pay(700, p0);

a.Purchase(20, p3);

a.Purchase(10, p1);

a.Purchase(15, p1);

Console.WriteLine(a);

b = Bank.GetAccount("SV-100007") as SavingAccount;

b.Deposit(300, p3); //ok even though p3 is not a holder

b.Deposit(32.90, p2);

b.Deposit(50, p5);

b.Withdraw(111.11, p7);

Console.WriteLine(b);

Console.WriteLine("\n\nExceptions:");

//The following will cause exception

try

{

p8.Login("911"); //incorrect password

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

p3.Logout();

a.Purchase(12.5, p3); //exception user is not logged in

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

a.Purchase(12.5, p0); //user is not associated with this account

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

a.Purchase(5825, p4); //credit limit exceeded

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

c.Withdraw(1500, p6); //no overdraft

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

Bank.GetAccount("CK-100018"); //account does not exist

}

catch (AccountException e) { Console.WriteLine(e.Message); }

try

{

Bank.GetPerson("Trudeau"); //user does not exist

}

catch (AccountException e) { Console.WriteLine(e.Message); }

//show all transactions

Console.WriteLine("\n\nAll transactions");

foreach(var transaction in Bank.GetAllTransactions())

Console.WriteLine( transaction);

foreach (var keyValuePair in Bank.ACCOUNTS)

{

Account account = keyValuePair.Value;

Console.WriteLine("\nBefore PrepareMonthlyReport()");

Console.WriteLine(account);

Console.WriteLine("\nAfter PrepareMonthlyReport()");

account.PrepareMonthlyReport(); //all transactions are cleared, balance
changes

Console.WriteLine(account);

}

Logger.ShowLoginEvents();

Logger.ShowTransactionEvents();

```

## Sample output

Use the following code in your test harness.

``` txt
All acounts:

[VS-100000, VS-100000 Narendra Not logged in, Ilia Not logged in, Mehrdad Not logged in $0.00 - transactions (0)

]

[VS-100001, VS-100001 Vijay Not logged in, Arben Not logged in, Patrick Not logged in $150.00 - transactions (0)

]

[SV-100002, SV-100002 Yin Not logged in, Hao Not logged in, Jake Not logged in $5,000.00 - transactions (0)

]

[SV-100003, SV-100003 Mayy Not logged in, Nicoletta Not logged in $0.00 - transactions (0)

]

[CK-100004, CK-100004 Mehrdad Not logged in, Arben Not logged in, Yin Not logged in $2,000.00 - transactions (0)

]

[CK-100005, CK-100005 Jake Not logged in, Nicoletta Not logged in $1,500.00 - transactions (0)

]

[VS-100006, VS-100006 Ilia Not logged in, Vijay Not logged in $50.00 - transactions (0)

]

[SV-100007, SV-100007 Patrick Not logged in, Hao Not logged in $1,000.00 - transactions (0)

]

All Users:

[Narendra, Narendra Not logged in]

[Ilia, Ilia Not logged in]

[Mehrdad, Mehrdad Not logged in]

[Vijay, Vijay Not logged in]

[Arben, Arben Not logged in]

[Patrick, Patrick Not logged in]

[Yin, Yin Not logged in]

[Hao, Hao Not logged in]

[Jake, Jake Not logged in]

[Mayy, Mayy Not logged in]

[Nicoletta, Nicoletta Not logged in]

VS-100000 Narendra Logged in, Ilia Logged in, Mehrdad Logged in $1,621.00 - transactions (6)

VS-100000 $1,500.00 deposited by Narendra on 2021-08-18 05:10

VS-100000 $200.00 withdrawn by Ilia on 2021-08-19 09:11

VS-100000 $25.00 withdrawn by Mehrdad on 2021-08-20 01:39

VS-100000 $15.00 withdrawn by Narendra on 2021-08-22 05:21

VS-100000 $39.00 withdrawn by Ilia on 2021-08-24 18:17

VS-100000 $400.00 deposited by Narendra on 2021-08-25 21:58

VS-100001 Vijay Logged in, Arben Logged in, Patrick Logged in $590.00 - transactions (4)

VS-100001 $500.00 deposited by Narendra on 2021-08-27 00:39

VS-100001 $25.00 withdrawn by Vijay on 2021-08-28 23:55

VS-100001 $20.00 withdrawn by Arben on 2021-09-01 09:51

VS-100001 $15.00 withdrawn by Patrick on 2021-09-03 03:46

SV-100002 Yin Logged in, Hao Logged in, Jake Logged in $4,505.99 - transactions (4)

SV-100002 $300.00 withdrawn by Yin on 2021-09-04 20:23

SV-100002 $32.90 withdrawn by Yin on 2021-09-05 17:11

SV-100002 $50.00 withdrawn by Hao on 2021-09-07 08:54

SV-100002 $111.11 withdrawn by Jake on 2021-09-08 16:16

SV-100003 Mayy Not logged in, Nicoletta Logged in $271.79 - transactions (4)

SV-100003 $300.00 deposited by Vijay on 2021-09-10 18:14

SV-100003 $32.90 deposited by Mehrdad on 2021-09-12 20:20

SV-100003 $50.00 deposited by Patrick on 2021-09-13 06:52

SV-100003 $111.11 withdrawn by Nicoletta on 2021-09-15 00:51

CK-100004 Mehrdad Logged in, Arben Logged in, Yin Logged in $728.77 - transactions (6)

CK-100004 $33.33 deposited by Hao on 2021-09-16 10:40

CK-100004 $40.44 deposited by Hao on 2021-09-18 03:03

CK-100004 $150.00 withdrawn by Mehrdad on 2021-09-20 17:27

CK-100004 $200.00 withdrawn by Arben on 2021-09-22 19:01

CK-100004 $645.00 withdrawn by Yin on 2021-09-25 02:44

CK-100004 $350.00 withdrawn by Yin on 2021-09-27 10:29

CK-100005 Jake Logged in, Nicoletta Logged in -$871.23 - transactions (6)

CK-100005 $33.33 deposited by Jake on 2021-09-28 06:51

CK-100005 $40.44 deposited by Hao on 2021-09-29 07:34

CK-100005 $450.00 withdrawn by Nicoletta on 2021-09-30 06:07

CK-100005 $500.00 withdrawn by Jake on 2021-10-01 13:11

CK-100005 $645.00 withdrawn by Nicoletta on 2021-10-02 12:47

CK-100005 $850.00 withdrawn by Nicoletta on 2021-10-03 21:54

VS-100006 Ilia Logged in, Vijay Logged in $705.00 - transactions (4)

VS-100006 $700.00 deposited by Narendra on 2021-10-05 15:16

VS-100006 $20.00 withdrawn by Vijay on 2021-10-06 05:47

VS-100006 $10.00 withdrawn by Ilia on 2021-10-07 19:54

VS-100006 $15.00 withdrawn by Ilia on 2021-10-09 08:31

SV-100007 Patrick Logged in, Hao Logged in $1,271.79 - transactions (4)

SV-100007 $300.00 deposited by Vijay on 2021-10-10 06:31

SV-100007 $32.90 deposited by Mehrdad on 2021-10-11 13:55

SV-100007 $50.00 deposited by Patrick on 2021-10-12 14:04

SV-100007 $111.11 withdrawn by Hao on 2021-10-13 11:58

Exceptions:

PASSWORD_INCORRECT

USER_NOT_LOGGED_IN

NAME_NOT_ASSOCIATED_WITH_ACCOUNT

NAME_NOT_ASSOCIATED_WITH_ACCOUNT

NAME_NOT_ASSOCIATED_WITH_ACCOUNT

ACCOUNT_DOES_NOT_EXIST

USER_DOES_NOT_EXIST

All transactions

VS-100000 $1,500.00 deposited by Narendra on 2021-08-18 05:10

VS-100000 $200.00 withdrawn by Ilia on 2021-08-19 09:11

VS-100000 $25.00 withdrawn by Mehrdad on 2021-08-20 01:39

VS-100000 $15.00 withdrawn by Narendra on 2021-08-22 05:21

VS-100000 $39.00 withdrawn by Ilia on 2021-08-24 18:17

VS-100000 $400.00 deposited by Narendra on 2021-08-25 21:58

VS-100001 $500.00 deposited by Narendra on 2021-08-27 00:39

VS-100001 $25.00 withdrawn by Vijay on 2021-08-28 23:55

VS-100001 $20.00 withdrawn by Arben on 2021-09-01 09:51

VS-100001 $15.00 withdrawn by Patrick on 2021-09-03 03:46

SV-100002 $300.00 withdrawn by Yin on 2021-09-04 20:23

SV-100002 $32.90 withdrawn by Yin on 2021-09-05 17:11

SV-100002 $50.00 withdrawn by Hao on 2021-09-07 08:54

SV-100002 $111.11 withdrawn by Jake on 2021-09-08 16:16

SV-100003 $300.00 deposited by Vijay on 2021-09-10 18:14

SV-100003 $32.90 deposited by Mehrdad on 2021-09-12 20:20

SV-100003 $50.00 deposited by Patrick on 2021-09-13 06:52

SV-100003 $111.11 withdrawn by Nicoletta on 2021-09-15 00:51

CK-100004 $33.33 deposited by Hao on 2021-09-16 10:40

CK-100004 $40.44 deposited by Hao on 2021-09-18 03:03

CK-100004 $150.00 withdrawn by Mehrdad on 2021-09-20 17:27

CK-100004 $200.00 withdrawn by Arben on 2021-09-22 19:01

CK-100004 $645.00 withdrawn by Yin on 2021-09-25 02:44

CK-100004 $350.00 withdrawn by Yin on 2021-09-27 10:29

CK-100005 $33.33 deposited by Jake on 2021-09-28 06:51

CK-100005 $40.44 deposited by Hao on 2021-09-29 07:34

CK-100005 $450.00 withdrawn by Nicoletta on 2021-09-30 06:07

CK-100005 $500.00 withdrawn by Jake on 2021-10-01 13:11

CK-100005 $645.00 withdrawn by Nicoletta on 2021-10-02 12:47

CK-100005 $850.00 withdrawn by Nicoletta on 2021-10-03 21:54

VS-100006 $700.00 deposited by Narendra on 2021-10-05 15:16

VS-100006 $20.00 withdrawn by Vijay on 2021-10-06 05:47

VS-100006 $10.00 withdrawn by Ilia on 2021-10-07 19:54

VS-100006 $15.00 withdrawn by Ilia on 2021-10-09 08:31

SV-100007 $300.00 deposited by Vijay on 2021-10-10 06:31

SV-100007 $32.90 deposited by Mehrdad on 2021-10-11 13:55

SV-100007 $50.00 deposited by Patrick on 2021-10-12 14:04

SV-100007 $111.11 withdrawn by Hao on 2021-10-13 11:58

Before PrepareMonthlyReport()

VS-100000 Narendra Logged in, Ilia Logged in, Mehrdad Logged in $1,621.00 - transactions (6)

VS-100000 $1,500.00 deposited by Narendra on 2021-08-18 05:10

VS-100000 $200.00 withdrawn by Ilia on 2021-08-19 09:11

VS-100000 $25.00 withdrawn by Mehrdad on 2021-08-20 01:39

VS-100000 $15.00 withdrawn by Narendra on 2021-08-22 05:21

VS-100000 $39.00 withdrawn by Ilia on 2021-08-24 18:17

VS-100000 $400.00 deposited by Narendra on 2021-08-25 21:58

After PrepareMonthlyReport()

VS-100000 Narendra Logged in, Ilia Logged in, Mehrdad Logged in $1,621.00 - transactions (0)

Before PrepareMonthlyReport()

VS-100001 Vijay Not logged in, Arben Logged in, Patrick Logged in $590.00 - transactions (4)

VS-100001 $500.00 deposited by Narendra on 2021-08-27 00:39

VS-100001 $25.00 withdrawn by Vijay on 2021-08-28 23:55

VS-100001 $20.00 withdrawn by Arben on 2021-09-01 09:51

VS-100001 $15.00 withdrawn by Patrick on 2021-09-03 03:46

After PrepareMonthlyReport()

VS-100001 Vijay Not logged in, Arben Logged in, Patrick Logged in $619.92 - transactions (0)

Before PrepareMonthlyReport()

SV-100002 Yin Logged in, Hao Logged in, Jake Not logged in $4,505.99 - transactions (4)

SV-100002 $300.00 withdrawn by Yin on 2021-09-04 20:23

SV-100002 $32.90 withdrawn by Yin on 2021-09-05 17:11

SV-100002 $50.00 withdrawn by Hao on 2021-09-07 08:54

SV-100002 $111.11 withdrawn by Jake on 2021-09-08 16:16

After PrepareMonthlyReport()

SV-100002 Yin Logged in, Hao Logged in, Jake Not logged in $4,573.38 - transactions (0)

Before PrepareMonthlyReport()

SV-100003 Mayy Not logged in, Nicoletta Logged in $271.79 - transactions (4)

SV-100003 $300.00 deposited by Vijay on 2021-09-10 18:14

SV-100003 $32.90 deposited by Mehrdad on 2021-09-12 20:20

SV-100003 $50.00 deposited by Patrick on 2021-09-13 06:52

SV-100003 $111.11 withdrawn by Nicoletta on 2021-09-15 00:51

After PrepareMonthlyReport()

SV-100003 Mayy Not logged in, Nicoletta Logged in $271.59 - transactions (0)

Before PrepareMonthlyReport()

CK-100004 Mehrdad Logged in, Arben Logged in, Yin Logged in $728.77 - transactions (6)

CK-100004 $33.33 deposited by Hao on 2021-09-16 10:40

CK-100004 $40.44 deposited by Hao on 2021-09-18 03:03

CK-100004 $150.00 withdrawn by Mehrdad on 2021-09-20 17:27

CK-100004 $200.00 withdrawn by Arben on 2021-09-22 19:01

CK-100004 $645.00 withdrawn by Yin on 2021-09-25 02:44

CK-100004 $350.00 withdrawn by Yin on 2021-09-27 10:29

After PrepareMonthlyReport()

CK-100004 Mehrdad Logged in, Arben Logged in, Yin Logged in $732.11 - transactions (0)

Before PrepareMonthlyReport()

CK-100005 Jake Not logged in, Nicoletta Logged in -$871.23 - transactions (6)

CK-100005 $33.33 deposited by Jake on 2021-09-28 06:51

CK-100005 $40.44 deposited by Hao on 2021-09-29 07:34

CK-100005 $450.00 withdrawn by Nicoletta on 2021-09-30 06:07

CK-100005 $500.00 withdrawn by Jake on 2021-10-01 13:11

CK-100005 $645.00 withdrawn by Nicoletta on 2021-10-02 12:47

CK-100005 $850.00 withdrawn by Nicoletta on 2021-10-03 21:54

After PrepareMonthlyReport()

CK-100005 Jake Not logged in, Nicoletta Logged in -$875.89 - transactions (0)

Before PrepareMonthlyReport()

VS-100006 Ilia Logged in, Vijay Not logged in $705.00 - transactions (4)

VS-100006 $700.00 deposited by Narendra on 2021-10-05 15:16

VS-100006 $20.00 withdrawn by Vijay on 2021-10-06 05:47

VS-100006 $10.00 withdrawn by Ilia on 2021-10-07 19:54

VS-100006 $15.00 withdrawn by Ilia on 2021-10-09 08:31

After PrepareMonthlyReport()

VS-100006 Ilia Logged in, Vijay Not logged in $714.98 - transactions (0)

Before PrepareMonthlyReport()

SV-100007 Patrick Logged in, Hao Logged in $1,271.79 - transactions (4)

SV-100007 $300.00 deposited by Vijay on 2021-10-10 06:31

SV-100007 $32.90 deposited by Mehrdad on 2021-10-11 13:55

SV-100007 $50.00 deposited by Patrick on 2021-10-12 14:04

SV-100007 $111.11 withdrawn by Hao on 2021-10-13 11:58

After PrepareMonthlyReport()

SV-100007 Patrick Logged in, Hao Logged in $1,286.59 - transactions (0)

Login events as of 2021-10-18 05:02

1 Narendra logged in successfully on 2021-08-09 21:24

2 Ilia logged in successfully on 2021-08-11 00:02

3 Mehrdad logged in successfully on 2021-08-12 09:15

4 Vijay logged in successfully on 2021-08-13 05:23

5 Arben logged in successfully on 2021-08-13 15:16

6 Patrick logged in successfully on 2021-08-14 09:14

7 Yin logged in successfully on 2021-08-14 22:32

8 Hao logged in successfully on 2021-08-15 12:40

9 Nicoletta logged in successfully on 2021-08-15 20:23

10 Jake logged in successfully on 2021-08-16 16:08

11 Jake logged in unsuccessfully on 2021-10-14 01:59

Transaction events as of 2021-10-18 05:02

1 Narendra deposit $1,500.00 successfully on 2021-08-17 07:05

2 Ilia deposit $200.00 successfully on 2021-08-18 19:58

3 Mehrdad deposit $25.00 successfully on 2021-08-19 12:26

4 Narendra deposit $15.00 successfully on 2021-08-21 05:58

5 Ilia deposit $39.00 successfully on 2021-08-23 14:17

6 Narendra deposit $400.00 successfully on 2021-08-25 06:04

7 Narendra deposit $500.00 successfully on 2021-08-26 03:11

8 Vijay deposit $25.00 successfully on 2021-08-27 16:59

9 Arben deposit $20.00 successfully on 2021-08-30 05:42

10 Patrick deposit $15.00 successfully on 2021-09-01 22:08

11 Yin deposit $300.00 successfully on 2021-09-04 13:01

12 Yin deposit $32.90 successfully on 2021-09-05 11:14

13 Hao deposit $50.00 successfully on 2021-09-06 07:43

14 Jake deposit $111.11 successfully on 2021-09-07 12:20

15 Vijay deposit $300.00 successfully on 2021-09-09 14:05

16 Mehrdad deposit $32.90 successfully on 2021-09-11 16:50

17 Patrick deposit $50.00 successfully on 2021-09-13 02:42

18 Nicoletta deposit $111.11 successfully on 2021-09-13 23:30

19 Hao deposit $33.33 successfully on 2021-09-16 08:38

20 Hao deposit $40.44 successfully on 2021-09-17 01:40

21 Mehrdad deposit $150.00 successfully on 2021-09-19 11:17

22 Arben deposit $200.00 successfully on 2021-09-22 01:01

23 Yin deposit $645.00 successfully on 2021-09-23 21:42

24 Yin deposit $350.00 successfully on 2021-09-26 04:27

25 Jake deposit $33.33 successfully on 2021-09-27 22:25

26 Hao deposit $40.44 successfully on 2021-09-28 15:46

27 Nicoletta deposit $450.00 successfully on 2021-09-30 04:37

28 Jake deposit $500.00 successfully on 2021-09-30 17:15

29 Nicoletta deposit $645.00 successfully on 2021-10-02 08:42

30 Nicoletta deposit $850.00 successfully on 2021-10-02 22:48

31 Narendra deposit $700.00 successfully on 2021-10-04 20:47

32 Vijay deposit $20.00 successfully on 2021-10-05 21:04

33 Ilia deposit $10.00 successfully on 2021-10-06 23:57

34 Ilia deposit $15.00 successfully on 2021-10-08 06:25

35 Vijay deposit $300.00 successfully on 2021-10-09 14:23

36 Mehrdad deposit $32.90 successfully on 2021-10-11 05:38

37 Patrick deposit $50.00 successfully on 2021-10-12 06:37

38 Hao deposit $111.11 successfully on 2021-10-13 10:12

39 Vijay deposit $12.50 unsuccessfully on 2021-10-15 10:24

40 Narendra deposit $12.50 unsuccessfully on 2021-10-16 14:19

41 Arben deposit $5,825.00 unsuccessfully on 2021-10-17 13:56

42 Yin deposit $1,500.00 unsuccessfully on 2021-10-18 05:02
```

## Appendix

Copy the following statements to your Utils class

``` cs
//this class depends of the implementation of the following types:

//DayTime struct and AccountType enum

public static class Utils

{

static DayTime \_time = new DayTime(1_048_000_000);

static Random random = new Random();

public static DayTime Time

{

get =\> \_time += random.Next(1000);

}

public static DayTime Now

{

get =\> \_time += 0;

}

public readonly static Dictionary\<AccountType, string\> ACCOUNT_TYPES =

new Dictionary\<AccountType, string\>

{

{ AccountType.Checking , "CK" },

{ AccountType.Saving , "SV" },

{ AccountType.Visa , "VS" }

};

}
```