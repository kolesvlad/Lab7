namespace ConsoleAppRestaurantTableReservationManager;

public class TablesAvailabilityComparer(DateTime date) : IComparer<Restaurant>
{
    public int Compare(Restaurant x, Restaurant y)
    {
        var xAvailableTableCount = CountAvailableTables(x, date);
        var yAvailableTableCount = CountAvailableTables(y, date);

        if (xAvailableTableCount > yAvailableTableCount)
        {
            return -1;
        }

        if (xAvailableTableCount < yAvailableTableCount)
        {
            return 1;
        }
        
        return 0;
    }
    
    public static int CountAvailableTables(Restaurant restaurant, DateTime date)
    {
        return restaurant.Tables.Count(table => !table.IsBooked(date));
    }
}