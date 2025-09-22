
// Class for a menu category 
class MenuCategory : IMenuCategory
{
    public string Name { get; }
    public List<IMenuItem> Items { get; }

    public MenuCategory(string name, List<IMenuItem> items)
    {
        //Console.WriteLine("Assining values to list " + name);
        Name = name;
        
        Items = items;
    }
}
