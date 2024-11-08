namespace Phonebook;

public class ContactsDataManager
{
    internal List<Contact> GetEntries()
    {
        using var db = new PhonebookContext();
        return db.Contacts.ToList();
    }

    internal void AddNewContact(Contact contact)
    {
        using var db = new PhonebookContext();
        db.Add(contact);
        db.SaveChanges();
    }

    internal void DeleteContact(Contact chosenOne)
    {
        using var db = new PhonebookContext();
        db.Remove(chosenOne);
        db.SaveChanges();
    }

    internal void UpdateContact(Contact updatedContact)
    {
        var db = new PhonebookContext();
        db.Update(updatedContact);
        db.SaveChanges();
    }
}