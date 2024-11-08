using Spectre.Console;

namespace Phonebook;

public class DisplayData
{
    // public void MainMenu()
    // {
    //     Console.Clear();
    //     var menuBuilder = new System.Text.StringBuilder();

    //     menuBuilder.AppendLine("--------------------------------------------------")
    //                .AppendLine()
    //                .AppendLine("\t\tMAIN MENU")
    //                .AppendLine()
    //                .AppendLine("\tWhat would you like to do?")
    //                .AppendLine()
    //                .AppendLine("\tType 0 to Close Application")
    //                .AppendLine("\tType 1 to Add New Entry")
    //                .AppendLine("\tType 2 to Delete Entry")
    //                .AppendLine("\tType 3 to Update Entry")
    //                .AppendLine("\tType 4 to View Entries")
    //                //    .AppendLine("\tType 5 to View Study Sessions")
    //                //    .AppendLine("\tType 6 to View Study Sessions COUNT by Month")
    //                //    .AppendLine("\tType 7 to View Study Sessions GRADES by Month")
    //                //    .AppendLine("\tType 8 to Add Fake Data")
    //                //    .AppendLine("\tType 9 to Add Fake Study Sessions")
    //                .AppendLine("--------------------------------------------------");

    //     Console.WriteLine(menuBuilder.ToString());
    // }

    public void ShowContacts(List<Contact> contacts)
    {
        var table = new Table();
        bool isAlternateRow = false;

        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.Title("Contacts");
        table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
        table.AddColumn(new TableColumn("[green1]Name[/]").RightAligned());
        table.AddColumn(new TableColumn("[blue1]Phone Number[/]").RightAligned());
        table.AddColumn(new TableColumn("[yellow1]Email[/]").RightAligned());
        table.AddColumn(new TableColumn("[red1]Category[/]").LeftAligned());

        foreach (Contact contact in contacts)
        {
            var color = isAlternateRow ? "grey" : "blue";
            table.AddRow(
                $"[{color}]{contact.ContactId}[/]",
                $"[{color}]{contact.Name}[/]",
                $"[{color}]{contact.PhoneNumber}[/]",
                $"[{color}]{contact.Email}[/]",
                $"[{color}]{contact.Category.Name}[/]"
            );
            isAlternateRow = !isAlternateRow;
        }
        Console.Clear();
        AnsiConsole.Write(table);
    }

    public void ShowCategories(List<Category> categories)
    {
        var table = new Table();
        bool isAlternateRow = false;

        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.Title("Categories");
        table.AddColumn(new TableColumn("[cyan1]Category[/]").LeftAligned());
        // table.AddColumn(new TableColumn("[green1]Name[/]").RightAligned());
        // table.AddColumn(new TableColumn("[blue1]Phone Number[/]").RightAligned());
        // table.AddColumn(new TableColumn("[yellow1]Email[/]").RightAligned());
        // table.AddColumn(new TableColumn("[red1]Category[/]").LeftAligned());

        foreach (Category category in categories)
        {
            var color = isAlternateRow ? "grey" : "blue";
            table.AddRow(
                $"[{color}]{category.Name}[/]"
            // $"[{color}]{contact.Name}[/]",
            // $"[{color}]{contact.PhoneNumber}[/]",
            // $"[{color}]{contact.Email}[/]",
            // $"[{color}]{contact.Category.Name}[/]"
            );
            isAlternateRow = !isAlternateRow;
        }
        Console.Clear();
        AnsiConsole.Write(table);
    }

    // internal void PressToContinue()
    // {
    //     Console.WriteLine($"Press a key to continue...");
    //     Console.Read();
    // }



}

