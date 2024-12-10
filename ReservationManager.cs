namespace ConsoleAppRestaurantTableReservationManager;

public class ReservationManager
{
    private readonly List<Restaurant> _restaurants = new();

    public void AddRestaurant(string n, int t)
    {
        try
        {
            Restaurant r = new Restaurant();
            r.n = n;
            r.t = new RestaurantTableClass[t];
            for (int i = 0; i < t; i++)
            {
                r.t[i] = new RestaurantTableClass();
            }
            _restaurants.Add(r);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
        }
    }
    
    public bool BookTable(string rName, DateTime d, int tNumber)
    {
        foreach (var r in _restaurants)
        {
            if (r.n == rName)
            {
                if (tNumber < 0 || tNumber >= r.t.Length)
                {
                    throw new Exception(null); //Invalid table number
                }

                return r.t[tNumber].Book(d);
            }
        }

        throw new Exception(null); //Restaurant not found
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

// Restaurant Class
public class Restaurant
{
    public string n; //name
    public RestaurantTableClass[] t; // tables
}

// Table Class
public class RestaurantTableClass
{
    private List<DateTime> bd; //booked dates


    public RestaurantTableClass()
    {
        bd = new List<DateTime>();
    }

    // book
    public bool Book(DateTime d)
    {
        try
        { 
            if (bd.Contains(d))
            {
                return false;
            }
            //add to bd
            bd.Add(d);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            return false;
        }
    }

    // is booked
    public bool IsBooked(DateTime d)
    {
        return bd.Contains(d);
    }
}