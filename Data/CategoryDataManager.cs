namespace Phonebook;

public class CategoryDataManager
{
    internal void AddCategory(Category category)
    {
        using var db = new ContactsContext();
        db.Add(category);
        db.SaveChanges();
    }
}