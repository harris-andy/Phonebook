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

    internal static void RemoveCategory(int categoryId)
    {
        using var db = new PhonebookContext();
        db.Remove(new Category { CategoryId = categoryId });
        db.SaveChanges();
    }
}