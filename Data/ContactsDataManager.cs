namespace Phonebook;

public class ContactsDataManager
{
    internal List<Contact> GetEntries()
    {
        using var db = new ContactsContext();
        return db.Contacts.ToList();
    }

    internal void AddNewContact(Contact contact)
    {
        using var db = new ContactsContext();
        db.Add(contact);
        db.SaveChanges();
    }

    internal void DeleteContact(Contact chosenOne)
    {
        using var db = new ContactsContext();
        db.Remove(chosenOne);
        db.SaveChanges();
    }

    internal void UpdateContact(Contact updatedContact)
    {
        var db = new ContactsContext();
        db.Update(updatedContact);
        db.SaveChanges();
    }
}