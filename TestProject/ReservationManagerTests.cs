namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class ReservationManagerTests
{
    private ReservationManager _reservationManager;
    
    [SetUp]
    public void Setup()
    {
        _reservationManager = new ReservationManager();
    }

    [Test]
    public void Test1()
    {
        
        Assert.Pass();
    }
}