using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;

namespace Work_Intergrated_Learning.Controllers
{
    public class JobsController : Controller
    {
        private readonly WilDbContext context;
        public JobsController(WilDbContext context)
        {
            this.context = context;
        }

        //GET /Jobs
        public async Task<IActionResult> Index()
        {
            return View(await context.Jobs.OrderBy(x => x.Sorting).ToListAsync());

        }


    }
}
