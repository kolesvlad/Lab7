using Serilog;

namespace ConsoleAppRestaurantTableReservationManager;

public static class RestaurantRepository
{
    
    public static Dictionary<string, int> LoadRestaurantsFromFile(string filePath)
    {
        var restaurantsData = new Dictionary<string, int>();
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out var tableCount))
                {
                    restaurantsData.Add(parts[0], tableCount);
                }
            }
        }
        catch (IOException ex)
        {
            Log.Error(ex.Message);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        
        return restaurantsData;
    }
}