// namespace Phonebook;

// public class CategoryController
// {
//     private readonly DisplayData _displayData;
//     private readonly UserInput _userInput;
//     private readonly CategoryDataManager _dataManager;

//     public CategoryController(DisplayData displayData, UserInput userInput, CategoryDataManager dataManager)
//     {
//         _displayData = displayData;
//         _userInput = userInput;
//         _dataManager = dataManager;
//     }
//     internal void AddCategory()
//     {
//         Category category = new Category();
//         category.Name = _userInput.GetName("category");
//         _dataManager.AddCategory(category);
//     }
// }