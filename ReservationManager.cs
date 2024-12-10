namespace ConsoleAppRestaurantTableReservationManager;

public class ReservationManager
{
    private readonly List<Restaurant> _restaurants = [];

    public void AddRestaurant(string name, int tableCount)
    {
        var restaurant = new Restaurant(name, new Table[tableCount]);
        
        for (var i = 0; i < tableCount; i++)
        {
            restaurant.Tables[i] = new Table();
        }

        _restaurants.Add(restaurant);
    }
    
    public bool BookTable(string restaurantName, DateTime date, int tableIndex)
    {
        foreach (var restaurant in _restaurants.Where(restaurant => restaurant.Name == restaurantName))
        {
            if (tableIndex < 0 || tableIndex >= restaurant.Tables.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(tableIndex), "Invalid table number.");
            }

            return restaurant.Tables[tableIndex].Book(date);
        }

        throw new ArgumentException("Restaurant not found.");
    }

    public void LoadRestaurants(string filePath)
    {
        var restaurantsData = RestaurantRepository.LoadRestaurantsFromFile(filePath);
        foreach (var restaurantData in restaurantsData)
        {
            AddRestaurant(restaurantData.Key, restaurantData.Value);
        }
    }

    public List<string> FindAllFreeTables(DateTime date)
    {
        var freeTables = new List<string>();

        foreach (var restaurant in _restaurants)
        {
            for (var i = 0; i < restaurant.Tables.Length; i++)
            {
                if (!restaurant.Tables[i].IsBooked(date))
                {
                    freeTables.Add($"{restaurant.Name} - Table {i + 1}");
                }
            }
        }

        return freeTables;
    }

    public void SortRestaurantsByTablesAvailability(DateTime date)
    {
        _restaurants.Sort(new TablesAvailabilityComparer(date));
    }
}


