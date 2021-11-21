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
    public class DepartmentController : Controller
    {
        private readonly WilDbContext context;

        public DepartmentController(WilDbContext context)
        {
            this.context = context;
        }


        //GET /admin/department
        public async Task<IActionResult> Index()
        {
            return View(await context.Departments.OrderBy(x => x.Sorting).ToListAsync());

        }
        //GET /admin/faculties/create 
        public IActionResult Create() => View();

        //Post /admin/department/create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.Slug = department.DepName.ToLower().Replace(" ", "-");
                department.Sorting = 100;

                var slug = await context.Faculties.FirstOrDefaultAsync(x => x.Slug == department.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Department already exists.");
                    return View(department);
                }

                context.Add(department);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Department has been added";

                return RedirectToAction("Index");
            }
            return View(department);
        }

        //GET /admin/department/Edit
        public async Task<IActionResult> Edit(int Id)
        {
            Department department = await context.Departments.FindAsync(Id);
            if (department == null)
                return NotFound();

            return View(department);

        }

        //POST /admin/department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                department.Slug = department.DepName.ToLower().Replace(" ", "-");


                var slug = await context.Departments.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == department.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Department already exists.");
                    return View(department);
                }

                context.Update(department);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Department has been edited";

                return RedirectToAction("Edit", new { id });
            }
            return View(department);
        }

        //GET /admin/department/Delete
        public async Task<IActionResult> Delete(int Id)
        {
            Department department = await context.Departments.FindAsync(Id);
            if (department == null)
            {
                TempData["Error"] = "The Department does not exist";
            }
            else
            {
                context.Departments.Remove(department);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Department has been deleted";
            }

            return RedirectToAction("Index");

        }


    }
}
