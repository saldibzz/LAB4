using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Form_Processing.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_Form_Processing.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index()
		{
			var greeting = "";
			var time = DateTime.Now;
			if (time.Hour < 12)
			{
				greeting = "Good morning!";
			}
			else if (time.Hour >= 12 && time.Hour < 18)
			{
				greeting = "Good Afternoon!";
			}
			else
			{
				greeting = "Good Evening!";
			}

			var shortTime = time.ToString("hh:mm tt");
			var day = time.DayOfWeek.ToString();
			var month = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(time.Month);

			int daysInYear = DateTime.IsLeapYear(time.Year) ? 366 : 365;
			var daysleft = daysInYear - time.DayOfYear;


			ViewData["greeting"] = greeting;
			ViewData["shortTime"] = shortTime;
			ViewData["day"] = day;
			ViewData["dayofmonth"] = time.Day;
			ViewData["month"] = month;
			ViewData["year"] = time.Year;
			ViewData["daysleft"] = daysleft;

			return View();
		}

		public IActionResult ShowPerson()
        {
			Person person = new Person();
			person.firstName = "Michael";
			person.lastName = "Holder";
			person.birthDate = DateTime.ParseExact("24/01/2000", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
			person.age = 17;

			ViewBag.Message = "Showing Person Details.";
			ViewBag.Person = person;

			return View(); 
        }
				
		
        public IActionResult Error()
        {
            return View();
        }

		
		
		[HttpGet]
		public IActionResult AddPerson()		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddPerson(Person person)
		{
			if (ModelState.IsValid)
			{
				ViewBag.Message = "Showing details of " + person.firstName;
				ViewBag.Person = person;
				return View("ShowPerson");
			}
			return View();
		}

		private readonly PersonContext _context;

		public HomeController(PersonContext context)
		{
			_context = context;
		}

		// GET: People
		public async Task<IActionResult> PersonDetails()
		{
			return View(await _context.Persons.ToListAsync());
		}

		// GET: People/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var person = await _context.Persons
				.SingleOrDefaultAsync(m => m.PersonId == id);
			if (person == null)
			{
				return NotFound();
			}

			return View(person);
		}

		// GET: People/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: People/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PersonId,firstName,lastName,birthDate,age")] Person person)
		{
			if (ModelState.IsValid)
			{
				_context.Add(person);
				await _context.SaveChangesAsync();
				return RedirectToAction("PersonDetails");
			}
			return View(person);
		}

		// GET: People/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonId == id);
			if (person == null)
			{
				return NotFound();
			}
			return View(person);
		}

		// POST: People/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("PersonId,firstName,lastName,birthDate,age")] Person person)
		{
			if (id != person.PersonId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(person);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PersonExists(person.PersonId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("PersonDetails");
			}
			return View(person);
		}

		// GET: People/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var person = await _context.Persons
				.SingleOrDefaultAsync(m => m.PersonId == id);
			if (person == null)
			{
				return NotFound();
			}

			return View(person);
		}

		// POST: People/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonId == id);
			_context.Persons.Remove(person);
			await _context.SaveChangesAsync();
			return RedirectToAction("PersonDetails");
		}

		private bool PersonExists(int id)
		{
			return _context.Persons.Any(e => e.PersonId == id);
		}
	}
}
