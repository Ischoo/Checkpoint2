
using Checkpoint2;
// create list which will contain your products
List<Product> products = new List<Product>();



// loop to add products until user press quits program
while (true)
{
    
    Product current = addProduct();
    
    if (current == null)
    {
        // user presses 'q', call print method with a sorted list
        printAllProducts(sortProducts(products), false, null);
        bool addNew = userChoice(); // check if user wants too add new, search or quit
        if (!addNew) { break; }
    }
    else
    {

        // no error from user, print confirm to user and add to list
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product added!");
        Console.ResetColor();  
        products.Add(current);
        Console.WriteLine();
    }

     

    
    
}
// choice for user after list is printed
bool userChoice()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Enter new product - press 'P' | Search for product - press 'S' | To quit - press 'Q'");
    Console.ResetColor();
    bool wrongInput = true;
    // loop to check if user inputs a correct choice
    string input = "";
    while(wrongInput) {
        input = Console.ReadLine().Trim().ToLower();
        if(input.Length == 1 && (input == "p" || input == "q" || input == "s")) // only 1 letter accepted and check if accepted letter
        {
            wrongInput = false;
        }
        else // message if wrong input
        { 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input");
            Console.ResetColor();
        }
    } 
    
    switch (input)
    {
        // return true if add new, false if quit. 
        case "p":
            return true;
        case "q":
            return false;
        case "s":
            return searchList(); // search method calls this method after its done. This recursion stops when user enters 'p' or 'q'
        default:
            return false; // default case, should never be entered
    }
}

bool searchList()
{
    // method to search for a product with a specific name, limit to 10 letters
    Console.Write("Search for product name: ");
    string input = Console.ReadLine().ToLower().Trim();
    if (input.Length > 10) { input = input.Substring(0, 10); }
    bool isFound = products.Any(prod => prod.name.ToLower() == input);
    if (isFound)
    {
        printAllProducts(sortProducts(products), true, input);
    }
    else
    {
        Console.WriteLine("Search doesn't match any products.");
    }

    return userChoice();
}

void printSum()
{
    // simple method too get total price
    int sum = products.Sum(product => product.price);
    Console.WriteLine();
    Console.WriteLine("".PadRight(20) + "Total amount:".PadRight(20) + sum);

}

List<Product> sortProducts(List<Product> products)
{
    // sort your list after price, ascending
    IEnumerable<Product> query = products.OrderBy(product => product.price);

    return query.ToList();
        
}


// method to add products
Product addProduct()
{
    

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Enter a new product - Follow the steps | Press 'Q' to quit");
    Console.ResetColor();

    Product product = new Product();
    for (int i = 0; i < 3; i++)
    {

        // get input from user, limit to 10 letters for cleaner output
        string input = "";
        switch (i)
        {
            case 0:
                Console.Write("Enter a Category: ");
                input = Console.ReadLine();
                if(input.Length > 10)
                {
                    product.category = input.Substring(0, 10);
                }
                else { product.category = input; }
                break;
            case 1:
                Console.Write("Enter a Product Name: ");
                input = Console.ReadLine();
                if (input.Length > 10)
                {
                    product.name = input.Substring(0, 10);
                }
                else { product.name = input; }
                break;
            case 2:
                bool isNumber = false;
                while (!isNumber) // loop until number or 'q' as input
                {
                    Console.Write("Enter a Price: ");
                    input = Console.ReadLine();
                    if (input.ToLower().Trim() == "q") { break; }

                    isNumber = int.TryParse(input, out int value);
                    if(!isNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid input");
                        Console.ResetColor();
                    }
                    else { product.price = value; }
                }
                break;
        }
        // check if user presses 'q', return null
        if (input.ToLower().Trim() == "q")
        {
            
            return null;
        }


    }
    return product;
}

string printProduct(Product prod)
{
    // return string which aligns the three categories in three columns
    return prod.category.PadRight(20) + prod.name.PadRight(20) + prod.price;
}


void printAllProducts(List<Product> products, bool search, string input)
{
    // print the three categories of your products, starting with the titles
    Console.WriteLine("".PadRight(60, '-'));
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
    Console.ResetColor();
    foreach (Product prod in products)
    {
        if(search && prod.name.ToLower() == input) // if user has searched and name matches, add highlight
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.WriteLine(printProduct(prod));
        Console.ResetColor();
    }
    printSum(); // call method to get sum of all the products price
    Console.WriteLine("".PadRight(60, '-'));


}
