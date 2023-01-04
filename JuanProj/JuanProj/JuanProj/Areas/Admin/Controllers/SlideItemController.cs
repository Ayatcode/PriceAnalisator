using Core.Entities;
using DataAccess.Contex;
using DataAccess.Interfaces;
using JuanProj.Utilities;
using JuanProj.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JuanProj.Areas.Areas.Controllers;

[Area("Admin")]
//[Authorize(Roles = "Admin","Moderator")]
public class SlideItemController : Controller
{
    private readonly ISlideItemsRepository _repository;
    private readonly IWebHostEnvironment _env;

    public SlideItemController(ISlideItemsRepository repository, IWebHostEnvironment env)
    {
        _repository = repository;
        _env = env;
    }



    public async Task<IActionResult> Index()
    {
        return View(await _repository.GetAllAsync());
    }
   
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SlideCreateVm slide)
    {
        if (!ModelState.IsValid) return View(slide);
        if (slide.Image == null)
        {
            ModelState.AddModelError("Photo", "Select Photo");
            return View(slide);
        }
        if (!slide.Image.CheckFileSize(300))
        {
            ModelState.AddModelError("Photo", "Image size must be less than 3");
            return View(slide);
        }
        if (!slide.Image.CheckFileFormat("image/"))
        {
            ModelState.AddModelError("Photo", "Choose img");
            return View(slide);
        }

        var filename = string.Empty;
        try
        {
            filename = await slide.Image.CopyFileAsync(_env.WebRootPath, "assets", "img", "slider");
        }
        catch (Exception)
        {

            return View(slide);
        }

        SlideItem slideItem = new SlideItem()
        {
            Title = slide.Title,
            Subtitle = slide.Subtitle,
            
            Image = filename

        };
        await _repository.CreateAsync(slideItem);
        await _repository.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Detail(int id)
    {
        var slide = await _repository.GetAsync(id);
        if (slide == null) { return NotFound(); }
        return View(slide);
    }

    // GET: SlideItemController/Edit/5
    public async Task<IActionResult> Update(int id)
    {
        var model = await _repository.GetAsync(id);
        if (model == null) { return NotFound(); }

        SlideCreateVm slideCreateVm = new SlideCreateVm()
        {
            Id = model.Id,
            Title = model.Title,
            Subtitle = model.Subtitle,

        };
        return View(slideCreateVm);

    }

    // POST: SlideItemController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, SlideCreateVm item)
    {
        if (id != item.Id) return BadRequest(item.Id);
        if (!ModelState.IsValid) return View(item);
        var model = await _repository.GetAsync(id);







        if (model == null) { return NotFound(); }
        var filename = string.Empty;
        if (item.Image != null)
        {

            try
            {
                filename = await item.Image.CopyFileAsync(_env.WebRootPath, "assets", "img", "slider");
            }
            catch (Exception)
            {

                return View(item);
            }
        }
        model.Title = item.Title;
        model.Subtitle = item.Subtitle;
        if (filename != null)
        {
            model.Image = filename;
        }
      
        _repository.Update(model);
        await _repository.SaveAsync();
        return RedirectToAction(nameof(Index));

    }

    // GET: SlideItemController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {

        var slide = await _repository.GetAsync(id);
        if (slide == null) return NotFound();
        return View(slide);
    }

    // POST: SlideItemController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> DeletePost(int id)
    {
        var slide = await _repository.GetAsync(id);
        if (slide == null) return NotFound();
        Helper.DeleteFile(_env.WebRootPath, "assets", "img", "slider");
        _repository.Delete(slide);
        await _repository.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
}
