using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebUI.Areas.Admin.ViewModels.Slider;
using WebUI.Utilities;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideItemController : Controller
    {
        private readonly ISlideItems _repository;
        private readonly IWebHostEnvironment _env;
        private int _count;

        public SlideItemController(ISlideItems repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
            
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Count = _count;
            return View(await _repository.GetAllAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            var slide=await _repository.GetAsync(id);
            if (slide == null) { return NotFound(); }
            return View(slide);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SlideCreateVM slide)
        {
            if (!ModelState.IsValid) return View(slide);
            if(slide.Photo==null)
            {
                ModelState.AddModelError("Photo", "Select Photo");
                return View(slide);
            }
            if (!slide.Photo.CheckFileSize(300))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 3");
                return View(slide);
            }
            if (!slide.Photo.CheckFileFormat("image/")) 
            {
                ModelState.AddModelError("Photo", "Choose img");
                return View(slide);
            }

            //var wwwroot = _env.WebRootPath;
            //var filename = Guid.NewGuid().ToString() + slide.Photo.FileName;
            //var resultPath = Path.Combine(wwwroot, "assets", "images", "website-images",filename);
            //using(FileStream stream=new FileStream(resultPath, FileMode.Create))
            //{
            //    await slide.Photo.CopyToAsync(stream);
            //}
            var filename = string.Empty;
            try
            {
                 filename = await slide.Photo.CopyFileAsync(_env.WebRootPath, "assets", "images", "website-images");
            }
            catch (Exception)
            {

                return View(slide);
            }
            
            SlideItem slideItem = new SlideItem()
            {
                Title= slide.Title,
                Offer= slide.Offer,
                Description= slide.Description,
                Photo=filename

            };
            await _repository.CreateAsync(slideItem);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            var slide = await _repository.GetAsync(id);
            if (slide == null) return NotFound();
            return View(slide);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_count == 1) return BadRequest();
            var slide = await _repository.GetAsync(id);
            if (slide == null) return NotFound();
            Helper.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            _repository.Delete(slide);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _repository.GetAsync(id);
            if (model == null) { return NotFound(); }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ShippingItem item)
        {
            if (id != item.Id) return BadRequest(item.Id);
            if (!ModelState.IsValid) return View(item);
            var model = await _repository.GetAsync(id);
            if (model == null) { return NotFound(); }
            model.Title = item.Title;
            model.Description = item.Description;
            model.Photo = item.Photo;
            _repository.Update(model);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
