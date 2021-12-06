using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Controllers
{
    public class AccountController : Controller
    {
        //GET /Account/Register
        public IActionResult Register() => View();
        
    }

}
