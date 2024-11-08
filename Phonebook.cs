using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phonebook;

// public class Category
// {
//     public int CategoryId { get; set; }

//     public List<Person> Persons { get; } = new();
// }

[Index(nameof(Name), IsUnique = true)]
public class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    // public string Category { get; set; } = string.Empty;

    // public int CategoryId { get; set; }

    // public Category Category { get; set; } = new();
}