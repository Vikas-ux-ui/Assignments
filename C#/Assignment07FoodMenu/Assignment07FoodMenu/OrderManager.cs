
// Class to manage the customer's order
class OrderManager : IOrderManager
{
    private Dictionary<IMenuItem,int> _orderedItems = new Dictionary<IMenuItem, int>();

    // Add an item to the order
    public void AddItem(IMenuItem item,int quantity)
    {
        Console.WriteLine("adding item "+item.Name +" * "+quantity);
        if (_orderedItems.ContainsKey(item))
        {
            _orderedItems[item]+=quantity;
        }
        else
        {
            _orderedItems[item]=quantity;
        }
    }

    // Get all items in the order
    public Dictionary<IMenuItem,int > GetOrderItems()
    {
       
        return _orderedItems;
    }
}
