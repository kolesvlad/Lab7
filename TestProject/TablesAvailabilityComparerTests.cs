using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class TablesAvailabilityComparerTests
{
    [Test]
    public void TestCompare()
    {
        var now = DateTime.Now.Date;
        var comparer = new TablesAvailabilityComparer(now);
        
        var oneTableRestaurant = new Restaurant("X", new Table[1])
        {
            Tables =
            {
                [0] = new Table()
            }
        };
        var twoTablesRestaurant = new Restaurant("Y", new Table[2])
        {
            Tables =
            {
                [0] = new Table(),
                [1] = new Table()
            }
        };

        ClassicAssert.AreEqual(1, comparer.Compare(oneTableRestaurant, twoTablesRestaurant));
        ClassicAssert.AreEqual(-1, comparer.Compare(twoTablesRestaurant, oneTableRestaurant));
        ClassicAssert.AreEqual(0, comparer.Compare(oneTableRestaurant, oneTableRestaurant));
    }
}