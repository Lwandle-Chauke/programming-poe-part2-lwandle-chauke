### My Recipe App README

---

#### Overview
The Recipe App is a command-line application written in C# that allows users to manage recipes. It provides functionality for adding new recipes, viewing existing ones, scaling recipes, and displaying detailed information about each recipe. Additionally, it includes a feature to warn users if the total calories of a recipe exceed 300.

---

### Link to GitHub Repository
https://github.com/Lwandle-Chauke/programming-poe-part2-lwandle-chauke

---

#### Features
- **Add New Recipes**: Users can enter details for a new recipe, including ingredients and steps.
- **View Existing Recipes**: Users can view a list of existing recipes and select one to view its details.
- **Scale Recipes**: Recipes can be scaled by a given factor, adjusting the quantities of all ingredients accordingly.
- **Calorie Warning**: If the total calories of a recipe exceed 300, the user receives a warning message.
- **Clear Data**: Users can clear the current recipe data and start fresh.

---

#### Getting Started
1. **Clone or Download the Repository**: Clone or download the repository to your local machine.
2. **Open the Solution**: Open the solution file in Visual Studio or any C# IDE.
3. **Build and Run**: Build the solution and run the application.

---

#### Usage
- Upon launching the application, users are presented with a menu with options to:
  1. Enter a new recipe
  2. View existing recipes
  3. Scale a recipe
  4. Clear recipe data
  5. Exit the application
- Follow the prompts to perform the desired action.
- When entering a new recipe, provide details such as the recipe name, ingredients (name, quantity, unit, calories, and food group), and steps.
- If the total calories of a recipe exceed 300, a warning message is displayed.

---

#### Requirements
- .NET Framework or .NET Core installed on your machine.
- Access to a command-line interface for input and output.

---

#### Contributing
Contributions to the Recipe App are welcome! If you encounter any issues or have suggestions for improvements, please open an issue or submit a pull request on the GitHub repository.

---

#### License
This project is licensed under the [MIT License](LICENSE).

---

### Changes Based on Lecturer's Feedback

**1. Improved Error Handling**:
   - Added input validation to ensure users enter valid data for ingredients and steps.

**2. Enhanced Recipe Display**:
   - Improved the layout of the recipe display for better readability, ensuring a neat format.

**3. Recipe Scaling**:
   - Improved the scaling functionality to correctly handle unit conversions, such as converting tablespoons to cups.

**4. Confirmation Before Clearing Data**:
   - Added a prompt to confirm before clearing existing recipe data to prevent accidental deletions.

**5. Refined Class Structure**:
   - Refactored the code to enhance the logical structure of classes, ensuring better encapsulation and separation of concerns.

**6. Use of Dynamic Lists**:
   - Replaced static arrays with dynamic lists for storing ingredients and steps, allowing for more flexible and efficient data management.

**7. Improved Documentation**:
   - Added detailed comments and documentation throughout the code to enhance readability and maintain coding standards.

These changes improve the functionality, usability, and structure of the application, addressing the feedback provided and ensuring a better user experience.
