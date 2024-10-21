using LibraryProject.Models;
using LibraryProject.Repositories;
using LibraryProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class KindController : Controller
    {
        private readonly IKindrepo kindrepo;

        public KindController(IKindrepo _kindrepo)
        {
            kindrepo = _kindrepo;
        }
        public IActionResult Index()
        {
            var allkinds = kindrepo.GetAll();
            var allkindVMs =new List<KindVM>();

            if(allkinds != null)
            {
                foreach(var kind in allkinds)
                {
                    var kindVM =new KindVM();
                    kindVM.Id = kind.Id;
                    kindVM.Name = kind.Name;
                    allkindVMs.Add(kindVM);
                }
            }
            return View(allkindVMs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(KindVM kindVM)
        {
            if (ModelState.IsValid)
            {
                var kind = new Kind();
                kind.Name = kindVM.Name;

                kindrepo.Add(kind);
                kindrepo.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(kindVM);
            }
        }

        public IActionResult Edit(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            else
            {
                var kind = kindrepo.GetById(Id);
                if (kind == null)
                    return NotFound();

                var kindVM = new KindVM();
                kindVM.Id = kind.Id;
                kindVM.Name = kind.Name;
                return View(kindVM);
            }

        }
        [HttpPost]
        public IActionResult Edit(KindVM kindVM)
        {
            if (ModelState.IsValid)
            {
                var kind = kindrepo.GetById(kindVM.Id);
                if (kind == null)
                    return View(kindVM);

                kind.Name = kindVM.Name;
                kindrepo.Update(kind);
                kindrepo.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View(kindVM);
            }
        }
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var kind = kindrepo.GetById(Id);
            if (kind != null)
            {
                var kindVM = new KindVM();
                kindVM.Id = kind.Id;
                kindVM.Name = kind.Name;
                return View(kindVM);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(KindVM kindVM)
        {
            if (kindVM.Id == 0)
            {
                return NotFound();
            }
            var kind = kindrepo.GetById(kindVM.Id);
            if (kind != null)
            {
                kindrepo.Remove(kind);
                kindrepo.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();

        }


    }
}
