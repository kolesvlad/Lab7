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

            var firstBookAttempt = manager
                .BookTable("A", new DateTime(2023, 12, 25), 3);
            var secondBookAttempt = manager
                .BookTable("A", new DateTime(2023, 12, 25), 3);
            
            Log.Information("A book attempt: {result}", firstBookAttempt);
            Log.Information("B book attempt: {result}", secondBookAttempt);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
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