namespace ConsoleAppRestaurantTableReservationManager;

public class Table
{
    private readonly List<DateTime> _bookedDates = [];
    
    public bool Book(DateTime date)
    {
        if (_bookedDates.Contains(date))
        { 
            return false;
        }
        
        _bookedDates.Add(date);
        return true;
    }
    
    public bool IsBooked(DateTime date)
    {
        return _bookedDates.Contains(date);
    }
}