
// Interface for a menu item (food name and price)
interface IMenuItem
{
    string Name { get; }
    decimal Price { get; }
    string  Display();
}
