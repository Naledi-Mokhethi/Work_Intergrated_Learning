using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Controllers
{
    public class PagesController : Controller
    {
        private readonly WilDbContext context;

        public PagesController(WilDbContext context)
        {
            this.context = context;
        }


        //GET / or /slug
        public async Task<IActionResult> Page(string slug)
        {
            if (slug == null)
            {
                return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();

            if (page == null)
            {
                return NotFound();
            }

            return View(page);

        }
    }
}
