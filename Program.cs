using Phonebook;


/*
    TO DO:
    - What if you want to send not only e-mails but SMS?


    QUESTIONS
    - CategoryDataManager uses static functions (it was easier) but it's the only one - is that bad practice?
    - "Virtual" keyword in Contact class
*/


internal class Program
{
    private static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        DisplayData displayData = new DisplayData();
        ContactsDataManager dataManager = new ContactsDataManager();
        CategoryDataManager categoryDataManager = new CategoryDataManager();
        PhonebookController phonebookController = new PhonebookController(displayData, userInput, dataManager, categoryDataManager);
        // CategoryController categoryController = new CategoryController(displayData, userInput, categoryDataManager);

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

