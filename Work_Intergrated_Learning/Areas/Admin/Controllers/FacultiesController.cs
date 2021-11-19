using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacultiesController : Controller
    {

        private readonly WilDbContext context;

        public FacultiesController(WilDbContext context)
        {
            this.context = context;
        }
        //Get /admin/faculties
        public async Task<IActionResult> Index()
        {
            return View(await context.Faculties.OrderBy(x => x.Sorting).ToListAsync());

        }
        //Get /admin/faculties/create 
        public IActionResult Create() => View();

        //Post /admin/faculties/create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                faculty.Slug = faculty.FacultyName.ToLower().Replace(" ", "-");
                faculty.Sorting = 100;

                var slug = await context.Faculties.FirstOrDefaultAsync(x => x.Slug == faculty.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The faculty already exists.");
                    return View(faculty);
                }

                context.Add(faculty);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been added";

                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        //GET /admin/faculties/Edit
        public async Task<IActionResult> Edit(int Id)
        {
            Faculty faculty = await context.Faculties.FindAsync(Id);
            if (faculty == null)
                return NotFound();

            return View(faculty);

        }

        //POST /admin/faculties/Edit
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id,Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                faculty.Slug = faculty.FacultyName.ToLower().Replace(" ", "-");


                var slug = await context.Faculties.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == faculty.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Faculty already exists.");
                    return View(faculty);
                }

                context.Update(faculty);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been edited";

                return RedirectToAction("Edit", new {id});
            }
            return View(faculty);
        }

        //GET /admin/faculties/Delete
        public async Task<IActionResult> Delete(int Id)
        {
            Faculty faculty = await context.Faculties.FindAsync(Id);
            if (faculty == null)
            {
                TempData["Error"] = "The Faculty does not exist";
            }
            else
            {
                context.Faculties.Remove(faculty);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been deleted";
            }

            return RedirectToAction("Index");

        }





    }

    
}
