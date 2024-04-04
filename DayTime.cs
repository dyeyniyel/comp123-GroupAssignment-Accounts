namespace Assignment_04_Accounts;

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
        long day = remainingMinutes / (24 * 60);
        remainingMinutes %= (24 * 60);
        long hour = remainingMinutes / 60;
        remainingMinutes %= 60;
        long minute = remainingMinutes;

        long year = day / 365;
        day %= 365;
        long month = day / 30; // Approximation, as not all months have 30 days
        day %= 30;

        return $"{2024:0000}-{month + 1:00}-{day + 1:00} {hour:00}:{minute:00}";
    }

}
