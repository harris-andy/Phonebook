using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Contact> Contacts { get; } = new();
}