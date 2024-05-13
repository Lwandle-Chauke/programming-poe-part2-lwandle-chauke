//Part 1
using System;

class MyRecipeApp
{
    static string[] ingredients;
    static double[] quantities;
    static string[] units;
    static string[] steps;
    static double[] originalQuantities; // New array to store original quantities

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to My Recipe App!");

        int previousChoice = -1;
        // Display the menu options after each user interaction
        DisplayOptions();

        // Main loop for interacting with the user
        while (true)
        {
            Console.Write("\nEnter your choice: ");
            int choice;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            // Switch statement to handle user choices
            switch (choice)
            {
                case 1:
                    EnterRecipe();
                    break;
                case 2:
                    if (ingredients == null)
                    {
                        Console.WriteLine("No recipe has been created.");
                        EnterRecipe();
                    }
                    else
                    {
                        ViewRecipe();
                    }
                    break;
                case 3:
                    ScaleRecipe();
                    break;
                case 4:
                    ResetQuantities();
                    break;
                case 5:
                    ClearData();
                    break;
                case 6:
                    Console.WriteLine("Thank you for using Recipe App!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != 4)
            {
                previousChoice = choice;
            }

            // Display the menu options after each user interaction
            DisplayOptions();
        }
    }

    // Method to enter a new recipe
    static void EnterRecipe()
    {
        Console.WriteLine("\nEnter the details for the recipe");

        Console.Write("Number of ingredients: ");
        int numIngredients = Convert.ToInt32(Console.ReadLine());


        ingredients = new string[numIngredients];
        quantities = new double[numIngredients];
        units = new string[numIngredients];

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write("Ingredient {0}: ", i + 1);
            ingredients[i] = Console.ReadLine();

            Console.Write("Quantity: ");
            quantities[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unit of measurement: ");
            units[i] = Console.ReadLine();
        }

        // Create a backup of quantities
        originalQuantities = new double[numIngredients];
        Array.Copy(quantities, originalQuantities, numIngredients);

        Console.Write("\nNumber of steps: ");
        int numSteps = Convert.ToInt32(Console.ReadLine());

        steps = new string[numSteps];

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write("Step {0}: ", i + 1);
            steps[i] = Console.ReadLine();
        }

        Console.WriteLine("\nRecipe entered successfully!");
    }

    // Method to view the full recipe the user has made
    static void ViewRecipe()
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("                            MY RECIPE ");
        Console.WriteLine("\nINGREDIENTS");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine("{0}. {1} - {2} {3}", i + 1, ingredients[i], quantities[i], units[i]);
        }

        Console.WriteLine("\n*");
        Console.WriteLine("\nSTEPS");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine("Step {0}: {1}", i + 1, steps[i]);
        }
        Console.WriteLine("-----------------------------------------------------------------");
    }

    // Method to scale the recipe quantities
    static void ScaleRecipe()
    {
        if (ingredients == null)
        {
            Console.WriteLine("No recipe has been created.");
            EnterRecipe();
            return;
        }

        Console.WriteLine("\nSCALE");
        Console.WriteLine("1. Half");
        Console.WriteLine("2. Double");
        Console.WriteLine("3. Triple");

        Console.Write("\nEnter your choice: ");
        int choice;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid choice. Please enter a number.");
            return;
        }

        switch (choice)
        {
            case 1:
                ScaleQuantities(0.5);
                Console.WriteLine("Recipe scaled to half.");
                break;
            case 2:
                ScaleQuantities(2);
                Console.WriteLine("Recipe scaled to double.");
                break;
            case 3:
                ScaleQuantities(3);
                Console.WriteLine("Recipe scaled to triple.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    // Method to scale the quantities by a given factor
    static void ScaleQuantities(double scale)
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] *= scale;
        }
    }

    // Method to reset the quantities to their original values
    static void ResetQuantities()
    {
        if (ingredients == null)
        {
            Console.WriteLine("No recipe has been created.");
            EnterRecipe();
            return;
        }

        // Restore original quantities
        Array.Copy(originalQuantities, quantities, originalQuantities.Length);

        Console.WriteLine("\nQuantities reset to original values.");
    }

    // Method to clear all recipe data
    static void ClearData()
    {
        InitialiseRecipe();
        Console.WriteLine("\nData cleared. Enter a new recipe to continue.");
    }

    // Method to reset all recipe arrays to null
    static void InitialiseRecipe()
    {
        ingredients = null;
        quantities = null;
        units = null;
        steps = null;
    }

    // Method to display the menu options
    static void DisplayOptions()
    {
        Console.WriteLine("\nMENU");
        Console.WriteLine("1. Enter a new recipe");
        Console.WriteLine("2. View recipe");
        Console.WriteLine("3. Scale recipe");
        Console.WriteLine("4. Reset quantities");
        Console.WriteLine("5. Clear data");
        Console.WriteLine("6. Exit");
    }
}