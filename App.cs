using Serilog;

namespace ConsoleAppRestaurantTableReservationManager;

public static class App
{
    public static void Main()
    {
        Initialize();
        
        try
        {
            var manager = new ReservationManager();
            
            manager.AddRestaurant("A", 10);
            manager.AddRestaurant("B", 5);

            manager.BookTable("A", new DateTime(2023, 12, 25), 3); // True
            manager.BookTable("A", new DateTime(2023, 12, 25), 3); // False
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong");
        }
        finally
        {
            Log.CloseAndFlushAsync();
        }
    }

    private static void Initialize()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }
}