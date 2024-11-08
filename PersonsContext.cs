using Microsoft.EntityFrameworkCore;

namespace Phonebook;

internal class PersonsContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source = persons.db");
}