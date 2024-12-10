using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class TablesAvailabilityComparerTests
{
    private TablesAvailabilityComparer _comparer;
    private ReservationManager _reservationManager;
    private readonly DateTime _now = DateTime.Now.Date;
    
    [SetUp]
    public void Setup()
    {
        _comparer = new TablesAvailabilityComparer(_now);
        _reservationManager = new ReservationManager();
    }
    [Test]
    public void TestCompare()
    {
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

        ClassicAssert.AreEqual(1, _comparer.Compare(oneTableRestaurant, twoTablesRestaurant));
        ClassicAssert.AreEqual(-1, _comparer.Compare(twoTablesRestaurant, oneTableRestaurant));
        ClassicAssert.AreEqual(0, _comparer.Compare(oneTableRestaurant, oneTableRestaurant));
    }

    [Test]
    public void TestCountAvailableTables()
    {
        const string testName = "TestRestaurant";
        
        _reservationManager.AddRestaurant(testName, 2);
        _reservationManager.BookTable(testName, _now, 0);

        var availableTableCount = TablesAvailabilityComparer
            .CountAvailableTables(_reservationManager.Restaurants.First(), _now);
        ClassicAssert.AreEqual(1, availableTableCount);
    }
}