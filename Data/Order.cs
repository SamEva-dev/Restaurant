using SQLite;

namespace RestaurantPosMAUI.Data;

public class Order
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalItemsCount { get; set; }
    public int PaymentMode { get; set; }
}
