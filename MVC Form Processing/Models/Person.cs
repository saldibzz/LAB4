using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Form_Processing.Models
{
	[Table("PersonDetails")]
	public class Person
    {
		[Key]
		public int PersonId
		{
			get; set;
		}

		[StringLength(20, MinimumLength = 2)]
		[Display(Name = "First Name")]
		[Required(ErrorMessage = "This is a required field")]		
		public String firstName
		{
			get; set;
		}

		[StringLength(20, MinimumLength = 2)]
		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "This is a required field")]
		public String lastName
		{
			get; set;
		}

		[Display(Name = "Date of Birth"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		[Required(ErrorMessage = "This is a required field")]
		[DataType(DataType.DateTime)]
		public DateTime birthDate
		{
			get; set;
		}

		[Display(Name = "Age")]
		[Range(0, 100, ErrorMessage = "Please enter valid integer Number")]
		[Required(ErrorMessage = "This is a required field")]
		[DataType(DataType.PhoneNumber)]
		public int age
		{
			get; set;
		}

    }
}
