using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Data
{
    public class FacultiesViewComponent : ViewComponent
    {
        private readonly WilDbContext context;

        public FacultiesViewComponent(WilDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var faculties = await GetFacultiesAsync();
            return View(faculties);
        }

        private Task<List<Faculty>> GetFacultiesAsync()
        {
            return context.Faculties.OrderBy(x => x.Sorting).ToListAsync();
        }

    }
}
