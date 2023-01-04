using Core.Entities;
using DataAccess.Contex;
using Microsoft.AspNetCore.Mvc;

namespace JuanProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _slide = _context.SlideItems;
            return View(_slide);
        }
    }
}
