namespace Phonebook;

public class PhonebookController
{
    private readonly DisplayData _displayData;
    private readonly UserInput _userInput;
    private readonly ContactsDataManager _dataManager;
    private readonly CategoryDataManager _categoryDataManager;

    public PhonebookController(DisplayData displayData, UserInput userInput, ContactsDataManager dataManager, CategoryDataManager categoryDataManager)
    {
        _displayData = displayData;
        _userInput = userInput;
        _dataManager = dataManager;
        _categoryDataManager = categoryDataManager;
    }

    internal void ShowMainMenu()
    {
        bool closeApp = false;
        while (closeApp == false)
        {
            int inputNumber = _userInput.MainMenu();
            switch (inputNumber)
            {
                case 0:
                    Console.WriteLine("\nBye!\n");
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                case 1:
                    AddContact();
                    break;
                case 2:
                    DeleteContact();
                    break;
                case 3:
                    UpdateContact();
                    break;
                case 4:
                    ViewContacts();
                    break;
                case 5:
                    AddCategory();
                    break;
                case 6:
                    ViewCategories();
                    break;
                case 7:
                    DeleteCategory();
                    break;
                case 8:
                    UpdateCategory();
                    break;
                case 9:
                    // AddFakeStudySessions();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid Command. Give me number!");
                    break;
            }
        }
    }

    private void AddContact()
    {
        Contact contact = new Contact();
        contact.Name = _userInput.GetName("contact");
        contact.Email = _userInput.GetEmail();
        contact.PhoneNumber = _userInput.GetPhoneNumber();
        List<Category> categories = CategoryDataManager.GetCategories();
        if (categories.Count() == 0)
            AddCategory();
        contact.CategoryId = _userInput.GetCategory().CategoryId;


        // using var db = new ContactsContext();
        // db.Add(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
        // db.SaveChanges();

        // Contact contact = new Contact { Name = name, Email = email, PhoneNumber = phoneNumber };
        _dataManager.AddNewContact(contact);
    }

    private void DeleteContact()
    {
        List<Contact> contacts = _dataManager.GetContacts();
        // _displayData.ShowContacts(contacts);
        // _displayData.PressToContinue();
        string chooseMessage = "Choose contact to be elminated: ";
        // string name = _userInput.GetString(message);
        Contact chosenOne = _userInput.GetContact(contacts, chooseMessage);
        List<Contact> chosenList = new List<Contact> { chosenOne };
        _displayData.ShowContacts(chosenList);
        string deleteMessage = "Are you sure you want to delete this contact?";
        if (_userInput.GetConfirmation(deleteMessage))
            _dataManager.DeleteContact(chosenOne);
    }

    private void ViewContacts()
    {
        List<Contact> contacts = _dataManager.GetContacts();
        _displayData.ShowContacts(contacts);
        _userInput.PressToContinue();
    }

    private void UpdateContact()
    {
        List<Contact> contacts = _dataManager.GetContacts();
        string message = "Choose contact to update: ";
        Contact chosenOne = _userInput.GetContact(contacts, message);
        List<Contact> chosenList = new List<Contact> { chosenOne };
        int updateChoice;

        do
        {
            _displayData.ShowContacts(chosenList);
            updateChoice = _userInput.ChooseContactToUpdate();
            Action performAction = updateChoice switch
            {
                0 => () => ShowMainMenu(),
                1 => () => chosenOne.Name = _userInput.GetName("contact"),
                2 => () => chosenOne.PhoneNumber = _userInput.GetPhoneNumber(),
                3 => () => chosenOne.Email = _userInput.GetEmail(),
                4 => () => chosenOne.Category.Name = _userInput.GetName("category"),
                5 => () =>
                {
                    _dataManager.UpdateContact(chosenOne);
                    Console.WriteLine($"\nChanges committed!\n");
                    _userInput.PressToContinue();
                }
                ,
                _ => () => Console.WriteLine($"I don't know how you even got here. Retreat!")
            };
            performAction();
        } while (updateChoice != 0);
    }

    internal void AddCategory()
    {
        Category category = new Category();
        category.Name = _userInput.GetName("category");
        CategoryDataManager.AddCategory(category);
    }

    internal void DeleteCategory()
    {
        int categoryId = _userInput.GetCategory().CategoryId;
        CategoryDataManager.RemoveCategory(categoryId);
    }

    internal void ViewCategories()
    {
        List<Category> categories = CategoryDataManager.GetCategories();
        _displayData.ShowCategories(categories);
        _userInput.PressToContinue();
    }

    internal void UpdateCategory()
    {
        Category category = _userInput.GetCategory();
        category.Name = _userInput.GetName("new category");
        CategoryDataManager.UpdateCategory(category);
    }
}