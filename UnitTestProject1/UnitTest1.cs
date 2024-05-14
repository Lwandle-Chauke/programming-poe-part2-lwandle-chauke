// Recipe.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }
}

// Ingredient.cs
public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double Calories { get; set; }
    public string FoodGroup { get; set; }
}

// RecipeTests.cs
namespace MyRecipeApp.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestCalculateTotalCalories_SimpleRecipe()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Calories = 200 });

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(300, totalCalories);
        }

        [TestMethod]
        public void TestCalculateTotalCalories_ComplexRecipe()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 50 });
            recipe.Ingredients.Add(new Ingredient { Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Calories = 200 });

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(350, totalCalories);
        }
    }
}
