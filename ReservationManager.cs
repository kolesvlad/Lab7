using Serilog;

namespace ConsoleAppRestaurantTableReservationManager;

public class ReservationManager
{
    private readonly List<Restaurant> _restaurants = new();

    public void AddRestaurant(string name, int tableCount)
    {
        try
        {
            var restaurant = new Restaurant(name, new Table[tableCount]);
            for (var i = 0; i < tableCount; i++)
            {
                restaurant.Tables[i] = new Table();
            }
            _restaurants.Add(restaurant);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
    
    public bool BookTable(string restaurantName, DateTime date, int tableCount)
    {
        foreach (var restaurant in _restaurants.Where(restaurant => restaurant.Name == restaurantName))
        {
            if (tableCount < 0 || tableCount >= restaurant.Tables.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(tableCount), "Invalid table count.");
            }

            return restaurant.Tables[tableCount].Book(date);
        }

        throw new ArgumentException("Restaurant not found.");
    }

    // Load Restaurants From
    // File
    private void LoadRestaurantsFromFileMethod(string fileP)
    {
        try
        {
            string[] ls = File.ReadAllLines(fileP);
            foreach (string l in ls)
            {
                var parts = l.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int tableCount))
                {
                    AddRestaurant(parts[0], tableCount);
                }
                else
                {
                    Console.WriteLine(l);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
        }
    }

    //Find All Free Tables
    public List<string> FindAllFreeTables(DateTime dt)
    {
        try
        { 
            List<string> free = new List<string>();
            foreach (var r in res)
            {
                for (int i = 0; i < r.t.Length; i++)
                {
                    if (!r.t[i].IsBooked(dt))
                    {
                        free.Add($"{r.n} - Table {i + 1}");
                    }
                }
            }
            return free;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            return new List<string>();
        }
    }

    public void SortRestaurantsByAvailabilityForUsersMethod(DateTime dt)
    {
        try
        { 
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < res.Count - 1; i++)
                {
                    int avTc = CountAvailableTablesForRestaurantClassAndDateTimeMethod(res[i], dt); // available tables current
                    int avTn = CountAvailableTablesForRestaurantClassAndDateTimeMethod(res[i + 1], dt); // available tables next

                    if (avTc < avTn)
                    {
                        // Swap restaurants
                        var temp = res[i];
                        res[i] = res[i + 1];
                        res[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
        }
    }

    // count available tables in a restaurant
    public int CountAvailableTablesForRestaurantClassAndDateTimeMethod(Restaurant r, DateTime dt)
    {
        try
        {
            int count = 0;
            foreach (var t in r.t)
            {
                if (!t.IsBooked(dt))
                {
                    count++;
                }
            }
            return count;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            return 0;
        }
    }
}


