using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;

namespace Work_Intergrated_Learning.Models
{
    public class InitialData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WilDbContext(serviceProvider.GetRequiredService<DbContextOptions<WilDbContext>>()))
            {
                if(context.Pages.Any())
                {
                    return;
                }

                context.Pages.AddRange(
                    new Page
                    {
                        Title = "Home",
                        Slug = "home",
                        Context = "home page",
                        Sorting = 0

                    }
                    );
                context.SaveChanges(); 
            }


        }

    }
}
