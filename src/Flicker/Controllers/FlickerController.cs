using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Flicker.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Flicker.Controllers
{
    [Authorize]
    public class FlickerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlickerController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> MyImages()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Images.Where(x => x.User.Id == currentUser.Id));
        }

        public IActionResult Index()
        {
            return View(_db.Images.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Image image)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            image.User = currentUser;
            _db.Images.Add(image);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == id);
            return View(thisImage);
        }

        public IActionResult Edit(int id)
        {
            var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == id);
            return View(thisImage);
        }

        [HttpPost]
        public IActionResult Edit(Image image)
        {
            _db.Entry(image).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = _db.Images.FirstOrDefault(items => items.ImageId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = _db.Images.FirstOrDefault(items => items.ImageId == id);
            _db.Images.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
