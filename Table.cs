using Serilog;

namespace ConsoleAppRestaurantTableReservationManager;

public class Table
{
    private readonly List<DateTime> _bookedDates = new();
    
    public bool Book(DateTime date)
    {
        try
        {
            if (_bookedDates.Contains(date))
            {
                return false;
            }

            _bookedDates.Add(date);
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
    
    public bool IsBooked(DateTime date)
    {
        return _bookedDates.Contains(date);
    }
}