using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class TableTests
{
    [Test]
    public void TestTableBook()
    {
        var table = new Table();
        var now = DateTime.Now.Date;
        
        var bookResult = table.Book(now);
        ClassicAssert.IsTrue(bookResult);
        
        bookResult = table.Book(now);
        ClassicAssert.IsFalse(bookResult);
    }

    [Test]
    public void TestTableIsBooked()
    {
        var table = new Table();
        var now = DateTime.Now.Date;
        
        table.Book(now);
        
        ClassicAssert.IsTrue(table.IsBooked(now));
    }
}