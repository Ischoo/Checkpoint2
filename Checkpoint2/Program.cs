
using Checkpoint2;

List<Product> products = new List<Product>();




while (true)
{

    Product current = addProduct();
    if (current == null)
    {
        Console.WriteLine();
        printAllProducts(products);
        break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product added!");
        Console.ResetColor();  
        products.Add(current);
        
    }

     

    
    Console.ReadLine();
}



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
        if (input.ToLower().Trim() == "q")
        {
            
            return null;
        }


    }
    return product;
}

string printProduct(Product prod)
{
    return prod.category + ", " + prod.name + ", " + prod.price;
}

void printAllProducts(List<Product> products)
{
    foreach (Product prod in products)
    {
        Console.WriteLine(printProduct(prod));
    } 
}

