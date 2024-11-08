using System.ComponentModel.DataAnnotations;
using PhoneNumbers;

namespace Phonebook;

public class PhonebookController
{
    private readonly DisplayData _displayData;
    private readonly UserInput _userInput;
    private readonly DataManager _dataManager;

    public PhonebookController(DisplayData displayData, UserInput userInput, DataManager dataManager)
    {
        _displayData = displayData;
        _userInput = userInput;
        _dataManager = dataManager;
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
                    AddPerson();
                    break;
                case 2:
                    DeletePerson();
                    break;
                case 3:
                    UpdatePerson();
                    break;
                case 4:
                    ViewRecords();
                    break;
                case 5:
                    // ViewStudySessions();
                    break;
                case 6:
                    // StudyReport("counts");
                    break;
                case 7:
                    // StudyReport("grades");
                    break;
                case 8:
                    // AddFakeData();
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

    private void AddPerson()
    {
        string name = _userInput.GetName();
        string email = _userInput.GetEmail();
        string countryCode = _userInput.GetCountryCode();
        string phoneNumber = _userInput.GetPhoneNumber();

        // using var db = new PersonsContext();
        // db.Add(new Person { Name = name, Email = email, PhoneNumber = phoneNumber });
        // db.SaveChanges();

        Person person = new Person { Name = name, Email = email, PhoneNumber = phoneNumber };
        _dataManager.AddNewPerson(person);
    }

    private void DeletePerson()
    {
        List<Person> persons = _dataManager.GetEntries();
        // _displayData.ShowPersons(persons);
        // _displayData.PressToContinue();
        string chooseMessage = "Choose person to be elminated: ";
        // string name = _userInput.GetString(message);
        Person chosenOne = _userInput.GetPerson(persons, chooseMessage);
        List<Person> chosenList = new List<Person> { chosenOne };
        _displayData.ShowPersons(chosenList);
        string deleteMessage = "Are you sure you want to delete this person?";
        if (_userInput.GetConfirmation(deleteMessage))
            _dataManager.DeletePerson(chosenOne);

    }

    private void ViewRecords()
    {
        List<Person> persons = _dataManager.GetEntries();
        _displayData.ShowPersons(persons);
        _userInput.PressToContinue();
    }

    private void UpdatePerson()
    {
        List<Person> persons = _dataManager.GetEntries();
        string message = "Choose person to update: ";
        Person chosenOne = _userInput.GetPerson(persons, message);
        List<Person> chosenList = new List<Person> { chosenOne };
        int updateChoice;

        do
        {
            _displayData.ShowPersons(chosenList);
            updateChoice = _userInput.ChoosePersonToUpdate();
            Action performAction = updateChoice switch
            {
                0 => () => ShowMainMenu(),
                1 => () => chosenOne.Name = _userInput.GetName(),
                2 => () => chosenOne.PhoneNumber = _userInput.GetPhoneNumber(),
                3 => () => chosenOne.Email = _userInput.GetEmail(),
                4 => () =>
                {
                    _dataManager.UpdatePerson(chosenOne);
                    Console.WriteLine($"\nChanges committed!\n");
                    _userInput.PressToContinue();
                }
                ,
                _ => () => Console.WriteLine($"I don't know how you even got here. Retreat!")
            };
            performAction();
        } while (updateChoice != 0);

        // Person updatedPerson = _userInput.GetUpdatedPerson(chosenOne);
        // if (_userInput.BackToMainMenu()) ShowMainMenu();
        // _dataManager.UpdatePerson(updatedPerson);
    }
}