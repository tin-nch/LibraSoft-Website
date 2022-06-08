using LibraSoftWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraSoftWeb.Controllers
{
    [ViewComponent(Name = "Piranha_PagesView")]
    public class Piranha_PagesViewComponent : ViewComponent
    {
        private DatabaseContext _databaseContext;
        public Piranha_PagesViewComponent(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPages = (from p in _databaseContext.Piranha_Pages
                               select p).ToList();
            return View(listofPages);
        }
    }
}
