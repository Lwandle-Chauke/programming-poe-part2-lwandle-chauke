using System;
using System.Collections.Generic;

// Class representing an ingredient
class Ingredient
{
    // Ingredient properties
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double Calories { get; set; }
    public string FoodGroup { get; set; }
}

// Class representing a recipe
class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }
    public delegate void CalorieNotificationHandler(Recipe recipe);
    public event CalorieNotificationHandler CalorieNotification;

    // Method to calculate the total calories of the recipe
    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    // Method to check if the total calories exceed 300 calories to trigger notification
    public void CheckCalories()
    {
        if (CalculateTotalCalories() > 300)
        {
            CalorieNotification?.Invoke(this);
        }
    }

    // Method to scale the quantities of ingredients
    public void ScaleQuantities(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Method to reset the quantities to their original values
    public void ResetQuantities()
    {
        // Restore original quantities
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = ingredient.Quantity;
        }
    }
}

class MyRecipeApp
{
    static List<Recipe> recipes = new List<Recipe>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to My Recipe App!");

        DisplayOptions(); // Display the menu options

        while (true) // Loop to keep the program running until the user chooses to exit
        {
            Console.Write("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterRecipe(); // Option to enter a new recipe
                    break;
                case 2:
                    ViewRecipes(); // Option to view existing recipes
                    break;
                case 3:
                    ScaleRecipe(); // Option to scale a recipe
                    break;
                case 4:
                    ResetQuantities(); // Option to reset recipe quantities
                    break;
                case 5:
                    Console.WriteLine("Thank you for using Recipe App!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            DisplayOptions(); // Display the menu options again
        }
    }

    // Method to enter a new recipe
    static void EnterRecipe()
    {
        Recipe recipe = new Recipe();
        recipe.Ingredients = new List<Ingredient>();
        recipe.Steps = new List<string>();

        Console.WriteLine("\nEnter the details for the recipe");

        Console.Write("Recipe name: ");
        recipe.Name = Console.ReadLine();

        Console.Write("Number of ingredients: ");
        int numIngredients = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Ingredient ingredient = new Ingredient();

            Console.Write("Ingredient {0} name: ", i + 1);
            ingredient.Name = Console.ReadLine();

            Console.Write("Quantity: ");
            ingredient.Quantity = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unit of measurement: ");
            ingredient.Unit = Console.ReadLine();

            Console.Write("Calories: ");
            ingredient.Calories = Convert.ToDouble(Console.ReadLine());

            Console.Write("Food group: ");
            ingredient.FoodGroup = Console.ReadLine();

            recipe.Ingredients.Add(ingredient);
        }

        Console.Write("\nNumber of steps: ");
        int numSteps = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nEnter the steps:");
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write("Step {0}: ", i + 1);
            recipe.Steps.Add(Console.ReadLine());
        }

        recipes.Add(recipe);
        recipe.CalorieNotification += Recipe_CalorieNotification;
        recipe.CheckCalories();

        // Sort recipes by name
        recipes.Sort((x, y) => string.Compare(x.Name, y.Name));

        Console.WriteLine("\nRecipe entered successfully!");
    }

    // Method to handle calorie notification
    static void Recipe_CalorieNotification(Recipe recipe)
    {
        Console.WriteLine($"Warning: The total calories of '{recipe.Name}' exceed 300!");
    }

    // Method to view existing recipes
    static void ViewRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        Console.WriteLine("\nRecipes:");

        // Display recipes with numeric identifiers and names
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        Console.Write("\nEnter the number of the recipe you want to view: ");
        int recipeNumber = Convert.ToInt32(Console.ReadLine());

        if (recipeNumber > 0 && recipeNumber <= recipes.Count)
        {
            DisplayRecipe(recipes[recipeNumber - 1]);
        }
        else
        {
            Console.WriteLine("Invalid recipe number.");
        }
    }

    // Method to display the details of a recipe, including total calories
    static void DisplayRecipe(Recipe recipe)
    {
        Console.WriteLine("\nRecipe: " + recipe.Name);
        Console.WriteLine("Ingredients:");
        double totalCalories = 0; // Variable to store total calories
        foreach (var ingredient in recipe.Ingredients)
        {
            totalCalories += ingredient.Calories; // Add calories of each ingredient to total
            Console.WriteLine("- {0} ({1} {2}, {3} calories, Food group: {4})", ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
        }
        Console.WriteLine("\nTotal Calories: " + totalCalories); // Display total calories
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Count; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, recipe.Steps[i]);
        }
    }


    // Method to scale a recipe
    static void ScaleRecipe()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        Console.WriteLine("\nRecipes:");

        // Display recipes with numeric identifiers and names
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        Console.Write("\nEnter the number of the recipe you want to scale: ");
        int recipeNumber = Convert.ToInt32(Console.ReadLine());

        if (recipeNumber > 0 && recipeNumber <= recipes.Count)
        {
            Console.WriteLine("Choose scaling factor:");
            Console.WriteLine("1. Half");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. Triple");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Recipe selectedRecipe = recipes[recipeNumber - 1];

            switch (choice)
            {
                case 1:
                    selectedRecipe.ScaleQuantities(0.5);
                    Console.WriteLine("Recipe scaled to half.");
                    break;
                case 2:
                    selectedRecipe.ScaleQuantities(2);
                    Console.WriteLine("Recipe scaled to double.");
                    break;
                case 3:
                    selectedRecipe.ScaleQuantities(3);
                    Console.WriteLine("Recipe scaled to triple.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid recipe number.");
        }
    }

    // Method to reset quantities of a recipe
    static void ResetQuantities()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        Console.WriteLine("\nRecipes:");

        // Display recipes with numeric identifiers and names
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        Console.Write("\nEnter the number of the recipe you want to reset quantities for: ");
        int recipeNumber = Convert.ToInt32(Console.ReadLine());

        if (recipeNumber > 0 && recipeNumber <= recipes.Count)
        {
            Recipe selectedRecipe = recipes[recipeNumber - 1];
            selectedRecipe.ResetQuantities();
            Console.WriteLine("Quantities reset for the selected recipe.");
        }
        else
        {
            Console.WriteLine("Invalid recipe number.");
        }
    }

    // Method to display menu options
    static void DisplayOptions()
    {
        Console.WriteLine("\nMENU");
        Console.WriteLine("1. Enter a new recipe");
        Console.WriteLine("2. View recipes");
        Console.WriteLine("3. Scale a recipe");
        Console.WriteLine("4. Reset quantities for a recipe");
        Console.WriteLine("5. Exit");
    }
}
