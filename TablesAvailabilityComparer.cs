namespace ConsoleAppRestaurantTableReservationManager;

public class TablesAvailabilityComparer : IComparer<Restaurant>
{
    private readonly DateTime _date;

    public TablesAvailabilityComparer(DateTime date)
    {
        _date = date;
    }
    
    public int Compare(Restaurant x, Restaurant y)
    {
        var xAvailableTableCount = CountAvailableTables(x, _date);
        var yAvailableTableCount = CountAvailableTables(y, _date);

        if (xAvailableTableCount > yAvailableTableCount)
        {
            return 1;
        }

        if (xAvailableTableCount < yAvailableTableCount)
        {
            return -1;
        }
        
        return 0;
    }
    
    private int CountAvailableTables(Restaurant restaurant, DateTime date)
    {
        return restaurant.Tables.Count(table => !table.IsBooked(date));
    }
}