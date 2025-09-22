
// Class to manage the customer's order
class OrderManager : IOrderManager
{
    private Dictionary<IMenuItem,int> _orderedItems = new Dictionary<IMenuItem, int>();

    // Add an item to the order
    public void AddItem(IMenuItem item)
    {
        Console.WriteLine("adding item "+item.Name);
        if (_orderedItems.ContainsKey(item))
        {
            _orderedItems[item]++;
        }
        else
        {
            _orderedItems[item]=0;
        }
    }

    // Get all items in the order
    public Dictionary<IMenuItem,int > GetOrderItems()
    {
       
        return _orderedItems;
    }
}
