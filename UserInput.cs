using Spectre.Console;
using System.Net.Mail;
using PhoneNumbers;
using System.Globalization;

namespace Phonebook;

public class UserInput
{
    // public int GetMenuChoice(int start, int end, string text)
    // {
    //     int menuChoice = AnsiConsole.Prompt(
    //     new TextPrompt<int>(text)
    //     .Validate((n) =>
    //     {
    //         if (start <= n && n <= end)
    //             return ValidationResult.Success();
    //         else
    //             return ValidationResult.Error($"[red]Pick a valid option[/]");
    //     }));
    //     return menuChoice;
    // }

    public int MainMenu()
    {
        Console.Clear();
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose an option:")
                .AddChoices(
                    "0 - Exit Application",
                    "1 - Add New Entry",
                    "2 - Delete Entry",
                    "3 - Update Entry",
                    "4 - View Entries",
                    "5 - Add Category",
                    "6 - View Categories",
                    "7 - Delete Category",
                    "8 - Update Category",
                    "9 - Send Email"
                ));
        int menuChoice = int.Parse(choice.Split('-')[0].Trim());

        return menuChoice;
    }

    public string GetName(string type)
    {
        return AnsiConsole.Ask<string>($"Enter {type} name: ");
    }

    public string GetEmail()
    {
        string message = "Enter the email address. Format it like blahblah@blah.com: ";

        string nameChoice = AnsiConsole.Prompt(
        new TextPrompt<string>(message)
        .Validate((n) =>
        {
            try
            {
                var email = new MailAddress(n);
                return ValidationResult.Success();
            }
            catch (FormatException)
            {
                return ValidationResult.Error($"[red]Enter a valid email. Please.[/]");
            }
        }));
        return nameChoice;
    }

    public string GetCountryCode()
    {
        string code = AnsiConsole.Prompt(
        new TextPrompt<string>("Enter two character country code (e.g. US or FR)")
        .Validate((n) =>
        {
            try
            {
                var region = new RegionInfo(n.ToUpper());
                return ValidationResult.Success();
            }
            catch (ArgumentException)
            {
                return ValidationResult.Error($"[red]Enter a valid country code. Please.[/]");
            }
        }));
        return code.ToUpper();
    }

    public string GetPhoneNumber()
    {
        string countryCode = GetCountryCode();
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        string number = AnsiConsole.Prompt(
        new TextPrompt<string>("Enter a valid phone number")
        .Validate((n) =>
        {
            var testNumber = phoneNumberUtil.Parse(n, countryCode);
            if (phoneNumberUtil.IsValidNumber(testNumber))
                return ValidationResult.Success();
            else
                return ValidationResult.Error($"[red]Enter a valid phone number for country code {countryCode}. Seriously.[/]");
        }));
        var phoneNumber = phoneNumberUtil.Parse(number, countryCode);
        return phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);
    }

    internal Contact GetContact(List<Contact> contacts, string message)
    {
        Console.Clear();
        Contact chosenContact = AnsiConsole.Prompt(
            new SelectionPrompt<Contact>()
                .Title(message)
                .UseConverter(contact => contact.Name)
                .AddChoices(contacts));

        return chosenContact;
    }

    internal Category GetCategory()
    {
        Console.Clear();
        List<Category> categories = CategoryDataManager.GetCategories();
        if (categories.Count() == 1)
            return categories.First();
        Category category = AnsiConsole.Prompt(
            new SelectionPrompt<Category>()
                .Title("Choose a category: ")
                .UseConverter(category => category.Name)
                .AddChoices(categories));
        return category;
    }

    // internal Contact GetUpdatedContact(Contact contact)
    // {
    //     contact.Name = AnsiConsole.Ask<string>($"Enter new name for {contact.Name}: ");
    //     contact.Email = GetEmail();
    //     contact.PhoneNumber = GetPhoneNumber();

    //     return contact;
    // }

    internal bool GetConfirmation(string message)
    {
        return AnsiConsole.Confirm(message);
    }

    internal int ChooseContactToUpdate()
    {
        // Console.Clear();
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose what to change:")
                .AddChoices(
                    "0 - Back to Main Menu (uncommitted changes will be lost!)",
                    "1 - Name",
                    "2 - Phone Number",
                    "3 - Email",
                    "4 - Category",
                    "5 - Commit Changes"
                ));

        return int.Parse(choice.Split('-')[0].Trim());
    }

    internal bool BackToMainMenu()
    {
        Console.WriteLine($"Press 0 to return to main menu");
        ConsoleKeyInfo button = Console.ReadKey(true);

        if (button.Key == ConsoleKey.NumPad0 || button.Key == ConsoleKey.D0)
            return true;

        return false;
    }

    internal void PressToContinue()
    {
        Console.WriteLine($"Press any key to continue...");
        Console.Read();
    }
}
