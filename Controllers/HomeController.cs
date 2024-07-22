using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using Microsoft.Extensions.Logging;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ToDoContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = _context.Statuses.ToList();

            IQueryable<Ticket> query = _context.Tickets.Include(t => t.Status);
            if (filters.HasStatus) query = query.Where(t => t.StatusId == filters.StatusId);
            var tickets = query.OrderBy(t => t.SprintNumber).ToList();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = _context.Statuses.ToList();
            var ticket = new Ticket { StatusId = "to do" };
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = _context.Statuses.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, Ticket selected)
        {
            selected = _context.Tickets.Find(selected.Id)!;
            if (selected != null)
            {
                selected.StatusId = "done";
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = _context.Tickets.Where(t => t.StatusId == "done").ToList();
            foreach (var ticket in toDelete)
            {
                _context.Tickets.Remove(ticket);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id });
        }
    }
}
