using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Form_Processing.Models
{
    public class PersonContext : DbContext
    {
		public PersonContext(DbContextOptions<PersonContext> options) : base(options)
		{
		}
		public DbSet<Person> Persons
		{
			get; set;
		}
    }
}
