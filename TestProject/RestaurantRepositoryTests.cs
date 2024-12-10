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
        
        ClassicAssert.AreEqual(restaurantsData["PuzataHouse"], 10);
        ClassicAssert.AreEqual(restaurantsData["Mak"], 500);
        ClassicAssert.AreEqual(restaurantsData["AromaCava"], 8);
    }
}