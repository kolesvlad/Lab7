using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class TableTests
{
    private DateTime _now;
    
    [SetUp]
    public void Setup()
    {
        _now = DateTime.Now.Date;
    }
    
    [Test]
    public void TestTableBook()
    {
        var table = new Table();
        
        var bookResult = table.Book(_now);
        ClassicAssert.IsTrue(bookResult);
        
        bookResult = table.Book(_now);
        ClassicAssert.IsFalse(bookResult);
    }

    [Test]
    public void TestTableIsBooked()
    {
        var table = new Table();
        
        table.Book(_now);
        
        ClassicAssert.IsTrue(table.IsBooked(_now));
    }
}