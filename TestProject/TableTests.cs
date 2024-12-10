using NUnit.Framework.Legacy;

namespace ConsoleAppRestaurantTableReservationManager.TestProject;

[TestFixture]
public class TableTests
{
    [Test]
    public void TestTableBook()
    {
        var table = new Table();
        var bookResult = table.Book(DateTime.Now.Date);
        ClassicAssert.IsTrue(bookResult);
        
        bookResult = table.Book(DateTime.Now.Date);
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