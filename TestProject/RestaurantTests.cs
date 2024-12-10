namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class RestaurantTests
{
    [Test]
    public void TestRestaurantCreate()
    {
        var restaurant = new Restaurant("TestRestaurant", new Table[5]);
        
        Assert.That(restaurant.Name, Is.EqualTo("TestRestaurant"));
        Assert.That(restaurant.Tables.Length, Is.EqualTo(5));
    }
}