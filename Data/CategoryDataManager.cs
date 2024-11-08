namespace Phonebook;

public class CategoryDataManager
{
    internal static void AddCategory(Category category)
    {
        using var db = new PhonebookContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new PhonebookContext();
        return db.Categories.ToList();
    }

    // internal List<Category> GetEntries()
    // {
    //     using var db = new PhonebookContext();
    //     var categories = db.
    //     return db.Contacts.ToList();
    // }
}