using dotNet_Lista12.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace dotNet_Lista12.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;

        public ShopController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var ArticlesDbContext = await _context.Articles.Include(a => a.Category).ToListAsync();
            var isWithId = false;

            if (id != null)
            {
                isWithId = true;
                ArticlesDbContext = await _context.Articles.Include(a => a.Category).Where(a => a.CategoryId == id).ToListAsync();
            }

            var CategoriesDbContext = await _context.Categories.ToListAsync();
            dynamic vm = new ExpandoObject();
            vm.Categories = CategoriesDbContext;
            vm.Articles = ArticlesDbContext;
            vm.isWithId = isWithId;

            return View(vm);
        }
    }
}
