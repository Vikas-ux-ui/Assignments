

interface IOrderManager
{
    void AddItem(IMenuItem item);
    Dictionary<IMenuItem,int> GetOrderItems();
}
