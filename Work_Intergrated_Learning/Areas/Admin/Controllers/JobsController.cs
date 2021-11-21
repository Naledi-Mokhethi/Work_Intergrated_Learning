﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class JobsController : Controller
    {
        private readonly WilDbContext context;

        public JobsController(WilDbContext context)
        {
            this.context = context;
        }
        //GET /admin/Jobs
        public async Task<IActionResult> Index()
        {
            return View(await context.Jobs.OrderBy(x => x.Sorting).ToListAsync());

        }

        //GET /admin/jobs/create 
        public IActionResult Create() {
            ViewBag.FacultyId = new SelectList(context.Faculties.OrderBy(x => x.Sorting), "Id", "Name");

            return View();
        }


        //Post /admin/jobs/create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jobs job)
        {
            if (ModelState.IsValid)
            {
                job.Slug = job.JobTitle.ToLower().Replace(" ", "-");
                job.Sorting = 100;

                var slug = await context.Jobs.FirstOrDefaultAsync(x => x.Slug == job.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Job already exists.");
                    return View();
                }

                context.Add(job);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been added";

                return RedirectToAction("Index");
            }
            return View(job);
        }

        //GET /admin/faculties/Edit
        public async Task<IActionResult> Edit(int Id)
        {
            Jobs job = await context.Jobs.FindAsync(Id);
            if (job == null)
                return NotFound();

            return View(job);

        }

        //POST /admin/faculties/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Jobs job)
        {
            if (ModelState.IsValid)
            {
                job.Slug = job.JobTitle.ToLower().Replace(" ", "-");


                var slug = await context.Faculties.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == faculty.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Faculty already exists.");
                    return View(job);
                }

                context.Update(job);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been edited";

                return RedirectToAction("Edit", new { id });
            }
            return View(job);
        }

        //GET /admin/faculties/Delete
        public async Task<IActionResult> Delete(int Id)
        {
            Jobs job = await context.Jobs.FindAsync(Id);
            if (job == null)
            {
                TempData["Error"] = "The Faculty does not exist";
            }
            else
            {
                context.Jobs.Remove(job);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Faculty has been deleted";
            }

            return RedirectToAction("Index");

        }


    }
}
