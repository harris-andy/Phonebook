using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Phonebook;

// public class Category
// {
//     [Key]
//     public int CategoryId { get; set; }

//     public List<Person> Persons { get; } = new();
// }

[Index(nameof(Name), IsUnique = true)]
public class Contact
{
    [Key]
    public int ContactId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = default!;
}