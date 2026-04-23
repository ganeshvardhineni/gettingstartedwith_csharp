using System;

class InsufficientBalanceException : Exception
{
    public double CurrentBalance { get; }
    public double AttemptedAmount { get; }

    public InsufficientBalanceException(double current, double attempted)
        : base($"Can't withdraw ₹{attempted:F2}. Current balance is ₹{current:F2} and minimum balance of ₹1000 must be maintained.")
    {
        CurrentBalance = current;
        AttemptedAmount = attempted;
    }
}

class InvalidAmountException : Exception
{
    public double AttemptedAmount { get; }

    public InvalidAmountException(double amount)
        : base($"₹{amount:F2} is not a valid amount. Please enter a value greater than zero.")
    {
        AttemptedAmount = amount;
    }
}

class BankAccount
{
    private const double MinimumBalance = 1000;

    public string AccountHolderName { get; }
    public double Balance { get; private set; }

    public BankAccount(string name, double openingBalance)
    {
        if (openingBalance < MinimumBalance)
            throw new InsufficientBalanceException(openingBalance, 0);

        AccountHolderName = name;
        Balance = openingBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException(amount);

        Balance += amount;
        Console.WriteLine($"Deposited ₹{amount:F2}. New balance: ₹{Balance:F2}");
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException(amount);

        if (amount > Balance)
            throw new InsufficientBalanceException(Balance, amount);

        if (Balance - amount < MinimumBalance)
            throw new InsufficientBalanceException(Balance, amount);

        Balance -= amount;
        Console.WriteLine($"Withdrew ₹{amount:F2}. New balance: ₹{Balance:F2}");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account: {AccountHolderName} | Balance: ₹{Balance:F2}");
    }
}

class Program
{
    static void TryDeposit(BankAccount account, double amount)
    {
        try
        {
            account.Deposit(amount);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"Invalid deposit: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error during deposit: {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"Deposit attempt of ₹{amount:F2} finished.\n");
        }
    }

    static void TryWithdraw(BankAccount account, double amount)
    {
        try
        {
            account.Withdraw(amount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Withdrawal blocked: {ex.Message}");
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"Invalid withdrawal: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error during withdrawal: {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"Withdrawal attempt of ₹{amount:F2} finished.\n");
        }
    }

    static void Main()
    {
        BankAccount account = null;

        Console.WriteLine("=== Opening account ===");
        try
        {
            account = new BankAccount("Ananya Sharma", 5000);
            Console.WriteLine($"Account opened for {account.AccountHolderName} with ₹{account.Balance:F2}\n");
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Couldn't open account: {ex.Message}");
            return;
        }

        Console.WriteLine("=== Checking balance ===");
        account.CheckBalance();
        Console.WriteLine();

        Console.WriteLine("=== Valid deposit ===");
        TryDeposit(account, 2000);

        Console.WriteLine("=== Deposit with zero amount (US4) ===");
        TryDeposit(account, 0);

        Console.WriteLine("=== Deposit with negative amount (US4) ===");
        TryDeposit(account, -500);

        Console.WriteLine("=== Valid withdrawal ===");
        TryWithdraw(account, 1000);

        Console.WriteLine("=== Withdrawal that exceeds balance (US3) ===");
        TryWithdraw(account, 50000);

        Console.WriteLine("=== Withdrawal that would break minimum balance rule (US3) ===");
        TryWithdraw(account, 5500);

        Console.WriteLine("=== Withdrawal with invalid amount ===");
        TryWithdraw(account, -200);

        Console.WriteLine("=== Withdrawal with zero ===");
        TryWithdraw(account, 0);

        Console.WriteLine("=== Final balance ===");
        account.CheckBalance();

        Console.WriteLine("\n=== Trying to open account below minimum balance ===");
        try
        {
            var poorAccount = new BankAccount("Rohan Mehta", 500);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Account creation failed: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Account opening attempt finished.");
        }
    }
}