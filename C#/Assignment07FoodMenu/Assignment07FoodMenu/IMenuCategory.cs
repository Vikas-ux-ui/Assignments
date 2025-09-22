
// Interface for a menu category (like Starters or Desserts)
interface IMenuCategory
{
    string Name { get; }
    List<IMenuItem> Items { get; }
}
