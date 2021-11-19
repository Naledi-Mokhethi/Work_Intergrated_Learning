using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;

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
        //Get /admin/Jobs
        public async Task<IActionResult> Index()
        {
            return View(await context.Jobs.OrderBy(x => x.Sorting).ToListAsync());

        }

        //Get /admin/jobs/create 
        public IActionResult Create() {
            ViewBag.FacultyId = new SelectList(context.Faculties.OrderBy(x => x.Sorting), "Id", "Name");

            return View();
        } 


    }
}
