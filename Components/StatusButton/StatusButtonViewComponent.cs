using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Data;
using System.Linq;

namespace ToDoList.Components
{
    public class StatusButtonViewComponent : ViewComponent
    {
        private readonly ToDoContext _context;

        public StatusButtonViewComponent(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string statusId)
        {
            var status = await _context.Statuses.FindAsync(statusId);
            return View(status);
        }
    }
}