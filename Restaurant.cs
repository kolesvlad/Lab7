namespace ConsoleAppRestaurantTableReservationManager;

public struct Restaurant
{
    public readonly string Name;
    public readonly Table[] Tables;

    public Restaurant(string name, Table[] tables)
    {
        Name = name;
        Tables = tables;
    }
}
