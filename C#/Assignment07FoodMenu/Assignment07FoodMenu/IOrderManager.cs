

interface IOrderManager
{
    void AddItem(IMenuItem item,int quantity);
    Dictionary<IMenuItem,int> GetOrderItems();
}
