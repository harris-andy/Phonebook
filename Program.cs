using Phonebook;

internal class Program
{
    private static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        DisplayData displayData = new DisplayData();
        DataManager dataManager = new DataManager();
        PhonebookController phonebookController = new PhonebookController(displayData, userInput, dataManager);

        phonebookController.ShowMainMenu();
    }
}

// Class_Objects should really be Models or Entities
// Classes should be split up completely.
// AppConfig.cs -> \Configurations\.
// DisplayData.cs -> \Views\ or \Menus\.
// FlashCardController.cs -> \Controllers\
// UseDB.cs -> \Data\DataManager.cs or \Controllers\DataController.cs
// UserInput.cs -> \Helpers\ or \Services\UserInputService.cs

