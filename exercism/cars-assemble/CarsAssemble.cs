static class AssemblyLine
{
    public static double SuccessRate(int speed) => speed switch
    {
        0 => 0.0,
        >= 1 and <= 4 => 1.0,
        >= 5 and <= 8 => 0.9,
        9 => 0.8,
        10 => 0.77,
        _ => throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be between 0 and 10 inclusive.")
    };

    public static double ProductionRatePerHour(int speed)
    {
        const int carsPerHour = 221;
        double successRate = SuccessRate(speed);
        return speed * carsPerHour * successRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double productionRate = ProductionRatePerHour(speed);
        return (int)(productionRate / 60);
    }
}