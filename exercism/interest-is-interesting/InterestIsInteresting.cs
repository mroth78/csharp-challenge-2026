static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch
        {
            < 0m => 3.213f,
            >= 0m and < 1_000m => 0.5f,
            >= 1_000m and < 5_000m => 1.621f,
            _ => 2.475f
        };
    }

    public static decimal Interest(decimal balance)
    {
        float rate = InterestRate(balance);
        return balance * (decimal)rate / 100m;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        decimal interest = Interest(balance);
        return balance + interest;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (balance >= targetBalance)
        {
            return 0;
        }

        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        
        return years;
    }
}
