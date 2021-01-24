using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotNet_Lista12.Data;
using dotNet_Lista12.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace dotNet_Lista12.Controllers
{
    public class ArticlesController : Controller
    {
        IHostingEnvironment _hostingEnvironment;
        private readonly MyDbContext _context;

        public ArticlesController(MyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            //wstrzyknięcie w konstruktor IHostingEnvironment
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Articles.Include(a => a.Category);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,Name,Price,Image,CategoryId")] Article article, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                //dodanie obrazka
                string filename = "images/no-images.png";
                if (imageFile != null)
                {
                    string Folder = _hostingEnvironment.WebRootPath;
                    filename = "upload/" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".jpg";
                    string filePath = Path.Combine(Folder, filename);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                }
                article.Image = filename;

                //-dodanie
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", article.CategoryId); //zmiana
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "Name", article.CategoryId); //zmiana
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "Name", article.CategoryId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,Name,Price,Image,CategoryId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            //zmiana - usuwanie obrazka
            if (article.Image != "image/noimage.jpg" & article.Image != null)
            {
                string Folder = _hostingEnvironment.WebRootPath;
                string filePath = Path.Combine(Folder, article.Image);
                System.IO.File.Delete(filePath);
            }
            //-zmiana
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
