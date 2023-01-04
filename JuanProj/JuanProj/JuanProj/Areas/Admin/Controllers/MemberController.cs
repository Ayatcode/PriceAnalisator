using Core.Entities;
using DataAccess.Contex;
using DataAccess.Migrations;
using JuanProj.Areas.Admin.Models.CreateVM;
using JuanProj.Areas.Admin.Models.Member;
using JuanProj.Areas.Admin.Models.UpdateVm;
using JuanProj.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static JuanProj.Utilities.Helper;

namespace JuanProj.Areas.Admin.Controllers;

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
            bool resulManager = await _userManager.IsInRoleAsync(user, "Moderator");
            if (resultMember || resulManager)
            {
                MembersVM userPositionVM = new MembersVM();
                userPositionVM.UserName = user.UserName;
                userPositionVM.Id = user.Id;
                userPositionVM.Position = (await _userManager.GetRolesAsync(user))[0];

                userPositions.Add(userPositionVM);
            }
        }
        return View(userPositions);
    }


    public  IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult>Create(CreateVM createVM)
    {
        if(!ModelState.IsValid) {  return View(createVM); }

        AppUser appUser = new()
        {

            UserName = createVM.Username,
            Email = createVM.Email,
            
            IsActive = true
        };
        var identityResult = await _userManager.CreateAsync(appUser, createVM.Password);
        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(createVM);
        }
        await _userManager.AddToRoleAsync(appUser, createVM.DisplayRole);


        return RedirectToAction(nameof(Index));
        
    }

    public async Task<IActionResult> Update(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) { return NotFound(); }
        var userRole = (await _userManager.GetRolesAsync(user))[0];
        UpdateVM updateVM = new UpdateVM()
        {
            UserName = user.UserName,
            Email = user.Email,
            DisplayRole = userRole
        };
        
        return View(updateVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Update(string id, UpdateVM updateVM)
    {
        if (!ModelState.IsValid) {return View(updateVM);}
        var user = await _userManager.FindByIdAsync(id);
        var userRole= (await _userManager.GetRolesAsync(user))[0];

        user.UserName=updateVM.UserName; 
        user.Email=updateVM.Email;
        if (userRole != updateVM.DisplayRole)
        {
            await _userManager.RemoveFromRoleAsync(user, userRole);
            await _userManager.AddToRoleAsync(user,updateVM.DisplayRole);
        }
        await _userManager.ChangePasswordAsync(user,user.PasswordHash,updateVM.Password);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    

    public async Task<IActionResult> Delete(string id)
    {
        var user= await _userManager.FindByIdAsync(id);
        if (user == null) { return NotFound(); }

        await _userManager.DeleteAsync(user);
        return RedirectToAction(nameof(Index));
    }


    
    public async Task<IActionResult> RaiseModerator(string username)
    {
        AppUser appUser = await _userManager.FindByNameAsync(username);
        await _userManager.RemoveFromRoleAsync(appUser, (await _userManager.GetRolesAsync(appUser))[0]);
        await _userManager.AddToRoleAsync(appUser, "Moderator");
     
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> LowerToMember(string username)
    {
        AppUser appUser = await _userManager.FindByNameAsync(username);
        await _userManager.RemoveFromRoleAsync(appUser, (await _userManager.GetRolesAsync(appUser))[0]);
        await _userManager.AddToRoleAsync(appUser, "Member");
        return RedirectToAction(nameof(Index));

    }
}