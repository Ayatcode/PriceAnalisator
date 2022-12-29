using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Areas.Admin.ViewModels.Members;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;



        public MemberController(UserManager<AppUser> userManager, AppDbContext context)
        {

            _userManager = userManager;
            _context = context;
        }

        // GET: MemberController
        public async Task<IActionResult> Index()
        {
            List<MembersVM> userPositions = new List<MembersVM>();
            foreach (var user in await _context.Users.ToListAsync())
            {
                bool resultMember = await _userManager.IsInRoleAsync(user, "Member");
                bool resulManager = await _userManager.IsInRoleAsync(user, "Admin");
                if (resultMember || resulManager)
                {
                    MembersVM userPositionVM = new MembersVM();
                    userPositionVM.UserName = user.UserName;
                    userPositionVM.Position = (await _userManager.GetRolesAsync(user))[0];
                    userPositions.Add(userPositionVM);
                }
            }
            return View(userPositions);
        }


        // GET: MemberController/Details/5
        public async Task<IActionResult> RaiseAdmin(string username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            await _userManager.RemoveFromRoleAsync(appUser, (await _userManager.GetRolesAsync(appUser))[0]);
            await _userManager.AddToRoleAsync(appUser, "Admin");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LowerToMember(string username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            await _userManager.RemoveFromRoleAsync(appUser, (await _userManager.GetRolesAsync(appUser))[0]);
            await _userManager.AddToRoleAsync(appUser, "Member");
            return RedirectToAction(nameof(Index));

        }
        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
