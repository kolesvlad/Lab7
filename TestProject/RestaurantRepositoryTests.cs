using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class RestaurantRepositoryTests
{
    [Test]
    public void TestLoadRestaurantsFromFile()
    {
        const string filePath = "/Users/valdemar/RiderProjects/Lab7/ConsoleAppRestaurantTableReservationManager/load.txt";
        
        var restaurantsData = RestaurantRepository.LoadRestaurantsFromFile(filePath);

        ClassicAssert.IsTrue(restaurantsData.ContainsKey("PuzataHouse"));
        ClassicAssert.IsTrue(restaurantsData.ContainsKey("Mak"));
        ClassicAssert.IsTrue(restaurantsData.ContainsKey("AromaCava"));
        
        ClassicAssert.AreEqual(10, restaurantsData["PuzataHouse"]);
        ClassicAssert.AreEqual(500, restaurantsData["Mak"]);
        ClassicAssert.AreEqual(8, restaurantsData["AromaCava"]);
    }
}