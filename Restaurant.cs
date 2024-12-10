namespace ConsoleAppRestaurantTableReservationManager;

internal struct Restaurant
{
    public string Name;
    public readonly Table[] Tables;

    public Restaurant(string name, Table[] tables)
    {
        Name = name;
        Tables = tables;
    }
}
