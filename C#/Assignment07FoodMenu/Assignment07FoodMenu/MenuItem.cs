
// Class for a single menu item
class MenuItem : IMenuItem
{
    public string Name { get; }
    public decimal Price { get; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Display()
    {
       return $"{Name} {Price}";
    }
}
