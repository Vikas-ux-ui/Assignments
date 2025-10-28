using System;
using System.Collections.Generic;
using System.Linq;
class FoodMenuApp
{
    private List<IMenuCategory> _categories; // List of all menu categories
    private IOrderManager _order; // Manages the customer's order

    public FoodMenuApp()
    {
        // Initialize the order manager
        _order = new OrderManager();

        // Create menu categories with items
        _categories = new List<IMenuCategory>
        {
            new MenuCategory("Starters", new List<IMenuItem>
            {
                new MenuItem("Spring Rolls", 50),
                new MenuItem("Garlic Bread", 40),
                new MenuItem("Soup", 30)
            }),
            new MenuCategory("Chinese", new List<IMenuItem>
            {
                new MenuItem("Kung Pao Chicken", 120),
                new MenuItem("Fried Rice", 80),
                new MenuItem("Dumplings", 60)
            }),
            new MenuCategory("Main Course", new List<IMenuItem>
            {
                new MenuItem("Grilled Salmon", 150),
                new MenuItem("Pork", 180),
                new MenuItem("Pasta", 110)
            }),
            new MenuCategory("Desserts", new List<IMenuItem>
            {
                new MenuItem("Cheesecake", 60),
                new MenuItem("Ice Cream", 40),
                new MenuItem("Chocolate Cake", 50)
            })
        };
    }

    // Main method to run the application
    public void Run()
    {
        while (true)
        {
            // Show the main menu
            ShowMainMenu();
            string choice = Console.ReadLine();

            // Check if the user wants to exit
            if (choice.ToLower() == "exit")
            {
                // Display the current order before exiting
                Console.Clear();
                Console.WriteLine("=== Your Order ===");
                var items = _order.GetOrderItems();
                if (items.Count > 0)
                {
                    decimal total = items.Sum(i => i.Key.Price * i.Value); ;
                    Console.WriteLine($"{"OrderName",-20}{"OrderQuantity",9}{"Price",10}");
                    foreach (var item in items)
                    {
                        //Bill(items);
                        total = total + (item.Key.Price * item.Value);
                        Console.WriteLine($"{item.Key.Name,-20}{item.Value,10}{item.Key.Price * item.Value,10} ");
                        
                    }


                    Console.WriteLine("\n\n");
                    Console.WriteLine($"{"Total",-20}{total/2,20}");
                }
                else
                {
                    Console.WriteLine("Your order is empty.");

                }
                Console.ReadKey();
                break;
            }

            // Check if the choice is a valid category number
            if (int.TryParse(choice, out int categoryNumber) && categoryNumber >= 1 && categoryNumber <= _categories.Count)
            {
                ShowCategoryMenu(_categories[categoryNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid choice. Enter a number between 1 and 4, or type 'exit' to quit.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    // Display the main menu with categories
    private void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Welcome to the Food Menu ===");
        Console.WriteLine("Choose a category:");
        for (int i = 0; i < _categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_categories[i].Name}");
        }


        Console.WriteLine("\nType exit to finish and view your order.");
        Console.Write("Enter your choice: ");
    }


    // Display items in a specific category
    private void ShowCategoryMenu(IMenuCategory category)
    {
        Console.Clear();
        Console.WriteLine($"=== {category.Name} ===");
        var displayItems = category.Items
        .Select((item, i) => $"{i + 1}. {item.Display()}");

        foreach (var display in displayItems)
        {
            Console.WriteLine(display);
        }
        Console.WriteLine($"{category.Items.Count + 1}. Back to Main Menu");
        while (true)
        {
           
            Console.Write("Choose an item to add : ");

            string choice = Console.ReadLine();
            if (choice == (category.Items.Count + 1).ToString())
            {
                return; // Go back to main menu
            }

            if (int.TryParse(choice, out int itemNumber) && itemNumber >= 1 && itemNumber <= category.Items.Count)
            {
                Console.Write("Enter the Quantity of item ");
                if(int.TryParse(Console.ReadLine(),out int quantity))
                {
                    _order.AddItem(category.Items[itemNumber - 1], quantity);
                }
                else
                {
                    Console.WriteLine("enter valid quantity");
                }
                
                
            }
            else

            {
                Console.WriteLine("Invalid choice. Please try again.");

            }
        }
    }

    // Entry point of the program
    static void Main(string[] args)
    {
        FoodMenuApp app = new FoodMenuApp();
        app.Run();
    }
}