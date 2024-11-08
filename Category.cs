using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public List<Person> Persons { get; } = new();
}