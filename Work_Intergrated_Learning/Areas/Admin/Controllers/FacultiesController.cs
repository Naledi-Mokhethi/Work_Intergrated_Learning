using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}
