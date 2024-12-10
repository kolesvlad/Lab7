using ConsoleAppRestaurantTableReservationManager;
using Serilog;

public static class App
{
    static void Main(string[] args)
    {
        Initialize();
        
        try
        {
            ReservationManager manager = new ReservationManager();
            
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