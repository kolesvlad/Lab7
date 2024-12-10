namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class AppTests
{
    [Test]
    public void TestApp()
    {
        Assert.That(App.Main, Throws.Nothing);
    }
}