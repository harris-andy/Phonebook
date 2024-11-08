using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook
{
    public class DataManager
    {
        internal List<Person> GetEntries()
        {
            using var db = new PersonsContext();
            return db.Persons.ToList();
        }

        internal void AddNewPerson(Person person)
        {
            using var db = new PersonsContext();
            db.Add(person);
            db.SaveChanges();
        }

        internal void DeletePerson(Person chosenOne)
        {
            using var db = new PersonsContext();
            db.Remove(chosenOne);
            db.SaveChanges();
        }

        internal void UpdatePerson(Person updatedPerson)
        {
            var db = new PersonsContext();
            db.Update(updatedPerson);
            db.SaveChanges();
        }
    }
}