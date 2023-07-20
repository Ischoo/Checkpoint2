
using Checkpoint2;
// create list which will contain your products
List<Product> products = new List<Product>();



// loop to add products until user press 'q'
while (true)
{
    
    Product current = addProduct();
    
    if (current == null)
    {
        // user presses 'q', call print method qith a sorted list
        Console.WriteLine("".PadRight(60, '-'));
        printAllProducts(sortProducts(products));
        printSum();
        Console.WriteLine("".PadRight(60, '-'));
        bool addNew = userChoice();
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
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Enter new product - press 'P' | Search for product - press 'S' | To quit - press 'Q'");
    Console.ResetColor();
    string input = Console.ReadLine().Trim().ToLower();
    switch (input)
    {
        // a bit clunky, change later
        case "p":
            return true;
        case "q":
            return false;
        case "s":
            return searchList();
    }

    return false;
        

}

void printSum()
{
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
        string input = "";
        switch (i)
        {
            case 0:
                Console.Write("Enter a Category: ");
                input = Console.ReadLine();
                product.category = input;
                break;
            case 1:
                Console.Write("Enter a Product Name: ");
                input = Console.ReadLine();
                product.name = input;
                break;
            case 2:
                Console.Write("Enter a Price: ");
                input = Console.ReadLine();
                product.price = Int32.Parse(input);
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

void printAllProducts(List<Product> products)
{
    // print the three categories of your products, starting with the titles
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
    Console.ResetColor();
    foreach (Product prod in products)
    {
        Console.WriteLine(printProduct(prod));
    } 
}
bool searchList()
{
    throw new NotImplementedException();
}