using Microsoft.EntityFrameworkCore;

namespace Phonebook;

internal class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source = contacts.db");
}