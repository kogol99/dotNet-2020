using dotNet_Lista11.DataContext;
using dotNet_Lista11.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lista11.Controllers
{
    public class UserController : Controller
    {
        private readonly ICRUDContext<UserViewModel> _dataContext;

        public UserController(ICRUDContext<UserViewModel> dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(_dataContext.GetViewModels());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(_dataContext.Read(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataContext.Create(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_dataContext.Read(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Id = id;
                    _dataContext.Update(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_dataContext.Read(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _dataContext.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
