using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class ReservationManagerTests
{

    [Test]
    public void TestAddRestaurant()
    {
        var reservationManager = new ReservationManager();
        
        const string testName = "TestRestaurant";
        const int testTableCount = 5;
        
        reservationManager.AddRestaurant(testName, testTableCount);

        ClassicAssert.AreEqual(1, reservationManager.Restaurants.Count);
        ClassicAssert.AreEqual(testName, reservationManager.Restaurants.First().Name);
        ClassicAssert.AreEqual(5, reservationManager.Restaurants.First().Tables.Length);
    }

    [Test]
    public void TestBookTable()
    {
        var reservationManager = new ReservationManager();

        const string testName = "TestRestaurant";
        
        reservationManager.AddRestaurant(testName, 5);
        var bookResult = reservationManager.BookTable(testName, DateTime.Now.Date, 0);

        ClassicAssert.IsTrue(bookResult);

        bookResult = reservationManager.BookTable(testName, DateTime.Now.Date, 0);
        
        ClassicAssert.IsFalse(bookResult);
    }
    
    [Test]
    public void TestBookTableWithExceptions()
    {
        var reservationManager = new ReservationManager();

        const string testName = "TestRestaurant";
        
        reservationManager.AddRestaurant(testName, 5);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            reservationManager.BookTable(testName, DateTime.Now.Date, 9));
        Assert.Throws<ArgumentException>(() => 
            reservationManager.BookTable("FakeRestaurant", DateTime.Now.Date, 4));
    }

    [Test]
    public void TestLoadRestaurants()
    {
        var reservationManager = new ReservationManager();
        const string filePath = "/Users/valdemar/RiderProjects/Lab7/ConsoleAppRestaurantTableReservationManager/load.txt";
        
        reservationManager.LoadRestaurants(filePath);
        
        ClassicAssert.AreEqual(reservationManager.Restaurants[0].Name, "PuzataHouse");
        ClassicAssert.AreEqual(reservationManager.Restaurants[0].Tables.Length, 10);
        
        ClassicAssert.AreEqual(reservationManager.Restaurants[1].Name, "Mak");
        ClassicAssert.AreEqual(reservationManager.Restaurants[1].Tables.Length, 500);
        
        ClassicAssert.AreEqual(reservationManager.Restaurants[2].Name, "AromaCava");
        ClassicAssert.AreEqual(reservationManager.Restaurants[2].Tables.Length, 8);
    }

    [Test]
    public void TestFindAllFreeTables()
    {
        var reservationManager = new ReservationManager();
        const string testName = "TestRestaurant";
        
        reservationManager.AddRestaurant(testName, 3);
        reservationManager.BookTable(testName, DateTime.Now.Date, 0);
        reservationManager.BookTable(testName, DateTime.Now.Date, 1);

        var freeTables = reservationManager.FindAllFreeTables(DateTime.Now.Date);
        
        ClassicAssert.Contains($"{testName} - Table 3", freeTables);
    }

    [Test]
    public void TestSortRestaurantsByTablesAvailability()
    {
        var reservationManager = new ReservationManager();
        
        var now = DateTime.Now.Date;
        reservationManager.AddRestaurant("TestRestaurant1", 5);
        reservationManager.AddRestaurant("TestRestaurant2", 5);
        reservationManager.AddRestaurant("TestRestaurant3", 5);
        
        reservationManager.BookTable("TestRestaurant1", now, 0);
        reservationManager.BookTable("TestRestaurant1", now, 1);
        reservationManager.BookTable("TestRestaurant1", now, 2);
        reservationManager.BookTable("TestRestaurant1", now, 3);
        reservationManager.BookTable("TestRestaurant1", now, 4);
        
        reservationManager.BookTable("TestRestaurant2", now, 0);
        reservationManager.BookTable("TestRestaurant2", now, 1);
        reservationManager.BookTable("TestRestaurant2", now, 2);
        
        reservationManager.BookTable("TestRestaurant3", now, 1);
        
        ClassicAssert.AreEqual(0,
            TablesAvailabilityComparer.CountAvailableTables(reservationManager.Restaurants[0], now));
        
        reservationManager.SortRestaurantsByTablesAvailability(DateTime.Now.Date);
        
        ClassicAssert.AreEqual(4, 
            TablesAvailabilityComparer.CountAvailableTables(reservationManager.Restaurants[0], now));
    }

}