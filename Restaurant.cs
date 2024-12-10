namespace ConsoleAppRestaurantTableReservationManager;

public struct Restaurant(string name, Table[] tables)
{
    public readonly string Name = name;
    public readonly Table[] Tables = tables;
}
